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

namespace AccessBridgeExplorer.Utils.Settings {
  public static class UserSettingsExtensions {
    public static void SetIntValue(this IUserSettings userSettings, string key, int defaultValue, int value) {
      userSettings.SetValue(key, defaultValue.ToString(), value.ToString());
    }

    public static void SetBoolValue(this IUserSettings userSettings, string key, bool defaultValue, bool value) {
      userSettings.SetValue(key, defaultValue ? "true" : "false", value ? "true" : "false");
    }

    public static int GetIntValue(this IUserSettings userSettings, string key, int defaultValue) {
      var value = userSettings.GetValue(key, null);
      if (value == null) {
        return defaultValue;
      }
      return ConvertIntValue(value, defaultValue);
    }

    public static int ConvertIntValue(string value, int defaultValue) {
      int result;
      if (!int.TryParse(value, out result)) {
        return defaultValue;
      }
      return result;
    }

    public static bool GetBoolValue(this IUserSettings userSettings, string key, bool defaultValue) {
      var value = userSettings.GetValue(key, null);
      if (value == null) {
        return defaultValue;
      }

      return ConvertBoolValue(value, defaultValue);
    }

    public static bool ConvertBoolValue(string value, bool defaultValue) {
      return value == "true" ? true : value == "false" ? false : defaultValue;
    }
  }
}