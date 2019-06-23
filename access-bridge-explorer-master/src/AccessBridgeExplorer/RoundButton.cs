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

using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AccessBridgeExplorer {
  public class RoundButton : Button {
    protected override void OnPaint(PaintEventArgs e) {
      var grPath = new GraphicsPath();
      grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
      Region = new System.Drawing.Region(grPath);
      base.OnPaint(e);
    }
  }
}
