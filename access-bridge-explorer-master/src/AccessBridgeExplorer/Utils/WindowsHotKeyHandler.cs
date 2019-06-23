// Copyright 2015 Google Inc. All Rights Reserved.
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AccessBridgeExplorer.Utils {
  public class WindowsHotKeyHandler : IWindowsHotKeyHandler, IMessageFilter {
    private readonly IWin32Window _control;
    private readonly int _id;
    private readonly Keys _keys;
    private bool _isActive;

    // ReSharper disable once InconsistentNaming
    private const uint WM_HOTKEY = 0x312;

    public WindowsHotKeyHandler(IWin32Window owner, int id, Keys keys) {
      _control = owner;
      _id = id;
      _keys = keys;
    }

    public event EventHandler KeyPressed;

    public bool IsRegistered {
      get { return _isActive; }
      set {
        if (value) {
          Register();
        } else {
          Unregister();
        }
      }
    }

    public void Dispose() {
      Unregister();
    }

    private void Register() {
      if (_isActive)
        return;

      Application.AddMessageFilter(this);
      try {
        var modifiers = default(Modifiers);
        if ((_keys & Keys.Shift) != 0) modifiers |= Modifiers.MOD_SHIFT;
        if ((_keys & Keys.Control) != 0) modifiers |= Modifiers.MOD_CONTROL;
        if ((_keys & Keys.Alt) != 0) modifiers |= Modifiers.MOD_ALT;
        //if ((key & Keys.Win) != 0) modifiers |= Modifiers.MOD_WIN;

        // Register the hotkey
        if (RegisterHotKey(_control.Handle, _id, (uint)modifiers, _keys & Keys.KeyCode) == 0) {
          ThrowLastWin32Error("Error registering global hotkey");
        }
        _isActive = true;
      } catch {
        Application.RemoveMessageFilter(this);
        throw;
      }
    }

    private void Unregister() {
      if (!_isActive)
        return;

      if (UnregisterHotKey(_control.Handle, _id) == 0) {
        ThrowLastWin32Error("Error unregistering global hotkey");
      }
      _isActive = false;

      Application.RemoveMessageFilter(this);
    }

    private static void ThrowLastWin32Error(string message) {
      // ReSharper disable once InconsistentNaming
      const int E_FAIL = (unchecked((int)0x80004005));
      try {
        var hr = Marshal.GetHRForLastWin32Error();
        if (hr >= 0)
          hr = E_FAIL;
        Marshal.ThrowExceptionForHR(hr);
      } catch (Exception e) {
        throw new ApplicationException(message, e);
      }
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int UnregisterHotKey(IntPtr hWnd, int id);

    protected virtual void OnKeyPressed() {
      var handler = KeyPressed;
      if (handler != null) handler(this, EventArgs.Empty);
    }

    public bool PreFilterMessage(ref Message m) {
      // Only process WM_HOTKEY
      if (m.Msg != WM_HOTKEY)
        return false;

      // Only process our "id".
      var id = m.WParam.ToInt32();
      if (_control == null || _id != id)
        return false;

      OnKeyPressed();
      // TODO: Never eat the keystroke?
      return false;
    }

    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum Modifiers : uint {
      MOD_ALT = 0x1,
      MOD_CONTROL = 0x2,
      MOD_SHIFT = 0x4,
      MOD_WIN = 0x8,
    }
  }
}
