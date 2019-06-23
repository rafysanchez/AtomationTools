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
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using WindowsAccessBridgeInterop;
using AccessBridgeExplorer.Utils;
using AccessBridgeExplorer.Utils.Settings;

namespace AccessBridgeExplorer {
  public partial class ExplorerForm : Form, IExplorerFormView, IMessageQueue {
    private readonly IUserSettings _userSettings;
    private readonly WindowsHotKeyHandlerFactory _handlerFactory;
    private readonly ExplorerFormController _controller;
    private readonly PropertyListView _accessibleComponentPropertyListViewView;
    private readonly UserSetting<bool> _automaticallyCheckForUpdateSetting;
    private bool _capturing;
    private int _navigationVersion = int.MinValue;
    private bool _updateNotificationShown;

    public ExplorerForm() {
      InitializeComponent();
      _handlerFactory = new WindowsHotKeyHandlerFactory(this);
      _userSettings = UserSettingsProvider.Instance;
      _accessibleComponentPropertyListViewView = new PropertyListView(_accessibleContextPropertyList, _propertyImageList);
      _controller = new ExplorerFormController(this, _userSettings);

      _automaticallyCheckForUpdateSetting = new BoolUserSetting(_userSettings, "update.autoCheck", true);
      _automaticallyCheckForUpdateSetting.Sync += (sender, args) => {
        updateChecker.Enabled = args.Value;
        automaticallyCheckForUpdatesMenuItem.Checked = args.Value;
      };

      mainToolStrip.Renderer = new OverlayButtonRenderer(this);
      SetDoubleBuffered(_accessibilityTree, true);
      SetDoubleBuffered(_messageList, true);
      SetDoubleBuffered(_accessibleContextPropertyList, true);
      SetDoubleBuffered(_topLevelTabControl, true);
      SetDoubleBuffered(_accessibleComponentTabControl, true);
      SetDoubleBuffered(_bottomTabControl, true);

      //activateOverlayOnTreeSelectionButton_Click(activateOverlayOnTreeSelectionButton, EventArgs.Empty);
      //autoDetectApplicationsMenuItem_CheckChanged(autoDetectApplicationsMenuItem, EventArgs.Empty);
      //automaticallyCheckForUpdatesMenuItem_CheckedChanged(automaticallyCheckForUpdatesMenuItem, EventArgs.Empty);
    }

    private void MainForm_Shown(object sender, EventArgs e) {
      InvokeLater(() => {
        _controller.LogIntroMessages();
        _userSettings.Load();
        _controller.Initialize();
        //Application.Idle += Application_Idle;
      });


            var qtd = _controller.EnumJvms();

    }

    private void Application_Idle(object sender, EventArgs eventArgs) {
      UpdateNavigationState();
      UpdateNotificationMenu();
    }

    private void garbageCollectButton_Click(object sender, EventArgs e) {
      for (var i = 0; i < 3; i++) {
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
      _controller.ReleaseActiveObjects(true);
    }

    private void memoryRefreshTimer_Tick(object sender, EventArgs e) {
      _controller.ReleaseActiveObjects(false);
      RefreshObjectsStatus();
      RefreshMemoryStatus();
    }

    private void RefreshObjectsStatus() {
      var text = string.Format("Active Java Objects: {0:n0}, Inactive: {1:n0}",
        JavaObjectHandle.ActiveContextCount,
        JavaObjectHandle.InactiveContextCount);
      if (javaObjectsStatusLabel.Text != text) {
        javaObjectsStatusLabel.Text = text;
      }
    }

    private void RefreshMemoryStatus() {
      var text = string.Format("Mem: {0:n0} MB", GC.GetTotalMemory(false) / 1024 / 1024);
      if (memoryStatusLabel.Text != text) {
        memoryStatusLabel.Text = text;
      }
    }

    private void UpdateNotificationMenu() {
      showNotificationMenuItem.Checked = notificationPanel.Visible;
      showNotificationMenuItem.Enabled = notificationPanel.NotificationText.Length > 0;
    }

    private void UpdateNavigationState() {
      if (_navigationVersion == _controller.Navigation.Version)
        return;
      _navigationVersion = _controller.Navigation.Version;

      navigateBackwardButton.Enabled = _controller.Navigation.BackwardAvailable;
      navigateBackwardMenuItem.Enabled = _controller.Navigation.BackwardAvailable;
      AddDropDownEntries(navigateBackwardButton.DropDownItems, _controller.Navigation.BackwardEntries);

      navigateForwardButton.Enabled = _controller.Navigation.ForwardAvailable;
      navigateForwardMenuItem.Enabled = _controller.Navigation.ForwardAvailable;
      AddDropDownEntries(navigateForwardButton.DropDownItems, _controller.Navigation.ForwardEntries);
    }

    private void AddDropDownEntries(ToolStripItemCollection items, IEnumerable<NavigationEntry> entries) {
      items.Clear();
      var index = 0;
      entries.ForEach(entry => {
        if (index++ >= 20)
          return;

        var item = items.Add(entry.Description);
        item.Click += (sender, args) => {
          _controller.Navigation.NavigateTo(entry);
          UpdateNavigationState();
        };
      });
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      _controller.Dispose();
      Close();
    }

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
      _controller.RefreshTree();
    }

    private void refreshButton_Click(object sender, EventArgs e) {
      _controller.RefreshTree();
    }

    private void checkForUpdateMenuItem_Click(object sender, EventArgs e) {
      _updateNotificationShown = false;
      updateChecker.CheckNow();
      if (!_updateNotificationShown) {
        notificationPanel.ShowNotification(new NotificationPanelEntry {
          Text = string.Format("{0} is up to date.", Assembly.GetEntryAssembly().GetName().Name),
          Icon = NotificationPanelIcon.Info,
        });
      }
    }

    private void automaticallyCheckForUpdatesMenuItem_CheckedChanged(object sender, EventArgs e) {
      _automaticallyCheckForUpdateSetting.Value = automaticallyCheckForUpdatesMenuItem.Checked;
    }

    private void updateChecker_UpdateInfoAvailable(object sender, UpdateInfoArgs e) {
      var currentVersion = Assembly.GetEntryAssembly().GetName().Version;
      if (e.Version > currentVersion) {
        _updateNotificationShown = true;
        notificationPanel.ShowNotification(new NotificationPanelEntry {
          Text = string.Format("A new version {0} of {1} is available at {2}",
            e.Version,
            Assembly.GetEntryAssembly().GetName().Name,
            e.Url),
          Icon = NotificationPanelIcon.Info,
        });
      }
    }

    private void updateChecker_UpdateInfoError(object sender, System.IO.ErrorEventArgs e) {
      _updateNotificationShown = true;
      notificationPanel.ShowNotification(new NotificationPanelEntry {
        Text = ExceptionUtils.FormatExceptionMessage(e.GetException()),
        Icon = NotificationPanelIcon.Error,
      });
    }

    private void activateOverlayOnTreeSelectionMenuItem_Click(object sender, EventArgs e) {
      var enable = !activateOverlayOnTreeSelectionMenuItem.Checked;
      _controller.EnableOverlayActivationFlag(OverlayActivation.OnTreeViewSelection, enable);
    }

    private void activateOverlayOnComponentSelectionMenuItem_Click(object sender, EventArgs e) {
      var enable = !activateOverlayOnComponentSelectionMenuItem.Checked;
      _controller.EnableOverlayActivationFlag(OverlayActivation.OnPropertyListSelection, enable);
    }

    private void activateOverlayOnFocusMenuItem_Click(object sender, EventArgs e) {
      var enable = !activateOverlayOnFocusMenuItem.Checked;
      _controller.EnableOverlayActivationFlag(OverlayActivation.OnAccessibleComponentFocus, enable);
    }

    private void activateOverlayOnActiveDescendantMenuItem_Click(object sender, EventArgs e) {
      var enable = !activateOverlayOnActiveDescendantMenuItem.Checked;
      _controller.EnableOverlayActivationFlag(OverlayActivation.OnAccessibleActiveDescendantChanged, enable);
    }

    private void showTooltipAndOverlayMenuItem_Click(object sender, EventArgs e) {
      _controller.OverlayDisplayType = OverlayDisplayType.OverlayAndTooltip;
    }

    private void showTooltipOnlyMenuItem_Click(object sender, EventArgs e) {
      _controller.OverlayDisplayType = OverlayDisplayType.TooltipOnly;
    }

    private void showOverlayOnlyMenuItem_Click(object sender, EventArgs e) {
      _controller.OverlayDisplayType = OverlayDisplayType.OverlayOnly;
    }

    private class OverlayButtonRenderer : ToolStripProfessionalRenderer {
      private readonly ExplorerForm _explorerForm;

      public OverlayButtonRenderer(ExplorerForm explorerForm) {
        _explorerForm = explorerForm;
      }

      protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
        base.OnRenderButtonBackground(e);

        if (ReferenceEquals(e.Item, _explorerForm._enableOverlayButton)) {
          var bounds = new Rectangle(Point.Empty, e.Item.Size);
          bounds.Inflate(-1, -1);
          e.Graphics.FillRectangle(new SolidBrush(e.Item.ForeColor), bounds);
        }
      }
    }

    private void catpureButton_MouseDown(object sender, MouseEventArgs e) {
      _controller.StartMouseCapture();
      _capturing = true;
      Cursor = Cursors.Cross;
      Capture = true;
    }

    private void MainForm_MouseCaptureChanged(object sender, EventArgs e) {
      Cursor = Cursors.Default;
      _capturing = false;
      _controller.StopMouseCapture();
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e) {
      if (!_capturing)
        return;

      _controller.MouseCaptureMove(PointToScreen(e.Location));
    }

    private void MainForm_MouseUp(object sender, MouseEventArgs e) {
      if (!_capturing)
        return;

      var screenPoint = PointToScreen(e.Location);
      _controller.SelectNodeAtPoint(screenPoint);
      Capture = false;
    }

    private void initialTreeRefreshTimer_Tick(object sender, EventArgs e) {



     _initialTreeRefreshTimer.Stop();




      _controller.RefreshTree();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      Application.Idle -= Application_Idle;
      _controller.Dispose();
    }

    private void MainForm_Activated(object sender, EventArgs e) {
      _controller.OnFocusGained();
    }

    private void MainForm_Deactivate(object sender, EventArgs e) {
      _controller.OnFocusLost();
    }

    private void clearEventsButton_Click(object sender, EventArgs e) {
      _eventList.Items.Clear();
    }

    private void clearMessagesButton_Click(object sender, EventArgs e) {
      _messageList.Items.Clear();
    }

    private void showHelpButton_Click(object sender, EventArgs e) {
      ShowHelp();
    }

    private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e) {
      ShowHelp();
    }

    private void ShowHelp() {
      _controller.ShowHelp();
    }

    public static void SetDoubleBuffered(Control control, bool enable) {
      var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
      doubleBufferPropertyInfo.SetValue(control, enable, null);
    }

    public void Invoke(Action action) {
      if (InvokeRequired) {
        base.Invoke(action);
      } else {
        action();
      }
    }

    public T Compute<T>(Func<T> function) {
      if (InvokeRequired) {
        return (T)base.Invoke(function);
      } else {
        return function();
      }
    }

    public void InvokeLater(Action action) {
      BeginInvoke(action);
    }

    private void navigateForwardButton_Click(object sender, EventArgs e) {
      _controller.Navigation.NavigateForward();
      UpdateNavigationState();
    }

    private void navigateForwardToolStripMenuItem_Click(object sender, EventArgs e) {
      _controller.Navigation.NavigateForward();
      UpdateNavigationState();
    }

    private void navigateBackwardButton_Click(object sender, EventArgs e) {
      _controller.Navigation.NavigateBackward();
      UpdateNavigationState();
    }

    private void navigateBackwardToolStripMenuItem_Click(object sender, EventArgs e) {
      _controller.Navigation.NavigateBackward();
      UpdateNavigationState();
    }

    private void aboutMenuItem_Click(object sender, EventArgs e) {
      _controller.ShowAbout();
    }

    private void showNotificationMenuItem_Click(object sender, EventArgs e) {
      if (showNotificationMenuItem.Checked) {
        notificationPanel.HidePanel();
        showNotificationMenuItem.Checked = false;
      } else {
        notificationPanel.ShowPanel();
        showNotificationMenuItem.Checked = true;
      }
    }

    private void resetAllOptionsMenuItem_Click(object sender, EventArgs e) {
      var result = MessageBox.Show(this,
        "Are you sure you want to reset all options to their default values?\r\n\r\n(A Restart will be required)",
        "Reset all options",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button2);
      if (result == DialogResult.No) {
        return;
      }

      _userSettings.Clear();

      MessageBox.Show(this,
        "Please restart the application for changes to take effect",
        "Reset all options",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }

    #region IExplorerFormView

    string IExplorerFormView.Caption {
      get { return Text; }
    }

    Point IExplorerFormView.CursorPosition {
      get { return Cursor.Position; }
    }

    WindowsHotKeyHandlerFactory IExplorerFormView.WindowsHotKeyHandlerFactory {
      get {
                return _handlerFactory; }
            }

    IMessageQueue IExplorerFormView.MessageQueue {
      get { return this; }
    }

    ToolStripButton IExplorerFormView.RefreshButton {
      get { return _refreshButton; }
    }

    ToolStripButton IExplorerFormView.FindComponentButton {
      get { return _findComponentButton; }
    }

    TabPage IExplorerFormView.AccessibilityTreePage {
      get { return _accessibilityTreePage; }
    }

    TreeView IExplorerFormView.AccessibilityTree {
      get { return _accessibilityTree; }
    }

    PropertyListView IExplorerFormView.AccessibleComponentPropertyListView {
      get { return _accessibleComponentPropertyListViewView; }
    }

    TabPage IExplorerFormView.MessageListPage {
      get { return _messageListPage; }
    }

    ListView IExplorerFormView.MessageList {
      get { return _messageList; }
    }

    TabPage IExplorerFormView.EventListPage {
      get { return _eventListPage; }
    }

    ListView IExplorerFormView.EventList {
      get { return _eventList; }
    }

    ToolStripMenuItem IExplorerFormView.PropertiesMenu {
      get { return _propertiesMenu; }
    }

    ToolStripMenuItem IExplorerFormView.EventsMenu {
      get { return _eventsMenu; }
    }

    ToolStripMenuItem IExplorerFormView.LimitCollectionSizesMenu {
      get { return _limitCollectionsCountMenu; }
    }

    ToolStripMenuItem IExplorerFormView.LimitTextLineCountMenu {
      get { return _limitTextLineCountsMenu; }
    }

    ToolStripMenuItem IExplorerFormView.LimitTextLineLengthsMenu {
      get { return _limitTextLineLengthsMenu; }
    }

    ToolStripMenuItem IExplorerFormView.LimitTextBufferLengthMenu {
      get { return _limitTextBufferLengthMenu; }
    }

    ToolStripMenuItem IExplorerFormView.AutoDetectApplicationsMenuItem {
      get { return autoDetectApplicationsMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.AutoReleaseInactiveObjectsMenuItem {
      get { return autoReleaseInactiveObjectsMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.EnableOverlayMenuItem {
      get { return enableOverlayMenuItem; }
    }

    ToolStripButton IExplorerFormView.EnableOverlayButton {
      get { return _enableOverlayButton; }
    }

    ToolStripMenuItem IExplorerFormView.ActivateOverlayOnTreeSelectionMenu {
      get { return activateOverlayOnTreeSelectionMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.ActivateOverlayOnComponentSelectionMenu {
      get { return activateOverlayOnComponentSelectionMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.ActivateOverlayOnFocusMenu {
      get { return activateOverlayOnFocusMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.ActivateOverlayOnActiveDescendantMenu {
      get { return activateOverlayOnActiveDescendantMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.ShowTooltipAndOverlayMenuItem {
      get { return showTooltipAndOverlayMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.ShowTooltipOnlyMenuItem {
      get { return showTooltipOnlyMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.ShowOverlayOnlyMenuItem {
      get { return showOverlayOnlyMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.SynchronizeTreeMenuItem {
      get { return synchronizeTreeMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.SynchronizeTreeLogErrorsMenuItem {
      get { return synchronizeTreeLogErrorsMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.EnableCaptureHookMenuItem {
      get { return enableCaptureHookMenuItem; }
    }

    ToolStripMenuItem IExplorerFormView.EnableOverlayHookMenuItem {
      get { return enableOverlayHookMenuItem; }
    }

    ToolStripStatusLabel IExplorerFormView.StatusLabel {
      get { return _statusLabel; }
    }

    void IExplorerFormView.ShowMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon) {
      MessageBox.Show(this, message, title, buttons, icon);
    }

    void IExplorerFormView.ShowDialog(Form form) {
      form.ShowDialog(this);
    }

    void IExplorerFormView.FocusMessageList() {
      _bottomTabControl.SelectedTab = _messageListPage;
      _messageList.Focus();
    }

    void IExplorerFormView.ShowNotification(NotificationPanelEntry entry) {
      notificationPanel.ShowNotification(entry);
    }

    #endregion
  }
}
