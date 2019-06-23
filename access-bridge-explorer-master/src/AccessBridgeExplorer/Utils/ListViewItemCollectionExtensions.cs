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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccessBridgeExplorer.Utils {
  public static class ListViewItemCollectionExtensions {
    /// <summary>
    /// Wraps a <see cref="ListView.ListViewItemCollection"/> as an <see
    /// cref="IList{ListViewItem}"/>.
    /// </summary>
    public static IList<ListViewItem> AsList(this ListView.ListViewItemCollection collection) {
      return new ListViewItemCollectionWrapper(collection);
    }

    public class ListViewItemCollectionWrapper : IList<ListViewItem> {
      private readonly ListView.ListViewItemCollection _collection;

      public ListViewItemCollectionWrapper(ListView.ListViewItemCollection collection) {
        _collection = collection;
      }

      public IEnumerator<ListViewItem> GetEnumerator() {
        return _collection.Cast<ListViewItem>().GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
      }

      public void Add(ListViewItem item) {
        _collection.Add(item);
      }

      public void Clear() {
        _collection.Clear();
      }

      public bool Contains(ListViewItem item) {
        return _collection.Contains(item);
      }

      public void CopyTo(ListViewItem[] array, int arrayIndex) {
        _collection.CopyTo(array, arrayIndex);
      }

      public bool Remove(ListViewItem item) {
        _collection.Remove(item);
        return true;
      }

      public int Count {
        get { return _collection.Count; }
      }

      public bool IsReadOnly {
        get { return _collection.IsReadOnly; }
      }

      public int IndexOf(ListViewItem item) {
        return _collection.IndexOf(item);
      }

      public void Insert(int index, ListViewItem item) {
        _collection.Insert(index, item);
      }

      public void RemoveAt(int index) {
        _collection.RemoveAt(index);
      }

      public ListViewItem this[int index] {
        get { return _collection[index]; }
        set { _collection[index] = value; }
      }
    }
  }
}