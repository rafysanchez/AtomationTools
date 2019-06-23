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

using System.Runtime.InteropServices;
using System.Windows.Forms;
using AccessBridgeExplorer.Utils;

namespace AccessBridgeExplorer {
  public partial class OverlayWindow : Form {
    public OverlayWindow() {
      InitializeComponent();
      AllowTransparency = true;
      Opacity = 0.5;
    }

    protected override CreateParams CreateParams {
      get {
        var result = base.CreateParams;
        result.ExStyle |= (int)User32Utils.WindowStylesEx.WS_EX_TOOLWINDOW;
        result.ExStyle |= (int)User32Utils.WindowStylesEx.WS_EX_TRANSPARENT;
        result.ExStyle |= (int)User32Utils.WindowStylesEx.WS_EX_NOACTIVATE;
        result.ExStyle |= (int)User32Utils.WindowStylesEx.WS_EX_LAYERED;
        return result;
      }
    }

    protected override void CreateHandle() {
      base.CreateHandle();
      // Note: We need this because the Form.TopMost property does not respect
      // the "ShowWithoutActivation" flag, meaning the window will steal the
      // focus every time it is made visible.
      User32Utils.SetTopMost(new HandleRef(this, Handle), true);
    }

    protected override bool ShowWithoutActivation {
      get { return true; }
    }
  }
}
