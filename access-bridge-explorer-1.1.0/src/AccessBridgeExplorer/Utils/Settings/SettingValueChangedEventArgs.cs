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

namespace AccessBridgeExplorer.Utils.Settings {
  public class SettingValueChangedEventArgs : EventArgs {
    private readonly IUserSettings _userSettings;
    private readonly string _key;
    private readonly string _previousValue;
    private readonly string _newValue;

    public SettingValueChangedEventArgs(IUserSettings userSettings, string key, string previousValue, string newValue) {
      _userSettings = userSettings;
      _key = key;
      _previousValue = previousValue;
      _newValue = newValue;
    }

    public IUserSettings UserSettings {
      get { return _userSettings; }
    }

    public string Key {
      get { return _key; }
    }

    public string PreviousValue {
      get { return _previousValue; }
    }

    public string NewValue {
      get { return _newValue; }
    }
  }
}