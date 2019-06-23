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
using System.Linq;
using System.Windows.Forms;
using WindowsAccessBridgeInterop;
using AccessBridgeExplorer.Utils;

namespace AccessBridgeExplorer {
  /// <summary>
  /// Wraps a <see cref="ListView"/> used to display a <see
  /// cref="PropertyList"/> to handle node identation and expand/collapse. The
  /// <see cref="SetPropertyList"/> method must be called to switch to a new
  /// property list. The <see cref="Clear"/> method must be called to clear the
  /// contents of the listview.
  /// </summary>
  public class PropertyListView {
    private readonly TreeListView<PropertyNode> _treeListView;
    private readonly HashSet<PropertyGroup> _knownGroups = new HashSet<PropertyGroup>();
    private PropertyList _currentPropertyList;

    /// <summary>
    /// Setup event handlers and image list. Can be called in the Forms
    /// constructor, just after <code>InitializeComponent</code>.
    /// </summary>
    public PropertyListView(ListView listView, ImageList stateImageList) {
      _treeListView = new TreeListView<PropertyNode>(listView, stateImageList);
      _treeListView.NodeVisibilityChanged += TreeListViewOnNodeVisibilityChanged;
      listView.SelectedIndexChanged += ListOnSelectedIndexChanged;
      listView.GotFocus += ListViewOnGotFocus;
    }

    public event EventHandler<AccessibleRectInfoSelectedEventArgs> AccessibleRectInfoSelected;
    public event EventHandler<PropertyGroupErrorEventArgs> Error;

    /// <summary>
    /// Set a new <paramref name="propertyList"/> to be displayed in the <see
    /// cref="ListView"/>.
    /// </summary>
    public void SetPropertyList(PropertyList propertyList) {
      _currentPropertyList = propertyList;
      _knownGroups.Clear();
      _treeListView.SetModel(new PropertyListTreeViewModel(_currentPropertyList));
    }

    /// <summary>
    /// Remove the current <see cref="PropertyList"/> and remove all entries
    /// displayed in the <see cref="ListView"/>.
    /// </summary>
    public void Clear() {
      _treeListView.Clear();
    }

    private void TreeListViewOnNodeVisibilityChanged(object s, NodeVisibilityChangedArg<PropertyNode> nodeArgs) {
      var group = nodeArgs.Node as PropertyGroup;
      if (group != null) {
        _knownGroups.Add(group);
        group.Error += (sender, args) => {
          OnError(new PropertyGroupErrorEventArgs((PropertyGroup)sender, args.GetException()));
        };
      }
    }

    private void ListViewOnGotFocus(object sender, EventArgs eventArgs) {
      ListOnSelectedIndexChanged(sender, eventArgs);
    }

    private void ListOnSelectedIndexChanged(object sender, EventArgs eventArgs) {
      var propertyNode = _treeListView.SelectedNodes.FirstOrDefault();
      if (propertyNode == null)
        return;

      var rect = GetRectangleFromPropertyNode(propertyNode);
      if (rect == null)
        return;

      if (!rect.IsVisible)
        return;

      OnAccessibleRectInfoSelected(new AccessibleRectInfoSelectedEventArgs {
        PropertyNode = propertyNode,
        AccessibleRectInfo = rect,
      });
    }

    private AccessibleRectInfo GetRectangleFromPropertyNode(PropertyNode propertyNode) {
      // If property node has a rect, return the rect
      {
        var rect = propertyNode.Value as AccessibleRectInfo;
        if (rect != null)
          return rect;
      }

      // If group, look for child property with rectangle
      {
        var group = propertyNode as PropertyGroup;
        if (group != null) {
          var rect = group.Children.Select(x => x.Value as AccessibleRectInfo).FirstOrDefault(x => x != null);
          if (rect != null)
            return rect;
        }
      }

      // Look for containing group, then for property with a rect
      for (var groupNode = FindParentPropertyGroup(propertyNode); groupNode != null; groupNode = FindParentPropertyGroup(groupNode)) {
        var rect = groupNode.Children.Select(x => x.Value as AccessibleRectInfo).FirstOrDefault(x => x != null);
        if (rect != null)
          return rect;
      }

      // If no parent group has a valid rectangle, last change is to look at all property node at indent = 0
      return _currentPropertyList
        .Select(x => x.Value as AccessibleRectInfo)
        .FirstOrDefault(x => x != null);
    }

    private PropertyGroup FindParentPropertyGroup(PropertyNode node) {
      return _knownGroups.FirstOrDefault(x => x.Children.Contains(node));
    }

    protected virtual void OnAccessibleRectInfoSelected(AccessibleRectInfoSelectedEventArgs e) {
      var handler = AccessibleRectInfoSelected;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnError(PropertyGroupErrorEventArgs e) {
      var handler = Error;
      if (handler != null) handler(this, e);
    }
  }
}