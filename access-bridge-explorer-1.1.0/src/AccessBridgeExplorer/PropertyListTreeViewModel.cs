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

using System.Text;
using WindowsAccessBridgeInterop;
using AccessBridgeExplorer.Utils;

namespace AccessBridgeExplorer {
  /// <summary>
  /// Implementation of <see cref="TreeListViewModel{TNode}"/> using a single
  /// <see cref="PropertyList"/> as the input.
  /// </summary>
  public class PropertyListTreeViewModel : TreeListViewModel<PropertyNode> {
    private readonly PropertyGroup _rootNode;

    public PropertyListTreeViewModel(PropertyList propertyList) {
      _rootNode = new PropertyGroup("");
      _rootNode.Children.AddRange(propertyList);
    }

    public override PropertyNode GetRootNode() {
      return _rootNode;
    }

    public override bool IsRootVisible() {
      return false;
    }

    public override int GetChildCount(PropertyNode node) {
      var group = node as PropertyGroup;
      if (group == null)
        return 0;
      return group.Children.Count;
    }

    public override PropertyNode GetChildAt(PropertyNode node, int index) {
      var group = (PropertyGroup)node;
      return group.Children[index];
    }

    public override bool IsNodeExpandable(PropertyNode node) {
      var group = node as PropertyGroup;
      return group != null;
    }

    public override bool IsNodeExpanded(PropertyNode node) {
      var group = node as PropertyGroup;
      if (group != null)
        return group.Expanded;
      return false;
    }

    public override string GetNodeText(PropertyNode node) {
      return node.Name;
    }

    public override int GetNodeSubItemCount(PropertyNode node) {
      return 1;
    }

    public override string GetNodeSubItemAt(PropertyNode node, int index) {
      return PropertyNodeValueToString(node);
    }

    public static string PropertyNodeValueToString(PropertyNode propertyNode) {
      var text = ValueToStringImpl(propertyNode);
      var sb = new StringBuilder();
      foreach (var c in text) {
        sb.Append(TranslateChar(c));
      }
      return sb.ToString();
    }

    private static string TranslateChar(char c) {
      if (c == '\r') return "\\r";
      if (c == '\n') return "\\n";
      if (c == '\t') return "\\t";
      if (char.IsControl(c)) return "*";
      return c.ToString();
    }

    private static string ValueToStringImpl(PropertyNode propertyNode) {
      var value = propertyNode.Value;
      string valueText;
      if (value == null) {
        if (propertyNode is PropertyGroup)
          valueText = "";
        else
          valueText = "-";
      } else if (value is bool) {
        valueText = ((bool)value) ? "Yes" : "No";
      } else if (value is string) {
        valueText = string.IsNullOrEmpty((string)value) ? "-" : (string)value;
      } else {
        valueText = value.ToString();
      }
      return valueText;
    }
  }
}