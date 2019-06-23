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
using System.Linq;
using System.Reflection;

namespace AccessBridgeExplorer.Utils.Settings {
  public class EnumUserSetting<T> : UserSettingBase<T> {
    private readonly string _key;
    private readonly T _defaultValue;
    private readonly Func<string, T, T> _getter;
    private readonly Action<string, T, T> _setter;

    public EnumUserSetting(IUserSettings userSettings, string key, T defaultValue) : base(userSettings) {
      if (!typeof(T).IsEnum) {
        throw new ArgumentException("Type must be an enum type");
      }
      _key = key;
      _defaultValue = defaultValue;
      _getter = (k, d) => FromStringValue(UserSettings.GetValue(k, ""));
      _setter = (k, d, v) => UserSettings.SetValue(k, ToStringValue(d), ToStringValue(v));
    }

    public override T ConvertString(string value) {
      return FromStringValue(value);
    }

    public override Func<string, T, T> Getter {
      get { return _getter; }
    }

    public override Action<string, T, T> Setter {
      get { return _setter; }
    }

    public override string Key {
      get { return _key; }
    }

    public override T DefaultValue {
      get { return _defaultValue; }
    }

    private IEnumerable<KeyValuePair<T, string>> GetEnumValues() {
      return typeof (T)
        .GetFields(BindingFlags.Static | BindingFlags.Public)
        .Select(x => new KeyValuePair<T, string>((T)x.GetValue(null), x.Name));
    }

    private T FromStringValue(string value) {
      var enumValue = GetEnumValues().Where(x => x.Value == value).Select(x => x.Key).ToList();
      if (enumValue.Any())
        return enumValue.First();
      return DefaultValue;
    }

    private string ToStringValue(T value) {
      var enumValue = GetEnumValues().Where(x => Equals(x.Key, value)).Select(x => x.Value).ToList();
      if (enumValue.Any())
        return enumValue.First();
      return "";
    }
  }
}