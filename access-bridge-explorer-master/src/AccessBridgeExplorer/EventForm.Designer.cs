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
  partial class EventForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
      this.topSplitContainer = new System.Windows.Forms.SplitContainer();
      this.topLevelTabControl = new System.Windows.Forms.TabControl();
      this.accessibleContextTabPage = new System.Windows.Forms.TabPage();
      this.accessibleContextPropertyList = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.oldNewTabControl = new System.Windows.Forms.TabControl();
      this.oldValuePage = new System.Windows.Forms.TabPage();
      this.oldValuePropertyList = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.newValuePage = new System.Windows.Forms.TabPage();
      this.newValuePropertyList = new System.Windows.Forms.ListView();
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.closeButton = new System.Windows.Forms.Button();
      this.propertyImageList = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.topSplitContainer)).BeginInit();
      this.topSplitContainer.Panel1.SuspendLayout();
      this.topSplitContainer.Panel2.SuspendLayout();
      this.topSplitContainer.SuspendLayout();
      this.topLevelTabControl.SuspendLayout();
      this.accessibleContextTabPage.SuspendLayout();
      this.oldNewTabControl.SuspendLayout();
      this.oldValuePage.SuspendLayout();
      this.newValuePage.SuspendLayout();
      this.SuspendLayout();
      // 
      // topSplitContainer
      // 
      this.topSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.topSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.topSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.topSplitContainer.Name = "topSplitContainer";
      // 
      // topSplitContainer.Panel1
      // 
      this.topSplitContainer.Panel1.Controls.Add(this.topLevelTabControl);
      // 
      // topSplitContainer.Panel2
      // 
      this.topSplitContainer.Panel2.Controls.Add(this.oldNewTabControl);
      this.topSplitContainer.Size = new System.Drawing.Size(1008, 669);
      this.topSplitContainer.SplitterDistance = 497;
      this.topSplitContainer.TabIndex = 2;
      // 
      // topLevelTabControl
      // 
      this.topLevelTabControl.Controls.Add(this.accessibleContextTabPage);
      this.topLevelTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.topLevelTabControl.Location = new System.Drawing.Point(0, 0);
      this.topLevelTabControl.Name = "topLevelTabControl";
      this.topLevelTabControl.SelectedIndex = 0;
      this.topLevelTabControl.Size = new System.Drawing.Size(497, 669);
      this.topLevelTabControl.TabIndex = 0;
      // 
      // accessibleContextTabPage
      // 
      this.accessibleContextTabPage.Controls.Add(this.accessibleContextPropertyList);
      this.accessibleContextTabPage.Location = new System.Drawing.Point(4, 24);
      this.accessibleContextTabPage.Name = "accessibleContextTabPage";
      this.accessibleContextTabPage.Size = new System.Drawing.Size(489, 641);
      this.accessibleContextTabPage.TabIndex = 3;
      this.accessibleContextTabPage.Text = "Component Properties";
      this.accessibleContextTabPage.UseVisualStyleBackColor = true;
      // 
      // accessibleContextPropertyList
      // 
      this.accessibleContextPropertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.accessibleContextPropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.accessibleContextPropertyList.FullRowSelect = true;
      this.accessibleContextPropertyList.GridLines = true;
      this.accessibleContextPropertyList.Location = new System.Drawing.Point(0, 0);
      this.accessibleContextPropertyList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.accessibleContextPropertyList.Name = "accessibleContextPropertyList";
      this.accessibleContextPropertyList.Size = new System.Drawing.Size(489, 641);
      this.accessibleContextPropertyList.TabIndex = 0;
      this.accessibleContextPropertyList.UseCompatibleStateImageBehavior = false;
      this.accessibleContextPropertyList.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Property";
      this.columnHeader1.Width = 200;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Value";
      this.columnHeader2.Width = 300;
      // 
      // oldNewTabControl
      // 
      this.oldNewTabControl.Controls.Add(this.oldValuePage);
      this.oldNewTabControl.Controls.Add(this.newValuePage);
      this.oldNewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.oldNewTabControl.Location = new System.Drawing.Point(0, 0);
      this.oldNewTabControl.Name = "oldNewTabControl";
      this.oldNewTabControl.SelectedIndex = 0;
      this.oldNewTabControl.Size = new System.Drawing.Size(507, 669);
      this.oldNewTabControl.TabIndex = 0;
      // 
      // oldValuePage
      // 
      this.oldValuePage.Controls.Add(this.oldValuePropertyList);
      this.oldValuePage.Location = new System.Drawing.Point(4, 24);
      this.oldValuePage.Name = "oldValuePage";
      this.oldValuePage.Size = new System.Drawing.Size(499, 641);
      this.oldValuePage.TabIndex = 5;
      this.oldValuePage.Text = "Old Value";
      this.oldValuePage.UseVisualStyleBackColor = true;
      // 
      // oldValuePropertyList
      // 
      this.oldValuePropertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
      this.oldValuePropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.oldValuePropertyList.FullRowSelect = true;
      this.oldValuePropertyList.GridLines = true;
      this.oldValuePropertyList.Location = new System.Drawing.Point(0, 0);
      this.oldValuePropertyList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.oldValuePropertyList.Name = "oldValuePropertyList";
      this.oldValuePropertyList.Size = new System.Drawing.Size(499, 641);
      this.oldValuePropertyList.TabIndex = 0;
      this.oldValuePropertyList.UseCompatibleStateImageBehavior = false;
      this.oldValuePropertyList.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Property";
      this.columnHeader3.Width = 200;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Value";
      this.columnHeader4.Width = 300;
      // 
      // newValuePage
      // 
      this.newValuePage.Controls.Add(this.newValuePropertyList);
      this.newValuePage.Location = new System.Drawing.Point(4, 24);
      this.newValuePage.Name = "newValuePage";
      this.newValuePage.Size = new System.Drawing.Size(632, 631);
      this.newValuePage.TabIndex = 2;
      this.newValuePage.Text = "New Value";
      this.newValuePage.UseVisualStyleBackColor = true;
      // 
      // newValuePropertyList
      // 
      this.newValuePropertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
      this.newValuePropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.newValuePropertyList.FullRowSelect = true;
      this.newValuePropertyList.GridLines = true;
      this.newValuePropertyList.Location = new System.Drawing.Point(0, 0);
      this.newValuePropertyList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.newValuePropertyList.Name = "newValuePropertyList";
      this.newValuePropertyList.Size = new System.Drawing.Size(632, 631);
      this.newValuePropertyList.TabIndex = 1;
      this.newValuePropertyList.UseCompatibleStateImageBehavior = false;
      this.newValuePropertyList.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "Property";
      this.columnHeader5.Width = 200;
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "Value";
      this.columnHeader6.Width = 300;
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(910, 687);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(86, 34);
      this.closeButton.TabIndex = 0;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      // 
      // propertyImageList
      // 
      this.propertyImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("propertyImageList.ImageStream")));
      this.propertyImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.propertyImageList.Images.SetKeyName(0, "Plus.png");
      this.propertyImageList.Images.SetKeyName(1, "Minus.png");
      // 
      // EventForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1008, 733);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.topSplitContainer);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "EventForm";
      this.ShowInTaskbar = false;
      this.Text = "Event Viewer";
      this.topSplitContainer.Panel1.ResumeLayout(false);
      this.topSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.topSplitContainer)).EndInit();
      this.topSplitContainer.ResumeLayout(false);
      this.topLevelTabControl.ResumeLayout(false);
      this.accessibleContextTabPage.ResumeLayout(false);
      this.oldNewTabControl.ResumeLayout(false);
      this.oldValuePage.ResumeLayout(false);
      this.newValuePage.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer topSplitContainer;
    private System.Windows.Forms.TabControl topLevelTabControl;
    private System.Windows.Forms.TabPage accessibleContextTabPage;
    private System.Windows.Forms.ListView accessibleContextPropertyList;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.TabControl oldNewTabControl;
    private System.Windows.Forms.TabPage oldValuePage;
    private System.Windows.Forms.ListView oldValuePropertyList;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.TabPage newValuePage;
    private System.Windows.Forms.ListView newValuePropertyList;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ColumnHeader columnHeader6;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.ImageList propertyImageList;
  }
}

