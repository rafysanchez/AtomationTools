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

namespace AccessBridgeExplorer {
  public interface IExplorerFormNavigation {
    int Version { get; }
    bool ForwardAvailable { get; }
    bool BackwardAvailable { get; }

    IEnumerable<NavigationEntry> BackwardEntries { get; }
    IEnumerable<NavigationEntry> ForwardEntries { get; }

    void Clear();
    void AddNavigationAction(NavigationEntry entry);
    void NavigateForward();
    void NavigateBackward();
    void NavigateTo(NavigationEntry entry);
  }

  public class NavigationEntry {
    public string Description { get; set; }
    public Action Action { get; set; }
  }
}