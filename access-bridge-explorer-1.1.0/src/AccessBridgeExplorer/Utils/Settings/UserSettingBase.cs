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
  public abstract class UserSettingBase<T> : UserSetting<T> {
    private readonly IUserSettings _userSettings;

    protected UserSettingBase(IUserSettings userSettings) {
      _userSettings = userSettings;
      _userSettings.Loaded += (sender, args) => {
        OnLoaded();
        OnSync(new SyncEventArgs<T>(this, Value));
      };
      _userSettings.ValueChanged += (sender, args) => {
        if (Equals(Key, args.Key)) {
          OnChanged(new ChangedEventArgs<T>(this, ConvertString(args.PreviousValue), ConvertString(args.NewValue)));
          OnSync(new SyncEventArgs<T>(this, Value));
        }
      };
    }

    public override event EventHandler<SyncEventArgs<T>> Sync;
    public override event EventHandler Loaded;
    public override event EventHandler<ChangedEventArgs<T>> Changed;

    public IUserSettings UserSettings {
      get { return _userSettings; }
    }

    public abstract T DefaultValue { get; }

    public abstract T ConvertString(string value);

    public abstract Func<string, T, T> Getter { get; }

    public abstract Action<string, T, T> Setter { get; }

    public override T Value {
      get { return Getter(Key, DefaultValue); }
      set { Setter(Key, DefaultValue, value); }
    }

    protected virtual void OnChanged(ChangedEventArgs<T> e) {
      var handler = Changed;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnSync(SyncEventArgs<T> e) {
      var handler = Sync;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnLoaded() {
      var handler = Loaded;
      if (handler != null) handler(this, EventArgs.Empty);
    }
  }
}