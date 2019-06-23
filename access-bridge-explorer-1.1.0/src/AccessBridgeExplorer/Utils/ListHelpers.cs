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

using System.Collections.Generic;

namespace AccessBridgeExplorer.Utils {
  public abstract class IncrementalUpdateOperations<TSource, TNew> {
    /// <summary>
    /// Find the index of the element of <paramref name="items"/> associated to
    /// <paramref name="newItem"/>, starting the search at <paramref
    /// name="startIndex"/>. Returns <code>-1</code> if not found.
    /// </summary>
    public abstract int FindItem(IList<TSource> items, int startIndex, TNew newItem);

    /// <summary>
    /// Insert <paramref name="newItem"/> at <paramref name="index"/> in
    /// <paramref name="items"/>. It is assumed that <paramref name="items"/> is
    /// actually updated with a new element at <paramref name="index"/>.
    /// </summary>
    public abstract void InsertItem(IList<TSource> items, int index, TNew newItem);

    /// <summary>
    /// Update the element of <paramref name="items"/> at <paramref name="index"/>
    /// with <paramref name="newItem"/>. It is assumed that <paramref name="items"/>
    /// retains the same number of elements.
    /// </summary>
    public abstract void UpdateItem(IList<TSource> items, int index, TNew newItem);

    public virtual void RemoveItem(IList<TSource> items, int index) {
      items.RemoveAt(index);
    }
  }

  public static class ListHelpers {
    /// <summary>
    /// Update the <paramref name="items"/> list incrementally by
    /// adding/removing/updating elements so that it ends up being equivalent to
    /// <paramref name="newItems"/>. It is assumed that the elements of
    /// <paramref name="items"/> and <paramref name="newItems"/> are always
    /// deterministically ordered.
    /// </summary>
    public static void IncrementalUpdate<TSource, TNew>(IList<TSource> items, IList<TNew> newItems, IncrementalUpdateOperations<TSource, TNew> operations) {
      // The insertion position in "oldItems". Elements located *before* |oldInsertionIndex|
      // in "oldItems" have been processed and won't be touched anymore.
      var oldInsertionIndex = 0;

      // We go through each item in the new list and decide what to do in the
      // existing list of items currently displayed. If there are additional
      // nodes in the new list, we insert them in the existing list. If there
      // are missing nodes in the new list we delete them from the existing
      // list.
      for (var newIndex = 0; newIndex < newItems.Count; newIndex++) {
        var newItem = newItems[newIndex];

        // Find item with same tag in old list.
        var oldItemIndex = operations.FindItem(items, oldInsertionIndex, newItem);
        if (oldItemIndex < 0) {
          // If this is a new node (existing node not found), insert new list
          // view item at current insertion location (at end or in middle)

          operations.InsertItem(items, oldInsertionIndex, newItem);
          oldInsertionIndex++;
        } else {
          // If we found an equivalent node in the existing list, delete
          // existing items in between if needed, then update the existing
          // item with the updated values.

          // Delete items in range [oldIndex, oldItemIndex[
          for (var i = oldInsertionIndex; i < oldItemIndex; i++) {
            operations.RemoveItem(items, oldInsertionIndex);
          }
          oldItemIndex = oldInsertionIndex;

          // Update existing item with new property data
          operations.UpdateItem(items, oldItemIndex, newItem);
          oldInsertionIndex++;
        }
      }

      // Delete all the existing items that don't exist anymore, since we
      // reached the end of the new list.
      while (oldInsertionIndex < items.Count) {
        operations.RemoveItem(items, oldInsertionIndex);
      }
    }
  }
}