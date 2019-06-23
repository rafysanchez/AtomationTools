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

using System;
using System.Collections.Generic;
using System.Reflection;

namespace AccessBridgeExplorer.Utils.Settings {
  public class WeakDelegateList<T> where T : class {
    private readonly LinkedList<Entry> _handlers = new LinkedList<Entry>();

    public WeakDelegateList() {
      if (!IsDelegateType(typeof(T))) {
        throw new ArgumentException("Type must be a delegate type.");
      }
    }

    public void ForEach(Action<T> action) {
      foreach (var node in GetListNodes()) {
        var handler = node.Value.Handler;
        if (handler != null) {
          action(handler);
        } else {
          _handlers.Remove(node);
        }
      }
    }

    public void Add(T handler) {
      AddDelegate((Delegate)(object)handler);
    }

    public void Remove(T handler) {
      RemoveDelegate((Delegate)(object)handler);
    }

    private void AddDelegate(Delegate handler) {
      if (handler == null)
        throw new ArgumentNullException("handler");
      // Insert in first position, so that a paired "remove" call would remove
      // the instance just added.
      _handlers.AddFirst(new Entry(handler.Target, handler.Method));
    }

    private void RemoveDelegate(Delegate handler) {
      foreach (var node in GetListNodes()) {
        if (node.Value.IsSameDelegate(handler)) {
          _handlers.Remove(node);
          break;
        }
      }
    }

    private IEnumerable<LinkedListNode<Entry>> GetListNodes() {
      var node = _handlers.First;
      while (node != null) {
        // Keep "next" around in case the returned node is removed from the
        // collection
        var next = node.Next;
        yield return node;
        node = next;
      }
    }

    private static bool IsDelegateType(Type type) {
      return typeof(Delegate).IsAssignableFrom(type);
    }

    private struct Entry {
      private readonly WeakReference _targetWeakRef;
      private readonly MethodInfo _method;

      public Entry(object target, MethodInfo method) {
        _targetWeakRef = (target == null ? null : new WeakReference(target));
        _method = method;
      }

      private object Target {
        get {
          return _targetWeakRef == null ? null : _targetWeakRef.Target;
        }
      }

      public bool IsSameDelegate(Delegate handler) {
        return ReferenceEquals(Target, handler.Target) &&
          Equals(_method, handler.Method);
      }

      public T Handler {
        get {
          if (_targetWeakRef == null) {
            return (T)(object)Delegate.CreateDelegate(typeof(T), null, _method);
          } else {
            var target = _targetWeakRef.Target;
            if (target == null)
              return null;
            return (T)(object)Delegate.CreateDelegate(typeof(T), target, _method);
          }
        }
      }
    }
  }
}