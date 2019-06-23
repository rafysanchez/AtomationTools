// Copyright 2016 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;

namespace AccessBridgeExplorer {
  public partial class UpdateChecker : Component {
    private bool _enabled;
    private int _timerTick;
    //private Exception _lastCheckError;

    public UpdateChecker() {
      InitializeComponent();
    }

    public UpdateChecker(IContainer container) {
      container.Add(this);

      InitializeComponent();
    }

    public string Url { get; set; }

    public event EventHandler<UpdateInfoArgs> UpdateInfoAvailable;
    public event EventHandler<ErrorEventArgs> UpdateInfoError;

    public bool Enabled {
      get {
        return _enabled; 
      }
      set {
        if (_enabled == value)
          return;

        _enabled = value;
        checkTimer.Enabled = value;
        if (value) {
          ResetTimer();
          SetTimerInterval();
        }
      }
    }

    public void CheckNow() {
      CheckForUpdate();
    }

    private void SetTimerInterval() {
      if (_timerTick == 0)
        checkTimer.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
      else
        checkTimer.Interval = (int)TimeSpan.FromDays(1).TotalMilliseconds;
    }

    private void ResetTimer() {
      _timerTick = 0;
    }

    private void checkTimer_Tick(object sender, EventArgs e) {
      CheckForUpdate();
      _timerTick++;
      SetTimerInterval();
    }

    private void CheckForUpdate() {
      if (string.IsNullOrEmpty(Url))
        return;

      try {
        var latestVersionInfo = new UpdateInfoProvider().GetUpdateInfo(Url);
        OnUpdateInfoAvailable(latestVersionInfo);
      } catch (Exception e) {
        OnUpdateInfoError(new ErrorEventArgs(e));
      }
    }


    protected virtual void OnUpdateInfoAvailable(UpdateInfoArgs e) {
      var handler = UpdateInfoAvailable;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnUpdateInfoError(ErrorEventArgs e) {
      var handler = UpdateInfoError;
      if (handler != null) handler(this, e);
    }

    public class UpdateInfoProvider {
      public UpdateInfoArgs GetUpdateInfo(string url) {
        try {
          var webRequest = WebRequest.Create(url);
          using (var response = webRequest.GetResponse()) {
            using (var stream = response.GetResponseStream()) {
              if (stream == null) {
                throw new ApplicationException("No response from server");
              }
              using (var reader = new StreamReader(stream)) {
                var contents = reader.ReadToEnd();
                try {
                  return ParseUpdateInfo(contents);
                } catch (Exception e) {
                  throw new InvalidDataException("Invalid file contents", e);
                }
              }
            }
          }
        } catch (Exception e) {
          throw new ApplicationException(string.Format("Error retrieving latest version information at {0}", url), e);
        }
      }

      private UpdateInfoArgs ParseUpdateInfo(string contents) {
        using (var reader = new StringReader(contents)) {
          var lines = ParseEntries(ReadLines(reader)).ToList();
          var version = lines.First(x => StringComparer.OrdinalIgnoreCase.Equals(x.Key, "version")).Value;
          var url = lines.First(x => StringComparer.OrdinalIgnoreCase.Equals(x.Key, "url")).Value;
          return new UpdateInfoArgs {
            Version = new Version(version),
            Url = new Uri(url)
          };
        }
      }

      private IEnumerable<LineEntry> ParseEntries(IEnumerable<string> lines) {
        foreach (var line in lines) {
          var separatorIndex = line.IndexOf(':');
          if (separatorIndex <= 0 || separatorIndex >= line.Length - 1)
            continue;
          var key = line.Substring(0, separatorIndex);
          var value = line.Substring(separatorIndex + 1);
          yield return new LineEntry {
            Key = key.Trim(),
            Value = value.Trim()
          };
        }
      }

      private IEnumerable<string> ReadLines(TextReader reader) {
        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
          yield return line;
      }

      class LineEntry {
        public string Key { get; set; }
        public string Value { get; set; }
      }
    }
  }
}
