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

using System.Windows.Forms;

namespace AccessBridgeExplorer.Utils {
  public class WindowsHotKeyHandlerFactory {
    private readonly IWin32Window _owner;

    public WindowsHotKeyHandlerFactory(IWin32Window owner) {
      _owner = owner;
    }

    /// <param name="id">The identifier of the hot key. If a hot key already
    /// exists with the same control and id parameters, see Remarks for the
    /// action taken. An application must specify an id value in the range
    /// 0x0000 through 0xBFFF. A shared DLL must specify a value in the range
    /// 0xC000 through 0xFFFF (the range returned by the GlobalAddAtom
    /// function). To avoid conflicts with hot-key identifiers defined by other
    /// shared DLLs, a DLL should use the GlobalAddAtom function to obtain the
    /// hot-key identifier.</param>
    /// <param name="key"></param>
    public IWindowsHotKeyHandler CreateHandler(int id, Keys key) {
      return new WindowsHotKeyHandler(_owner, id, key);
    }
  }
}