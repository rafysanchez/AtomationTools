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
  public class UserSettingImpl<T> : UserSettingBase<T> {
    private readonly Func<string, T, T> _getter;
    private readonly Action<string, T, T> _setter;
    private readonly Func<string, T> _stringConverter;
    private readonly string _key;
    private readonly T _defaultValue;

    public UserSettingImpl(IUserSettings userSettings, string key, T defaultValue,
      Func<string, T, T> getter,
      Action<string, T, T> setter,
      Func<string, T> stringConverter) :
      base(userSettings) {
      _getter = getter;
      _setter = setter;
      _stringConverter = stringConverter;
      _key = key;
      _defaultValue = defaultValue;
    }

    public override T ConvertString(string value) {
      return _stringConverter(value);
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
  }
}