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

namespace AccessBridgeExplorer {
  partial class ExceptionForm {
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
      this.closeButton = new System.Windows.Forms.Button();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.errorDetailListViewImageList = new System.Windows.Forms.ImageList(this.components);
      this.errorDetailListView = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(910, 517);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(86, 34);
      this.closeButton.TabIndex = 0;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Text";
      this.columnHeader1.Width = 400;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Location";
      this.columnHeader2.Width = 200;
      // 
      // errorDetailListViewImageList
      // 
      this.errorDetailListViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("errorDetailListViewImageList.ImageStream")));
      this.errorDetailListViewImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.errorDetailListViewImageList.Images.SetKeyName(0, "Plus.png");
      this.errorDetailListViewImageList.Images.SetKeyName(1, "Minus.png");
      // 
      // errorDetailListView
      // 
      this.errorDetailListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.errorDetailListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
      this.errorDetailListView.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.errorDetailListView.FullRowSelect = true;
      this.errorDetailListView.Location = new System.Drawing.Point(8, 8);
      this.errorDetailListView.Name = "errorDetailListView";
      this.errorDetailListView.Size = new System.Drawing.Size(1000, 483);
      this.errorDetailListView.TabIndex = 1;
      this.errorDetailListView.UseCompatibleStateImageBehavior = false;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Error details";
      this.columnHeader3.Width = -1;
      // 
      // ExceptionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(1008, 563);
      this.Controls.Add(this.errorDetailListView);
      this.Controls.Add(this.closeButton);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "ExceptionForm";
      this.ShowInTaskbar = false;
      this.Text = "Error";
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ImageList errorDetailListViewImageList;
    private System.Windows.Forms.ListView errorDetailListView;
    private System.Windows.Forms.ColumnHeader columnHeader3;
  }
}

