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
  partial class ExplorerForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
      this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
      this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.navigateForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.navigateBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.separator1 = new System.Windows.Forms.ToolStripSeparator();
      this.showNotificationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
      this._propertiesMenu = new System.Windows.Forms.ToolStripMenuItem();
      this._eventsMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.componentOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enableOverlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.activateOverlayOnTreeSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.activateOverlayOnComponentSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.activateOverlayOnFocusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.activateOverlayOnActiveDescendantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.showTooltipAndOverlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showOverlayOnlyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showTooltipOnlyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
      this.synchronizeTreeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
      this.enableCaptureHookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enableOverlayHookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
      this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this._limitCollectionsCountMenu = new System.Windows.Forms.ToolStripMenuItem();
      this._limitTextLineCountsMenu = new System.Windows.Forms.ToolStripMenuItem();
      this._limitTextLineLengthsMenu = new System.Windows.Forms.ToolStripMenuItem();
      this._limitTextBufferLengthMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.separator5 = new System.Windows.Forms.ToolStripSeparator();
      this.autoReleaseInactiveObjectsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.autoDetectApplicationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      this.resetAllOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.viewHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.checkForUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.automaticallyCheckForUpdatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this._enableOverlayButton = new System.Windows.Forms.ToolStripButton();
      this.statusBarStrip = new System.Windows.Forms.StatusStrip();
      this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.javaObjectsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.memoryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.garbageCollectButton = new System.Windows.Forms.ToolStripDropDownButton();
      this.mainToolStrip = new System.Windows.Forms.ToolStrip();
      this.navigateBackwardButton = new System.Windows.Forms.ToolStripSplitButton();
      this.navigateForwardButton = new System.Windows.Forms.ToolStripSplitButton();
      this.separator4 = new System.Windows.Forms.ToolStripSeparator();
      this._refreshButton = new System.Windows.Forms.ToolStripButton();
      this._findComponentButton = new System.Windows.Forms.ToolStripButton();
      this.separator2 = new System.Windows.Forms.ToolStripSeparator();
      this.separator3 = new System.Windows.Forms.ToolStripSeparator();
      this.showHelpButton = new System.Windows.Forms.ToolStripButton();
      this._initialTreeRefreshTimer = new System.Windows.Forms.Timer(this.components);
      this.topSplitContainer = new System.Windows.Forms.SplitContainer();
      this._topLevelTabControl = new System.Windows.Forms.TabControl();
      this._accessibilityTreePage = new System.Windows.Forms.TabPage();
      this._accessibilityTree = new System.Windows.Forms.TreeView();
      this._accessibleComponentTabControl = new System.Windows.Forms.TabControl();
      this.accessibleComponentTabPage = new System.Windows.Forms.TabPage();
      this._accessibleContextPropertyList = new System.Windows.Forms.ListView();
      this.propertyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.valueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this._propertyImageList = new System.Windows.Forms.ImageList(this.components);
      this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
      this._bottomTabControl = new System.Windows.Forms.TabControl();
      this._messageListPage = new System.Windows.Forms.TabPage();
      this._messageList = new System.Windows.Forms.ListView();
      this.messageIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.messageTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.messageTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.messagesToolStrip = new System.Windows.Forms.ToolStrip();
      this.clearMessagesButton = new System.Windows.Forms.ToolStripButton();
      this._eventListPage = new System.Windows.Forms.TabPage();
      this._eventList = new System.Windows.Forms.ListView();
      this.eventId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventJvmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventOldValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventNewValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.eventsToolStrip = new System.Windows.Forms.ToolStrip();
      this.clearEventsButton = new System.Windows.Forms.ToolStripButton();
      this.memoryRefreshTimer = new System.Windows.Forms.Timer(this.components);
      this.notificationPanel = new AccessBridgeExplorer.NotificationPanel();
      this.updateChecker = new AccessBridgeExplorer.UpdateChecker(this.components);
      this.synchronizeTreeLogErrorsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
      this.mainMenuStrip.SuspendLayout();
      this.statusBarStrip.SuspendLayout();
      this.mainToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.topSplitContainer)).BeginInit();
      this.topSplitContainer.Panel1.SuspendLayout();
      this.topSplitContainer.Panel2.SuspendLayout();
      this.topSplitContainer.SuspendLayout();
      this._topLevelTabControl.SuspendLayout();
      this._accessibilityTreePage.SuspendLayout();
      this._accessibleComponentTabControl.SuspendLayout();
      this.accessibleComponentTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
      this.mainSplitContainer.Panel1.SuspendLayout();
      this.mainSplitContainer.Panel2.SuspendLayout();
      this.mainSplitContainer.SuspendLayout();
      this._bottomTabControl.SuspendLayout();
      this._messageListPage.SuspendLayout();
      this.messagesToolStrip.SuspendLayout();
      this._eventListPage.SuspendLayout();
      this.eventsToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenuStrip
      // 
      this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.optionsMenu,
            this.helpMenu});
      this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
      this.mainMenuStrip.Name = "mainMenuStrip";
      this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
      this.mainMenuStrip.Size = new System.Drawing.Size(1008, 24);
      this.mainMenuStrip.TabIndex = 0;
      this.mainMenuStrip.Text = "Main";
      // 
      // fileMenu
      // 
      this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
      this.fileMenu.Name = "fileMenu";
      this.fileMenu.Size = new System.Drawing.Size(37, 20);
      this.fileMenu.Text = "&File";
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.Name = "exitMenuItem";
      this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
      this.exitMenuItem.Size = new System.Drawing.Size(129, 22);
      this.exitMenuItem.Text = "E&xit";
      this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // viewMenu
      // 
      this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateForwardMenuItem,
            this.navigateBackwardMenuItem,
            this.separator1,
            this.showNotificationMenuItem,
            this.refreshMenuItem});
      this.viewMenu.Name = "viewMenu";
      this.viewMenu.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.viewMenu.Size = new System.Drawing.Size(44, 20);
      this.viewMenu.Text = "&View";
      // 
      // navigateForwardMenuItem
      // 
      this.navigateForwardMenuItem.Name = "navigateForwardMenuItem";
      this.navigateForwardMenuItem.ShortcutKeyDisplayString = "";
      this.navigateForwardMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
      this.navigateForwardMenuItem.Size = new System.Drawing.Size(225, 22);
      this.navigateForwardMenuItem.Text = "Navigate &Forward";
      this.navigateForwardMenuItem.Click += new System.EventHandler(this.navigateForwardToolStripMenuItem_Click);
      // 
      // navigateBackwardMenuItem
      // 
      this.navigateBackwardMenuItem.Name = "navigateBackwardMenuItem";
      this.navigateBackwardMenuItem.ShortcutKeyDisplayString = "";
      this.navigateBackwardMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
      this.navigateBackwardMenuItem.Size = new System.Drawing.Size(225, 22);
      this.navigateBackwardMenuItem.Text = "Navigate &Backward";
      this.navigateBackwardMenuItem.Click += new System.EventHandler(this.navigateBackwardToolStripMenuItem_Click);
      // 
      // separator1
      // 
      this.separator1.Name = "separator1";
      this.separator1.Size = new System.Drawing.Size(222, 6);
      // 
      // showNotificationMenuItem
      // 
      this.showNotificationMenuItem.Name = "showNotificationMenuItem";
      this.showNotificationMenuItem.Size = new System.Drawing.Size(225, 22);
      this.showNotificationMenuItem.Text = "&Last notification";
      this.showNotificationMenuItem.Click += new System.EventHandler(this.showNotificationMenuItem_Click);
      // 
      // refreshMenuItem
      // 
      this.refreshMenuItem.Name = "refreshMenuItem";
      this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.refreshMenuItem.Size = new System.Drawing.Size(225, 22);
      this.refreshMenuItem.Text = "&Refresh";
      this.refreshMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
      // 
      // optionsMenu
      // 
      this.optionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._propertiesMenu,
            this._eventsMenu,
            this.componentOverlayToolStripMenuItem,
            this.toolStripMenuItem6,
            this.advancedToolStripMenuItem,
            this.toolStripMenuItem5,
            this.resetAllOptionsMenuItem});
      this.optionsMenu.Name = "optionsMenu";
      this.optionsMenu.Size = new System.Drawing.Size(61, 20);
      this.optionsMenu.Text = "&Options";
      // 
      // _propertiesMenu
      // 
      this._propertiesMenu.Name = "_propertiesMenu";
      this._propertiesMenu.Size = new System.Drawing.Size(226, 22);
      this._propertiesMenu.Text = "Display Accessible &Properties";
      this._propertiesMenu.ToolTipText = "Properties to show in Component Properties";
      // 
      // _eventsMenu
      // 
      this._eventsMenu.Name = "_eventsMenu";
      this._eventsMenu.Size = new System.Drawing.Size(226, 22);
      this._eventsMenu.Text = "Capture Accessibility &Events";
      this._eventsMenu.ToolTipText = "Events to capture and display in the events window";
      // 
      // componentOverlayToolStripMenuItem
      // 
      this.componentOverlayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableOverlayMenuItem,
            this.toolStripMenuItem4,
            this.activateOverlayOnTreeSelectionMenuItem,
            this.activateOverlayOnComponentSelectionMenuItem,
            this.activateOverlayOnFocusMenuItem,
            this.activateOverlayOnActiveDescendantMenuItem,
            this.toolStripMenuItem3,
            this.showTooltipAndOverlayMenuItem,
            this.showOverlayOnlyMenuItem,
            this.showTooltipOnlyMenuItem,
            this.toolStripMenuItem7,
            this.synchronizeTreeMenuItem,
            this.toolStripMenuItem8,
            this.enableCaptureHookMenuItem,
            this.enableOverlayHookMenuItem});
      this.componentOverlayToolStripMenuItem.Name = "componentOverlayToolStripMenuItem";
      this.componentOverlayToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
      this.componentOverlayToolStripMenuItem.Text = "Component Overlay";
      // 
      // enableOverlayMenuItem
      // 
      this.enableOverlayMenuItem.CheckOnClick = true;
      this.enableOverlayMenuItem.Name = "enableOverlayMenuItem";
      this.enableOverlayMenuItem.Size = new System.Drawing.Size(275, 22);
      this.enableOverlayMenuItem.Text = "Enable";
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(272, 6);
      // 
      // activateOverlayOnTreeSelectionMenuItem
      // 
      this.activateOverlayOnTreeSelectionMenuItem.Name = "activateOverlayOnTreeSelectionMenuItem";
      this.activateOverlayOnTreeSelectionMenuItem.Size = new System.Drawing.Size(275, 22);
      this.activateOverlayOnTreeSelectionMenuItem.Text = "Activate on &Accessbility Tree selection";
      this.activateOverlayOnTreeSelectionMenuItem.ToolTipText = "Show the Overlay window when a component is selected in the Accessibility Tree";
      this.activateOverlayOnTreeSelectionMenuItem.Click += new System.EventHandler(this.activateOverlayOnTreeSelectionMenuItem_Click);
      // 
      // activateOverlayOnComponentSelectionMenuItem
      // 
      this.activateOverlayOnComponentSelectionMenuItem.Name = "activateOverlayOnComponentSelectionMenuItem";
      this.activateOverlayOnComponentSelectionMenuItem.Size = new System.Drawing.Size(275, 22);
      this.activateOverlayOnComponentSelectionMenuItem.Text = "Activate on &Component selection";
      this.activateOverlayOnComponentSelectionMenuItem.ToolTipText = "Show the Overlay window when a component is selected in the Accessible Component " +
    "Properties panel";
      this.activateOverlayOnComponentSelectionMenuItem.Click += new System.EventHandler(this.activateOverlayOnComponentSelectionMenuItem_Click);
      // 
      // activateOverlayOnFocusMenuItem
      // 
      this.activateOverlayOnFocusMenuItem.Name = "activateOverlayOnFocusMenuItem";
      this.activateOverlayOnFocusMenuItem.Size = new System.Drawing.Size(275, 22);
      this.activateOverlayOnFocusMenuItem.Text = "Activate on &Focus events";
      this.activateOverlayOnFocusMenuItem.ToolTipText = "Show the Overlay window when focus gained events are received";
      this.activateOverlayOnFocusMenuItem.Click += new System.EventHandler(this.activateOverlayOnFocusMenuItem_Click);
      // 
      // activateOverlayOnActiveDescendantMenuItem
      // 
      this.activateOverlayOnActiveDescendantMenuItem.Name = "activateOverlayOnActiveDescendantMenuItem";
      this.activateOverlayOnActiveDescendantMenuItem.Size = new System.Drawing.Size(275, 22);
      this.activateOverlayOnActiveDescendantMenuItem.Text = "Activate on &Active Descendant events";
      this.activateOverlayOnActiveDescendantMenuItem.ToolTipText = "Show the Overlay window when focus gained events are received";
      this.activateOverlayOnActiveDescendantMenuItem.Click += new System.EventHandler(this.activateOverlayOnActiveDescendantMenuItem_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(272, 6);
      // 
      // showTooltipAndOverlayMenuItem
      // 
      this.showTooltipAndOverlayMenuItem.Name = "showTooltipAndOverlayMenuItem";
      this.showTooltipAndOverlayMenuItem.Size = new System.Drawing.Size(275, 22);
      this.showTooltipAndOverlayMenuItem.Text = "Show &Tooltip && Overlay";
      this.showTooltipAndOverlayMenuItem.ToolTipText = "Show the Tooltip window next to the Overlay window";
      this.showTooltipAndOverlayMenuItem.Click += new System.EventHandler(this.showTooltipAndOverlayMenuItem_Click);
      // 
      // showOverlayOnlyMenuItem
      // 
      this.showOverlayOnlyMenuItem.Name = "showOverlayOnlyMenuItem";
      this.showOverlayOnlyMenuItem.Size = new System.Drawing.Size(275, 22);
      this.showOverlayOnlyMenuItem.Text = "Show &Overlay only";
      this.showOverlayOnlyMenuItem.ToolTipText = "Show the Tooltip window next to the Overlay window";
      this.showOverlayOnlyMenuItem.Click += new System.EventHandler(this.showOverlayOnlyMenuItem_Click);
      // 
      // showTooltipOnlyMenuItem
      // 
      this.showTooltipOnlyMenuItem.Name = "showTooltipOnlyMenuItem";
      this.showTooltipOnlyMenuItem.Size = new System.Drawing.Size(275, 22);
      this.showTooltipOnlyMenuItem.Text = "Show &Tooltip only";
      this.showTooltipOnlyMenuItem.ToolTipText = "Show the Tooltip window next to the Overlay window";
      this.showTooltipOnlyMenuItem.Click += new System.EventHandler(this.showTooltipOnlyMenuItem_Click);
      // 
      // toolStripMenuItem7
      // 
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new System.Drawing.Size(272, 6);
      // 
      // synchonizeTreeMenuItem
      // 
      this.synchronizeTreeMenuItem.Name = "synchronizeTreeMenuItem";
      this.synchronizeTreeMenuItem.Size = new System.Drawing.Size(275, 22);
      this.synchronizeTreeMenuItem.Text = "Synchonize Tree";
      // 
      // toolStripMenuItem8
      // 
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new System.Drawing.Size(272, 6);
      // 
      // enableCaptureHookMenuItem
      // 
      this.enableCaptureHookMenuItem.Name = "enableCaptureHookMenuItem";
      this.enableCaptureHookMenuItem.Size = new System.Drawing.Size(275, 22);
      this.enableCaptureHookMenuItem.Text = "Hook Ctrl-\\ to capture";
      // 
      // enableOverlayHookMenuItem
      // 
      this.enableOverlayHookMenuItem.Name = "enableOverlayHookMenuItem";
      this.enableOverlayHookMenuItem.Size = new System.Drawing.Size(275, 22);
      this.enableOverlayHookMenuItem.Text = "Hook Ctrl-Shift-\\  to toggle overlay";
      // 
      // toolStripMenuItem6
      // 
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new System.Drawing.Size(223, 6);
      // 
      // advancedToolStripMenuItem
      // 
      this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._limitCollectionsCountMenu,
            this._limitTextLineCountsMenu,
            this._limitTextLineLengthsMenu,
            this._limitTextBufferLengthMenu,
            this.separator5,
            this.autoReleaseInactiveObjectsMenuItem,
            this.autoDetectApplicationsMenuItem,
            this.toolStripMenuItem9,
            this.synchronizeTreeLogErrorsMenuItem});
      this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
      this.advancedToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
      this.advancedToolStripMenuItem.Text = "Advanced";
      // 
      // _limitCollectionsCountMenu
      // 
      this._limitCollectionsCountMenu.Name = "_limitCollectionsCountMenu";
      this._limitCollectionsCountMenu.Size = new System.Drawing.Size(250, 22);
      this._limitCollectionsCountMenu.Text = "Limit &collections to";
      // 
      // _limitTextLineCountsMenu
      // 
      this._limitTextLineCountsMenu.Name = "_limitTextLineCountsMenu";
      this._limitTextLineCountsMenu.Size = new System.Drawing.Size(250, 22);
      this._limitTextLineCountsMenu.Text = "Limit &text contents to";
      // 
      // _limitTextLineLengthsMenu
      // 
      this._limitTextLineLengthsMenu.Name = "_limitTextLineLengthsMenu";
      this._limitTextLineLengthsMenu.Size = new System.Drawing.Size(250, 22);
      this._limitTextLineLengthsMenu.Text = "Limit text &lines to";
      // 
      // _limitTextBufferLengthMenu
      // 
      this._limitTextBufferLengthMenu.Name = "_limitTextBufferLengthMenu";
      this._limitTextBufferLengthMenu.Size = new System.Drawing.Size(250, 22);
      this._limitTextBufferLengthMenu.Text = "Limit &names to";
      // 
      // separator5
      // 
      this.separator5.Name = "separator5";
      this.separator5.Size = new System.Drawing.Size(247, 6);
      // 
      // autoReleaseInactiveObjectsMenuItem
      // 
      this.autoReleaseInactiveObjectsMenuItem.Name = "autoReleaseInactiveObjectsMenuItem";
      this.autoReleaseInactiveObjectsMenuItem.Size = new System.Drawing.Size(250, 22);
      this.autoReleaseInactiveObjectsMenuItem.Text = "Auto-release inactive objects";
      // 
      // autoDetectApplicationsMenuItem
      // 
      this.autoDetectApplicationsMenuItem.Checked = true;
      this.autoDetectApplicationsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.autoDetectApplicationsMenuItem.Name = "autoDetectApplicationsMenuItem";
      this.autoDetectApplicationsMenuItem.Size = new System.Drawing.Size(250, 22);
      this.autoDetectApplicationsMenuItem.Text = "&Auto-detect running applications";
      this.autoDetectApplicationsMenuItem.ToolTipText = "Automatically refresh the Accessibility Tree when new applications are detected";
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new System.Drawing.Size(223, 6);
      // 
      // resetAllOptionsMenuItem
      // 
      this.resetAllOptionsMenuItem.Name = "resetAllOptionsMenuItem";
      this.resetAllOptionsMenuItem.Size = new System.Drawing.Size(226, 22);
      this.resetAllOptionsMenuItem.Text = "Reset all options";
      this.resetAllOptionsMenuItem.Click += new System.EventHandler(this.resetAllOptionsMenuItem_Click);
      // 
      // helpMenu
      // 
      this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpMenuItem,
            this.toolStripMenuItem1,
            this.checkForUpdateMenuItem,
            this.automaticallyCheckForUpdatesMenuItem,
            this.toolStripMenuItem2,
            this.aboutMenuItem});
      this.helpMenu.Name = "helpMenu";
      this.helpMenu.Size = new System.Drawing.Size(44, 20);
      this.helpMenu.Text = "&Help";
      // 
      // viewHelpMenuItem
      // 
      this.viewHelpMenuItem.Name = "viewHelpMenuItem";
      this.viewHelpMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
      this.viewHelpMenuItem.Size = new System.Drawing.Size(245, 22);
      this.viewHelpMenuItem.Text = "View &Help";
      this.viewHelpMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
      // 
      // checkForUpdateMenuItem
      // 
      this.checkForUpdateMenuItem.Name = "checkForUpdateMenuItem";
      this.checkForUpdateMenuItem.Size = new System.Drawing.Size(245, 22);
      this.checkForUpdateMenuItem.Text = "&Check for update";
      this.checkForUpdateMenuItem.Click += new System.EventHandler(this.checkForUpdateMenuItem_Click);
      // 
      // automaticallyCheckForUpdatesMenuItem
      // 
      this.automaticallyCheckForUpdatesMenuItem.Checked = true;
      this.automaticallyCheckForUpdatesMenuItem.CheckOnClick = true;
      this.automaticallyCheckForUpdatesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.automaticallyCheckForUpdatesMenuItem.Name = "automaticallyCheckForUpdatesMenuItem";
      this.automaticallyCheckForUpdatesMenuItem.Size = new System.Drawing.Size(245, 22);
      this.automaticallyCheckForUpdatesMenuItem.Text = "Automatically check for updates";
      this.automaticallyCheckForUpdatesMenuItem.CheckedChanged += new System.EventHandler(this.automaticallyCheckForUpdatesMenuItem_CheckedChanged);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(242, 6);
      // 
      // aboutMenuItem
      // 
      this.aboutMenuItem.Name = "aboutMenuItem";
      this.aboutMenuItem.Size = new System.Drawing.Size(245, 22);
      this.aboutMenuItem.Text = "&About";
      this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
      // 
      // _enableOverlayButton
      // 
      this._enableOverlayButton.BackColor = System.Drawing.SystemColors.ButtonFace;
      this._enableOverlayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this._enableOverlayButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this._enableOverlayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._enableOverlayButton.Name = "_enableOverlayButton";
      this._enableOverlayButton.Size = new System.Drawing.Size(23, 24);
      this._enableOverlayButton.Text = "Overlay";
      this._enableOverlayButton.ToolTipText = "Enable/Disable the accessibility window overlay";
      // 
      // statusBarStrip
      // 
      this.statusBarStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.statusBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel,
            this.javaObjectsStatusLabel,
            this.memoryStatusLabel,
            this.garbageCollectButton});
      this.statusBarStrip.Location = new System.Drawing.Point(0, 711);
      this.statusBarStrip.Name = "statusBarStrip";
      this.statusBarStrip.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
      this.statusBarStrip.Size = new System.Drawing.Size(1008, 22);
      this.statusBarStrip.TabIndex = 4;
      this.statusBarStrip.Text = "statusStrip1";
      // 
      // _statusLabel
      // 
      this._statusLabel.Name = "_statusLabel";
      this._statusLabel.Size = new System.Drawing.Size(804, 17);
      this._statusLabel.Spring = true;
      this._statusLabel.Text = "Ready.";
      this._statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // javaObjectsStatusLabel
      // 
      this.javaObjectsStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.javaObjectsStatusLabel.Name = "javaObjectsStatusLabel";
      this.javaObjectsStatusLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.javaObjectsStatusLabel.Size = new System.Drawing.Size(82, 17);
      this.javaObjectsStatusLabel.Text = "(placeholder)";
      this.javaObjectsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // memoryStatusLabel
      // 
      this.memoryStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.memoryStatusLabel.Name = "memoryStatusLabel";
      this.memoryStatusLabel.Size = new System.Drawing.Size(77, 17);
      this.memoryStatusLabel.Text = "(placeholder)";
      this.memoryStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // garbageCollectButton
      // 
      this.garbageCollectButton.BackColor = System.Drawing.SystemColors.Control;
      this.garbageCollectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.garbageCollectButton.Image = ((System.Drawing.Image)(resources.GetObject("garbageCollectButton.Image")));
      this.garbageCollectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.garbageCollectButton.Name = "garbageCollectButton";
      this.garbageCollectButton.ShowDropDownArrow = false;
      this.garbageCollectButton.Size = new System.Drawing.Size(27, 20);
      this.garbageCollectButton.Text = "GC";
      this.garbageCollectButton.Click += new System.EventHandler(this.garbageCollectButton_Click);
      // 
      // mainToolStrip
      // 
      this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateBackwardButton,
            this.navigateForwardButton,
            this.separator4,
            this._refreshButton,
            this._findComponentButton,
            this.separator2,
            this._enableOverlayButton,
            this.separator3,
            this.showHelpButton});
      this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
      this.mainToolStrip.Name = "mainToolStrip";
      this.mainToolStrip.Size = new System.Drawing.Size(1008, 27);
      this.mainToolStrip.TabIndex = 1;
      this.mainToolStrip.TabStop = true;
      this.mainToolStrip.Text = "Main";
      // 
      // navigateBackwardButton
      // 
      this.navigateBackwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.navigateBackwardButton.Image = ((System.Drawing.Image)(resources.GetObject("navigateBackwardButton.Image")));
      this.navigateBackwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.navigateBackwardButton.Name = "navigateBackwardButton";
      this.navigateBackwardButton.Size = new System.Drawing.Size(36, 24);
      this.navigateBackwardButton.Text = "Navigate Backward";
      this.navigateBackwardButton.ToolTipText = "Navigate Backward";
      this.navigateBackwardButton.ButtonClick += new System.EventHandler(this.navigateBackwardButton_Click);
      // 
      // navigateForwardButton
      // 
      this.navigateForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.navigateForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("navigateForwardButton.Image")));
      this.navigateForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.navigateForwardButton.Name = "navigateForwardButton";
      this.navigateForwardButton.Size = new System.Drawing.Size(36, 24);
      this.navigateForwardButton.Text = "Nagivate Forward";
      this.navigateForwardButton.ToolTipText = "Nagivate Forward";
      this.navigateForwardButton.ButtonClick += new System.EventHandler(this.navigateForwardButton_Click);
      // 
      // separator4
      // 
      this.separator4.Name = "separator4";
      this.separator4.Size = new System.Drawing.Size(6, 27);
      // 
      // _refreshButton
      // 
      this._refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("_refreshButton.Image")));
      this._refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._refreshButton.Name = "_refreshButton";
      this._refreshButton.Size = new System.Drawing.Size(24, 24);
      this._refreshButton.Text = "Refresh";
      this._refreshButton.ToolTipText = "Refresh the list of accessible windows";
      this._refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
      // 
      // _findComponentButton
      // 
      this._findComponentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this._findComponentButton.Image = global::AccessBridgeExplorer.Properties.Resources.Crosshair;
      this._findComponentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this._findComponentButton.Name = "_findComponentButton";
      this._findComponentButton.Size = new System.Drawing.Size(24, 24);
      this._findComponentButton.Text = "Find Component";
      this._findComponentButton.ToolTipText = "Find accessibility elements using the mouse pointer";
      this._findComponentButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.catpureButton_MouseDown);
      // 
      // separator2
      // 
      this.separator2.Name = "separator2";
      this.separator2.Size = new System.Drawing.Size(6, 27);
      // 
      // separator3
      // 
      this.separator3.Name = "separator3";
      this.separator3.Size = new System.Drawing.Size(6, 27);
      // 
      // showHelpButton
      // 
      this.showHelpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.showHelpButton.Image = ((System.Drawing.Image)(resources.GetObject("showHelpButton.Image")));
      this.showHelpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.showHelpButton.Name = "showHelpButton";
      this.showHelpButton.Size = new System.Drawing.Size(24, 24);
      this.showHelpButton.Text = "Help";
      this.showHelpButton.Click += new System.EventHandler(this.showHelpButton_Click);
      // 
      // _initialTreeRefreshTimer
      // 
      this._initialTreeRefreshTimer.Enabled = true;
      this._initialTreeRefreshTimer.Tick += new System.EventHandler(this.initialTreeRefreshTimer_Tick);
      // 
      // topSplitContainer
      // 
      this.topSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.topSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.topSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.topSplitContainer.Name = "topSplitContainer";
      // 
      // topSplitContainer.Panel1
      // 
      this.topSplitContainer.Panel1.Controls.Add(this._topLevelTabControl);
      // 
      // topSplitContainer.Panel2
      // 
      this.topSplitContainer.Panel2.Controls.Add(this._accessibleComponentTabControl);
      this.topSplitContainer.Size = new System.Drawing.Size(1008, 417);
      this.topSplitContainer.SplitterDistance = 464;
      this.topSplitContainer.TabIndex = 0;
      this.topSplitContainer.TabStop = false;
      // 
      // _topLevelTabControl
      // 
      this._topLevelTabControl.Controls.Add(this._accessibilityTreePage);
      this._topLevelTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this._topLevelTabControl.Location = new System.Drawing.Point(0, 0);
      this._topLevelTabControl.Name = "_topLevelTabControl";
      this._topLevelTabControl.SelectedIndex = 0;
      this._topLevelTabControl.Size = new System.Drawing.Size(464, 417);
      this._topLevelTabControl.TabIndex = 0;
      // 
      // _accessibilityTreePage
      // 
      this._accessibilityTreePage.Controls.Add(this._accessibilityTree);
      this._accessibilityTreePage.Location = new System.Drawing.Point(4, 24);
      this._accessibilityTreePage.Name = "_accessibilityTreePage";
      this._accessibilityTreePage.Size = new System.Drawing.Size(456, 389);
      this._accessibilityTreePage.TabIndex = 0;
      this._accessibilityTreePage.Text = "Accessibility Tree";
      this._accessibilityTreePage.UseVisualStyleBackColor = true;
      // 
      // _accessibilityTree
      // 
      this._accessibilityTree.AccessibleName = "Accessibility Tree";
      this._accessibilityTree.Dock = System.Windows.Forms.DockStyle.Fill;
      this._accessibilityTree.FullRowSelect = true;
      this._accessibilityTree.HideSelection = false;
      this._accessibilityTree.Location = new System.Drawing.Point(0, 0);
      this._accessibilityTree.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this._accessibilityTree.Name = "_accessibilityTree";
      this._accessibilityTree.Size = new System.Drawing.Size(456, 389);
      this._accessibilityTree.TabIndex = 0;
      // 
      // _accessibleComponentTabControl
      // 
      this._accessibleComponentTabControl.Controls.Add(this.accessibleComponentTabPage);
      this._accessibleComponentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this._accessibleComponentTabControl.Location = new System.Drawing.Point(0, 0);
      this._accessibleComponentTabControl.Name = "_accessibleComponentTabControl";
      this._accessibleComponentTabControl.SelectedIndex = 0;
      this._accessibleComponentTabControl.Size = new System.Drawing.Size(540, 417);
      this._accessibleComponentTabControl.TabIndex = 0;
      // 
      // accessibleComponentTabPage
      // 
      this.accessibleComponentTabPage.Controls.Add(this._accessibleContextPropertyList);
      this.accessibleComponentTabPage.Location = new System.Drawing.Point(4, 24);
      this.accessibleComponentTabPage.Name = "accessibleComponentTabPage";
      this.accessibleComponentTabPage.Size = new System.Drawing.Size(532, 389);
      this.accessibleComponentTabPage.TabIndex = 0;
      this.accessibleComponentTabPage.Text = "Accessible Component Properties";
      this.accessibleComponentTabPage.UseVisualStyleBackColor = true;
      // 
      // _accessibleContextPropertyList
      // 
      this._accessibleContextPropertyList.AccessibleName = "Component Properties";
      this._accessibleContextPropertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertyHeader,
            this.valueHeader});
      this._accessibleContextPropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
      this._accessibleContextPropertyList.FullRowSelect = true;
      this._accessibleContextPropertyList.GridLines = true;
      this._accessibleContextPropertyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this._accessibleContextPropertyList.Location = new System.Drawing.Point(0, 0);
      this._accessibleContextPropertyList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this._accessibleContextPropertyList.MultiSelect = false;
      this._accessibleContextPropertyList.Name = "_accessibleContextPropertyList";
      this._accessibleContextPropertyList.Size = new System.Drawing.Size(532, 389);
      this._accessibleContextPropertyList.SmallImageList = this._propertyImageList;
      this._accessibleContextPropertyList.TabIndex = 0;
      this._accessibleContextPropertyList.UseCompatibleStateImageBehavior = false;
      this._accessibleContextPropertyList.View = System.Windows.Forms.View.Details;
      // 
      // propertyHeader
      // 
      this.propertyHeader.Text = "Property";
      this.propertyHeader.Width = 200;
      // 
      // valueHeader
      // 
      this.valueHeader.Text = "Value";
      this.valueHeader.Width = 300;
      // 
      // _propertyImageList
      // 
      this._propertyImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_propertyImageList.ImageStream")));
      this._propertyImageList.TransparentColor = System.Drawing.Color.Transparent;
      this._propertyImageList.Images.SetKeyName(0, "Plus.png");
      this._propertyImageList.Images.SetKeyName(1, "Minus.png");
      // 
      // mainSplitContainer
      // 
      this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainSplitContainer.Location = new System.Drawing.Point(0, 51);
      this.mainSplitContainer.Name = "mainSplitContainer";
      this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // mainSplitContainer.Panel1
      // 
      this.mainSplitContainer.Panel1.Controls.Add(this.topSplitContainer);
      // 
      // mainSplitContainer.Panel2
      // 
      this.mainSplitContainer.Panel2.Controls.Add(this._bottomTabControl);
      this.mainSplitContainer.Size = new System.Drawing.Size(1008, 660);
      this.mainSplitContainer.SplitterDistance = 417;
      this.mainSplitContainer.TabIndex = 4;
      this.mainSplitContainer.TabStop = false;
      // 
      // _bottomTabControl
      // 
      this._bottomTabControl.Controls.Add(this._messageListPage);
      this._bottomTabControl.Controls.Add(this._eventListPage);
      this._bottomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this._bottomTabControl.Location = new System.Drawing.Point(0, 0);
      this._bottomTabControl.Name = "_bottomTabControl";
      this._bottomTabControl.SelectedIndex = 0;
      this._bottomTabControl.Size = new System.Drawing.Size(1008, 239);
      this._bottomTabControl.TabIndex = 0;
      // 
      // _messageListPage
      // 
      this._messageListPage.Controls.Add(this._messageList);
      this._messageListPage.Controls.Add(this.messagesToolStrip);
      this._messageListPage.Location = new System.Drawing.Point(4, 24);
      this._messageListPage.Name = "_messageListPage";
      this._messageListPage.Size = new System.Drawing.Size(1000, 211);
      this._messageListPage.TabIndex = 1;
      this._messageListPage.Text = "Messages";
      this._messageListPage.UseVisualStyleBackColor = true;
      // 
      // _messageList
      // 
      this._messageList.AccessibleName = "Messages";
      this._messageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.messageIdColumn,
            this.messageTimeColumn,
            this.messageTextColumn});
      this._messageList.Dock = System.Windows.Forms.DockStyle.Fill;
      this._messageList.FullRowSelect = true;
      this._messageList.GridLines = true;
      this._messageList.Location = new System.Drawing.Point(25, 0);
      this._messageList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this._messageList.Name = "_messageList";
      this._messageList.Size = new System.Drawing.Size(975, 211);
      this._messageList.TabIndex = 7;
      this._messageList.UseCompatibleStateImageBehavior = false;
      this._messageList.View = System.Windows.Forms.View.Details;
      // 
      // messageIdColumn
      // 
      this.messageIdColumn.Text = "Id";
      // 
      // messageTimeColumn
      // 
      this.messageTimeColumn.Text = "Time";
      this.messageTimeColumn.Width = 100;
      // 
      // messageTextColumn
      // 
      this.messageTextColumn.Text = "Message";
      this.messageTextColumn.Width = 900;
      // 
      // messagesToolStrip
      // 
      this.messagesToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
      this.messagesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.messagesToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.messagesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMessagesButton});
      this.messagesToolStrip.Location = new System.Drawing.Point(0, 0);
      this.messagesToolStrip.Name = "messagesToolStrip";
      this.messagesToolStrip.Size = new System.Drawing.Size(25, 211);
      this.messagesToolStrip.TabIndex = 6;
      this.messagesToolStrip.TabStop = true;
      this.messagesToolStrip.Text = "Messages";
      this.messagesToolStrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
      // 
      // clearMessagesButton
      // 
      this.clearMessagesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.clearMessagesButton.Image = ((System.Drawing.Image)(resources.GetObject("clearMessagesButton.Image")));
      this.clearMessagesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.clearMessagesButton.Name = "clearMessagesButton";
      this.clearMessagesButton.Size = new System.Drawing.Size(22, 24);
      this.clearMessagesButton.Text = "Clear";
      this.clearMessagesButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
      this.clearMessagesButton.Click += new System.EventHandler(this.clearMessagesButton_Click);
      // 
      // _eventListPage
      // 
      this._eventListPage.Controls.Add(this._eventList);
      this._eventListPage.Controls.Add(this.eventsToolStrip);
      this._eventListPage.Location = new System.Drawing.Point(4, 22);
      this._eventListPage.Name = "_eventListPage";
      this._eventListPage.Size = new System.Drawing.Size(1000, 213);
      this._eventListPage.TabIndex = 0;
      this._eventListPage.Text = "Accessibility Events";
      this._eventListPage.UseVisualStyleBackColor = true;
      // 
      // _eventList
      // 
      this._eventList.AccessibleName = "Events";
      this._eventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.eventId,
            this.eventTime,
            this.eventJvmId,
            this.eventName,
            this.eventSource,
            this.eventOldValue,
            this.eventNewValue});
      this._eventList.Dock = System.Windows.Forms.DockStyle.Fill;
      this._eventList.FullRowSelect = true;
      this._eventList.GridLines = true;
      this._eventList.Location = new System.Drawing.Point(25, 0);
      this._eventList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this._eventList.Name = "_eventList";
      this._eventList.Size = new System.Drawing.Size(975, 213);
      this._eventList.TabIndex = 5;
      this._eventList.UseCompatibleStateImageBehavior = false;
      this._eventList.View = System.Windows.Forms.View.Details;
      // 
      // eventId
      // 
      this.eventId.Text = "Id";
      // 
      // eventTime
      // 
      this.eventTime.Text = "Time";
      this.eventTime.Width = 100;
      // 
      // eventJvmId
      // 
      this.eventJvmId.Text = "JvmID";
      this.eventJvmId.Width = 100;
      // 
      // eventName
      // 
      this.eventName.Text = "Name";
      this.eventName.Width = 220;
      // 
      // eventSource
      // 
      this.eventSource.Text = "Source";
      this.eventSource.Width = 200;
      // 
      // eventOldValue
      // 
      this.eventOldValue.Text = "Old Value";
      this.eventOldValue.Width = 120;
      // 
      // eventNewValue
      // 
      this.eventNewValue.Text = "NewValue";
      this.eventNewValue.Width = 120;
      // 
      // eventsToolStrip
      // 
      this.eventsToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
      this.eventsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.eventsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.eventsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearEventsButton});
      this.eventsToolStrip.Location = new System.Drawing.Point(0, 0);
      this.eventsToolStrip.Name = "eventsToolStrip";
      this.eventsToolStrip.Size = new System.Drawing.Size(25, 213);
      this.eventsToolStrip.TabIndex = 0;
      this.eventsToolStrip.TabStop = true;
      this.eventsToolStrip.Text = "Events";
      this.eventsToolStrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
      // 
      // clearEventsButton
      // 
      this.clearEventsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.clearEventsButton.Image = ((System.Drawing.Image)(resources.GetObject("clearEventsButton.Image")));
      this.clearEventsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.clearEventsButton.Name = "clearEventsButton";
      this.clearEventsButton.Size = new System.Drawing.Size(22, 24);
      this.clearEventsButton.Text = "Clear";
      this.clearEventsButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
      this.clearEventsButton.Click += new System.EventHandler(this.clearEventsButton_Click);
      // 
      // memoryRefreshTimer
      // 
      this.memoryRefreshTimer.Enabled = true;
      this.memoryRefreshTimer.Interval = 200;
      this.memoryRefreshTimer.Tick += new System.EventHandler(this.memoryRefreshTimer_Tick);
      // 
      // notificationPanel
      // 
      this.notificationPanel.AccessibleName = "Notification Panel";
      this.notificationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.notificationPanel.BackColor = System.Drawing.Color.LightYellow;
      this.notificationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.notificationPanel.Location = new System.Drawing.Point(440, 2);
      this.notificationPanel.Margin = new System.Windows.Forms.Padding(0);
      this.notificationPanel.MinimumSize = new System.Drawing.Size(100, 20);
      this.notificationPanel.Name = "notificationPanel";
      this.notificationPanel.Size = new System.Drawing.Size(566, 40);
      this.notificationPanel.TabIndex = 2;
      // 
      // updateChecker
      // 
      this.updateChecker.Enabled = true;
      this.updateChecker.Url = "https://google.github.io/access-bridge-explorer/latest_version.txt";
      this.updateChecker.UpdateInfoAvailable += new System.EventHandler<AccessBridgeExplorer.UpdateInfoArgs>(this.updateChecker_UpdateInfoAvailable);
      this.updateChecker.UpdateInfoError += new System.EventHandler<System.IO.ErrorEventArgs>(this.updateChecker_UpdateInfoError);
      // 
      // synchronizeTreeLogErrorsMenuItem
      // 
      this.synchronizeTreeLogErrorsMenuItem.Name = "synchronizeTreeLogErrorsMenuItem";
      this.synchronizeTreeLogErrorsMenuItem.Size = new System.Drawing.Size(250, 22);
      this.synchronizeTreeLogErrorsMenuItem.Text = "Log synchronize tree errors";
      // 
      // toolStripMenuItem9
      // 
      this.toolStripMenuItem9.Name = "toolStripMenuItem9";
      this.toolStripMenuItem9.Size = new System.Drawing.Size(247, 6);
      // 
      // ExplorerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1008, 733);
      this.Controls.Add(this.notificationPanel);
      this.Controls.Add(this.mainSplitContainer);
      this.Controls.Add(this.mainToolStrip);
      this.Controls.Add(this.mainMenuStrip);
      this.Controls.Add(this.statusBarStrip);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MainMenuStrip = this.mainMenuStrip;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MinimumSize = new System.Drawing.Size(600, 400);
      this.Name = "ExplorerForm";
      this.Text = "Access Bridge Explorer";
      this.Activated += new System.EventHandler(this.MainForm_Activated);
      this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.MouseCaptureChanged += new System.EventHandler(this.MainForm_MouseCaptureChanged);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
      this.mainMenuStrip.ResumeLayout(false);
      this.mainMenuStrip.PerformLayout();
      this.statusBarStrip.ResumeLayout(false);
      this.statusBarStrip.PerformLayout();
      this.mainToolStrip.ResumeLayout(false);
      this.mainToolStrip.PerformLayout();
      this.topSplitContainer.Panel1.ResumeLayout(false);
      this.topSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.topSplitContainer)).EndInit();
      this.topSplitContainer.ResumeLayout(false);
      this._topLevelTabControl.ResumeLayout(false);
      this._accessibilityTreePage.ResumeLayout(false);
      this._accessibleComponentTabControl.ResumeLayout(false);
      this.accessibleComponentTabPage.ResumeLayout(false);
      this.mainSplitContainer.Panel1.ResumeLayout(false);
      this.mainSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
      this.mainSplitContainer.ResumeLayout(false);
      this._bottomTabControl.ResumeLayout(false);
      this._messageListPage.ResumeLayout(false);
      this._messageListPage.PerformLayout();
      this.messagesToolStrip.ResumeLayout(false);
      this.messagesToolStrip.PerformLayout();
      this._eventListPage.ResumeLayout(false);
      this._eventListPage.PerformLayout();
      this.eventsToolStrip.ResumeLayout(false);
      this.eventsToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mainMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileMenu;
    private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    private System.Windows.Forms.StatusStrip statusBarStrip;
    private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
    private System.Windows.Forms.ToolStrip mainToolStrip;
    private System.Windows.Forms.ToolStripButton _refreshButton;
    private System.Windows.Forms.ToolStripButton _findComponentButton;
    private System.Windows.Forms.Timer _initialTreeRefreshTimer;
    private System.Windows.Forms.SplitContainer topSplitContainer;
    private System.Windows.Forms.SplitContainer mainSplitContainer;
    private System.Windows.Forms.ToolStripMenuItem _eventsMenu;
    private System.Windows.Forms.TabControl _bottomTabControl;
    private System.Windows.Forms.TabPage _eventListPage;
    private System.Windows.Forms.ListView _eventList;
    private System.Windows.Forms.ColumnHeader eventId;
    private System.Windows.Forms.ColumnHeader eventTime;
    private System.Windows.Forms.ColumnHeader eventJvmId;
    private System.Windows.Forms.ColumnHeader eventName;
    private System.Windows.Forms.ColumnHeader eventSource;
    private System.Windows.Forms.ColumnHeader eventOldValue;
    private System.Windows.Forms.ColumnHeader eventNewValue;
    private System.Windows.Forms.ToolStrip eventsToolStrip;
    private System.Windows.Forms.ToolStripButton clearEventsButton;
    private System.Windows.Forms.TabPage _messageListPage;
    private System.Windows.Forms.ListView _messageList;
    private System.Windows.Forms.ColumnHeader messageIdColumn;
    private System.Windows.Forms.ColumnHeader messageTimeColumn;
    private System.Windows.Forms.ColumnHeader messageTextColumn;
    private System.Windows.Forms.ToolStrip messagesToolStrip;
    private System.Windows.Forms.ToolStripButton clearMessagesButton;
    private System.Windows.Forms.TabControl _topLevelTabControl;
    private System.Windows.Forms.TabPage _accessibilityTreePage;
    private System.Windows.Forms.TreeView _accessibilityTree;
    private System.Windows.Forms.ToolStripSeparator separator2;
    private System.Windows.Forms.ToolStripSeparator separator3;
    private System.Windows.Forms.ToolStripButton showHelpButton;
    private System.Windows.Forms.TabControl _accessibleComponentTabControl;
    private System.Windows.Forms.TabPage accessibleComponentTabPage;
    private System.Windows.Forms.ListView _accessibleContextPropertyList;
    private System.Windows.Forms.ColumnHeader propertyHeader;
    private System.Windows.Forms.ColumnHeader valueHeader;
    private System.Windows.Forms.ToolStripMenuItem helpMenu;
    private System.Windows.Forms.ToolStripMenuItem viewHelpMenuItem;
    private System.Windows.Forms.ImageList _propertyImageList;
    private System.Windows.Forms.ToolStripMenuItem viewMenu;
    private System.Windows.Forms.ToolStripMenuItem navigateForwardMenuItem;
    private System.Windows.Forms.ToolStripMenuItem navigateBackwardMenuItem;
    private System.Windows.Forms.ToolStripSeparator separator1;
    private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
    private System.Windows.Forms.ToolStripSplitButton navigateBackwardButton;
    private System.Windows.Forms.ToolStripSplitButton navigateForwardButton;
    private System.Windows.Forms.ToolStripSeparator separator4;
    private System.Windows.Forms.ToolStripMenuItem optionsMenu;
    private System.Windows.Forms.ToolStripMenuItem _propertiesMenu;
    private System.Windows.Forms.ToolStripMenuItem activateOverlayOnTreeSelectionMenuItem;
    private System.Windows.Forms.ToolStripMenuItem activateOverlayOnComponentSelectionMenuItem;
    private System.Windows.Forms.ToolStripButton _enableOverlayButton;
    private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private NotificationPanel notificationPanel;
    private System.Windows.Forms.ToolStripMenuItem showNotificationMenuItem;
    private System.Windows.Forms.ToolStripMenuItem activateOverlayOnFocusMenuItem;
    private System.Windows.Forms.ToolStripMenuItem showTooltipAndOverlayMenuItem;
    private UpdateChecker updateChecker;
    private System.Windows.Forms.ToolStripMenuItem checkForUpdateMenuItem;
    private System.Windows.Forms.ToolStripMenuItem automaticallyCheckForUpdatesMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem componentOverlayToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem showOverlayOnlyMenuItem;
    private System.Windows.Forms.ToolStripMenuItem showTooltipOnlyMenuItem;
    private System.Windows.Forms.ToolStripMenuItem activateOverlayOnActiveDescendantMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enableOverlayMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.ToolStripMenuItem resetAllOptionsMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel javaObjectsStatusLabel;
    private System.Windows.Forms.ToolStripDropDownButton garbageCollectButton;
    private System.Windows.Forms.Timer memoryRefreshTimer;
    private System.Windows.Forms.ToolStripStatusLabel memoryStatusLabel;
    private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem _limitTextBufferLengthMenu;
    private System.Windows.Forms.ToolStripMenuItem autoReleaseInactiveObjectsMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    private System.Windows.Forms.ToolStripMenuItem enableCaptureHookMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enableOverlayHookMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    private System.Windows.Forms.ToolStripMenuItem _limitCollectionsCountMenu;
    private System.Windows.Forms.ToolStripMenuItem _limitTextLineCountsMenu;
    private System.Windows.Forms.ToolStripMenuItem _limitTextLineLengthsMenu;
    private System.Windows.Forms.ToolStripSeparator separator5;
    private System.Windows.Forms.ToolStripMenuItem autoDetectApplicationsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem synchronizeTreeMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
    private System.Windows.Forms.ToolStripMenuItem synchronizeTreeLogErrorsMenuItem;
  }
}

