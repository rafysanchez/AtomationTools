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
using System.IO;
using System.Linq;
using System.Text;

namespace AccessBridgeExplorer.Utils.Settings {
  public class UserSettings : IUserSettings {
    private readonly string _directoryName;
    private readonly Dictionary<string, string> _values = new Dictionary<string, string>();

    public UserSettings(string directoryName) {
      if (string.IsNullOrWhiteSpace(directoryName)) {
        throw new ArgumentException(@"Invalid user settings file directory name", "directoryName");
      }
      _directoryName = directoryName;
    }

    public event EventHandler<ErrorEventArgs> Error;
    public event EventHandler Loaded;
    public event EventHandler Saving;
    public event EventHandler<SettingValueChangedEventArgs> ValueChanged;

    public void Load() {
      Wrap("Error loading settings", () => {
        var path = GetFilePath();
        if (!File.Exists(path)) {
          return;
        }

        var lines = File.ReadAllLines(path);
        foreach (var line in lines) {
          ProcessLine(line);
        }

        OnLoaded();
      });
    }

    public void Save() {
      Wrap("Error loading settings", () => {
        OnSaving();

        var sb = new StringBuilder();
        foreach (var pair in _values.OrderBy(x => x.Key)) {
          sb.AppendFormat("{0}={1}", pair.Key, pair.Value);
          sb.AppendLine();
        }

        var path = GetFilePath();
        var tempPath = path + ".tmp";
        File.WriteAllText(tempPath, sb.ToString());
        if (File.Exists(path)) {
          File.Delete(path);
        }
        File.Move(tempPath, path);
      });
    }

    public void Clear() {
      Wrap("Error deleting options file", () => {
        var path = GetFilePath();
        if (File.Exists(path)) {
          File.Delete(path);
        }
      });
    }

    public void SetValue(string key, string defaultValue, string value) {
      CheckValidKey(key);
      CheckValidValue(value);

      string previousValue;
      if (!_values.TryGetValue(key, out previousValue)) {
        previousValue = defaultValue;
      }

      if (Equals(previousValue, value)) {
        // No-op
        return;
      }

      if (Equals(defaultValue, value)) {
        _values.Remove(key);
      } else {
        _values[key] = value;
      }
      OnValueChanged(new SettingValueChangedEventArgs(this, key, previousValue, value));
      Save();
    }

    public string GetValue(string key, string defaultValue) {
      string value;
      if (_values.TryGetValue(key, out value)) {
        return value;
      }
      return defaultValue;
    }

    private static void CheckValidValue(string value) {
      if (value.IndexOf('\n') >= 0) {
        throw new ArgumentException(@"User setting cannot contain newline characters", value);
      }
    }

    private static void CheckValidKey(string key) {
      if (string.IsNullOrEmpty(key)) {
        throw new ArgumentNullException(key);
      }

      foreach (var c in key) {
        if (char.IsLetter(c))
          continue;

        if (c == '.')
          continue;

        throw new ArgumentException(string.Format("Key \"{0}\" contains invalid characters", key), "key");
      }
    }

    private void ProcessLine(string line) {
      var separator = line.IndexOf('=');
      if (separator < 0 || separator == line.Length - 1) {
        return;
      }
      var key = line.Substring(0, separator).Trim();
      var value = line.Substring(separator + 1).Trim();
      if (key == "" || value == "") {
        return;
      }

      _values[key] = value;
    }

    private void Wrap(string message, Action action) {
      try {
        action();
      } catch (Exception e) {
        SignalError(message, e);
      }
    }

    private void SignalError(string message, Exception error) {
      try {
        throw new ApplicationException(message, error);
      } catch (Exception e) {
        OnError(new ErrorEventArgs(e));
      }
    }

    private string GetFilePath() {
      // ApplicationData is the roaming local application data
      // https://goo.gl/k0Ak0y
      //  Roaming Data:
      //   Application settings (provided they make sense to roam)
      //   Small user files that must be present
      //  Non - Roaming Data:
      //   Cache files
      //   Machine specific configuration settings
      //   Anything that can be easily regenerated if missing
      //   Very large configuration data
      var applicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      if (string.IsNullOrEmpty(applicationData)) {
        throw new ApplicationException("Application data environment variable is not correctly configured");
      }

      var userSettingDirectory = Path.Combine(applicationData, _directoryName);
      if (!Directory.Exists(userSettingDirectory)) {
        Directory.CreateDirectory(userSettingDirectory);
      }

      return Path.Combine(userSettingDirectory, "settings.txt");
    }

    protected virtual void OnError(ErrorEventArgs e) {
      var handler = Error;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnLoaded() {
      var handler = Loaded;
      if (handler != null) handler(this, EventArgs.Empty);
    }

    protected virtual void OnSaving() {
      var handler = Saving;
      if (handler != null) handler(this, EventArgs.Empty);
    }

    protected virtual void OnValueChanged(SettingValueChangedEventArgs e) {
      var handler = ValueChanged;
      if (handler != null) handler(this, e);
    }
  }
}
