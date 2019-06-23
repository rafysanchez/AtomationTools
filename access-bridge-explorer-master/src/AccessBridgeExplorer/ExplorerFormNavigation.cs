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

using System.Collections.Generic;

namespace AccessBridgeExplorer {
  public class ExplorerFormNavigation : IExplorerFormNavigation {
    /// <summary>The current action, or "null" if the navigation stack is empty.</summary>
    private NavigationEntry _currentEntry;
    /// <summary>Stack of actions before <see cref="_currentEntry"/></summary>
    private readonly Stack<NavigationEntry> _backwardEntries = new Stack<NavigationEntry>();
    /// <summary>Stack of actions after <see cref="_currentEntry"/></summary>
    private readonly Stack<NavigationEntry> _forwardEntries = new Stack<NavigationEntry>();
    private int _navigationNesting;
    private int _version;

    public int Version {
      get {
        return _version;
      }
    }

    public bool ForwardAvailable {
      get { return _forwardEntries.Count > 0; }
    }

    public bool BackwardAvailable {
      get { return _backwardEntries.Count > 0; }
    }

    public IEnumerable<NavigationEntry> BackwardEntries {
      get { return _backwardEntries; }
    }

    public IEnumerable<NavigationEntry> ForwardEntries {
      get { return _forwardEntries; }
    }

    public void Clear() {
      if (_currentEntry == null)
        return;

      _backwardEntries.Clear();
      _forwardEntries.Clear();
      _currentEntry = null;
      _version++;
    }

    public void AddNavigationAction(NavigationEntry entry) {
      if (_navigationNesting >= 1)
        return;

      _forwardEntries.Clear();
      if (_currentEntry != null) {
        _backwardEntries.Push(_currentEntry);
      }
      _currentEntry = entry;
      _version++;
    }

    public void NavigateForward() {
      if (_navigationNesting >= 1)
        return;

      if (!ForwardAvailable)
        return;

      if (_currentEntry != null) {
        _backwardEntries.Push(_currentEntry);
      }
      _currentEntry = _forwardEntries.Pop();
      DoNavigateAction(_currentEntry);
      _version++;
    }

    public void NavigateBackward() {
      if (_navigationNesting >= 1)
        return;

      if (!BackwardAvailable)
        return;

      if (_currentEntry != null) {
        _forwardEntries.Push(_currentEntry);
      }
      _currentEntry = _backwardEntries.Pop();
      DoNavigateAction(_currentEntry);
      _version++;
    }

    public void NavigateTo(NavigationEntry entry) {
      if (_currentEntry == entry)
        return;

      if (_backwardEntries.Contains(entry)) {
        while(BackwardAvailable) {
          NavigateBackward();
          if (_currentEntry == entry)
            break;
        }
      }
      if (_forwardEntries.Contains(entry)) {
        while (ForwardAvailable) {
          NavigateForward();
          if (_currentEntry == entry)
            break;
        }
      }
    }

    private void DoNavigateAction(NavigationEntry entry) {
      _navigationNesting++;
      try {
        entry.Action();
      } finally {
        _navigationNesting--;
      }
    }
  }
}
