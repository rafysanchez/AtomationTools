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
using System.IO;

namespace AccessBridgeExplorer.Utils.Settings {
  /// <summary>
  /// Abstraction over a central dictionary of settings, with eventing model
  /// for load/save/changes.
  /// </summary>
  public interface IUserSettings {
    event EventHandler<ErrorEventArgs> Error;
    event EventHandler Loaded;
    event EventHandler Saving;
    event EventHandler<SettingValueChangedEventArgs> ValueChanged;

    string GetValue(string key, string defaultValue);
    void SetValue(string key, string defaultValue, string value);

    void Load();
    void Save();
    void Clear();
  }
}