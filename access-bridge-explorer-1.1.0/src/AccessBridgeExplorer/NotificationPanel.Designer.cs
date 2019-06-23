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

namespace AccessBridgeExplorer {
  partial class NotificationPanel {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.textBox = new System.Windows.Forms.RichTextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.closeButton = new AccessBridgeExplorer.RoundButton();
      this.dismissTimer = new System.Windows.Forms.Timer(this.components);
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // textBox
      // 
      this.textBox.AccessibleName = "Notification Text";
      this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox.BackColor = System.Drawing.SystemColors.Window;
      this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox.Location = new System.Drawing.Point(20, 4);
      this.textBox.Margin = new System.Windows.Forms.Padding(0);
      this.textBox.Name = "textBox";
      this.textBox.ReadOnly = true;
      this.textBox.Size = new System.Drawing.Size(449, 104);
      this.textBox.TabIndex = 0;
      this.textBox.Text = "";
      this.textBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textBox_LinkClicked);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Controls.Add(this.closeButton);
      this.panel1.Controls.Add(this.textBox);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(4);
      this.panel1.Size = new System.Drawing.Size(486, 112);
      this.panel1.TabIndex = 2;
      // 
      // pictureBox1
      // 
      this.pictureBox1.AccessibleName = "Icon";
      this.pictureBox1.Image = global::AccessBridgeExplorer.Properties.Resources.InfoIcon;
      this.pictureBox1.Location = new System.Drawing.Point(4, 4);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(16, 16);
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // closeButton
      // 
      this.closeButton.AccessibleName = "Close";
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
      this.closeButton.FlatAppearance.BorderSize = 0;
      this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.closeButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
      this.closeButton.Image = global::AccessBridgeExplorer.Properties.Resources.SmallCloseButton;
      this.closeButton.Location = new System.Drawing.Point(469, 0);
      this.closeButton.Margin = new System.Windows.Forms.Padding(0);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(16, 16);
      this.closeButton.TabIndex = 3;
      this.closeButton.UseVisualStyleBackColor = false;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // dismissTimer
      // 
      this.dismissTimer.Enabled = true;
      this.dismissTimer.Interval = 200;
      this.dismissTimer.Tick += new System.EventHandler(this.dismissTimer_Tick);
      // 
      // NotificationPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Controls.Add(this.panel1);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.MinimumSize = new System.Drawing.Size(100, 20);
      this.Name = "NotificationPanel";
      this.Size = new System.Drawing.Size(486, 112);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox textBox;
    private System.Windows.Forms.Panel panel1;
    private RoundButton closeButton;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Timer dismissTimer;
  }
}
