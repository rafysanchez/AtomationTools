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
using System.Linq;
using System.Windows.Forms;
using WindowsAccessBridgeInterop;
using AccessBridgeExplorer.Utils;

namespace AccessBridgeExplorer.Model {
  public class AccessibleNodeModel : NodeModel {
    private readonly AccessibleNodeModelResources _resources;
    private AccessibleNode _accessibleNode;

    public AccessibleNodeModel(AccessibleNodeModelResources resources, AccessibleNode accessibleNode) {
      _resources = resources;
      _accessibleNode = accessibleNode;
    }

    public AccessibleNode AccessibleNode {
      get { return _accessibleNode; }
      set { _accessibleNode = value; }
    }

    public override void AddChildren(TreeNode node) {
      _accessibleNode.GetChildren()
        .Select(x => new AccessibleNodeModel(_resources, x))
        .ForEach(x => {
          node.Nodes.Add(x.CreateTreeNode());
        });
    }

    public override void SetupTreeNode(TreeNode node) {
      bool hasChildren;
      try {
        hasChildren = _accessibleNode.GetChildren().Any();
      } catch {
        hasChildren = false;
      }

      if (hasChildren) {
        AddFakeChild(node);
      }

      try {
        node.Text = _accessibleNode.GetTitle();
      } catch (Exception e) {
        node.Text = string.Format("Error: {0}", e.Message);
      }

      if (_accessibleNode.IsManagedDescendant) { 
        node.NodeFont = _resources.ManagedDescendantFont;
      }
    }
  }
}