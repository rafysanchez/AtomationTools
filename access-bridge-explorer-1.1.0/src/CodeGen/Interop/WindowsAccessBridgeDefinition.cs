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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using CodeGen.Interop.NativeStructures;

namespace CodeGen.Interop {
  /// <summary>
  /// This interface defintion serves as the source defintion of the WindowsAccessBridge
  /// library definitions. It is used by the code generator to generate vaious interop
  /// classes, interfaces and utility methods.
  /// </summary>
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  public interface WindowsAccessBridgeDefinition {
    /// <summary>
    /// Initialization, needs to be called before any other entry point.
    /// </summary>
    void Windows_run();

    /// <summary>
    /// Returns <code>true</code> if the given window handle belongs to a Java
    /// application.
    /// </summary>
    bool IsJavaWindow(WindowHandle window);
    /// <summary>
    /// Returns <code>true</code> if both java object handles reference the same
    /// object. Note that the function may return <cdoe>false</cdoe> for
    /// tansient objects, e.g. for items of tables/list/trees.
    /// </summary>
    bool IsSameObject(int vmid, JavaObjectHandle obj1, JavaObjectHandle obj2);
    /// <summary>
    /// Retrieves the accessible context of the root component of a given window
    /// handle.
    /// </summary>
    StatusResult GetAccessibleContextFromHWND(WindowHandle window, out int vmid, out JavaObjectHandle ac);
    /// <summary>
    /// Returns the window handle corresponding to given root component
    /// accessible context.
    /// </summary>
    WindowHandle GetHWNDFromAccessibleContext(int vmid, JavaObjectHandle ac);

    /// <summary>
    /// Returns the deepest accessible context at screen location (x,y) using
    /// <paramref name="acParent"/> as the root of the search tree. The returned
    /// AccessibleContext <paramref name="ac"/> maybe be equal to <paramref
    /// name="acParent"/> in case there is no child at that location. Returns
    /// <code>false</code> in case of serious error.
    /// </summary>
    StatusResult GetAccessibleContextAt(int vmid, JavaObjectHandle acParent, int x, int y, out JavaObjectHandle ac);

    /// <summary>
    /// Retrieves the accessible context of the input focus component of the
    /// given window handle.
    /// </summary>
    StatusResult GetAccessibleContextWithFocus(WindowHandle window, out int vmid, out JavaObjectHandle ac);
    /// <summary>
    /// Retrieves the <see cref="AccessibleContextInfo"/> of the component
    /// corresponding to the given accessible context.
    /// </summary>
    StatusResult GetAccessibleContextInfo(int vmid, JavaObjectHandle ac, [Out] AccessibleContextInfo info);
    /// <summary>
    /// Returns the accessible context of the <paramref name="i"/>'th child of
    /// the component associated to <paramref name="ac"/>. Returns an
    /// <code>null</code> accessible context if there is no such child.
    /// </summary>
    JavaObjectHandle GetAccessibleChildFromContext(int vmid, JavaObjectHandle ac, int i);
    /// <summary>
    /// Returns the accessible context of the parent of the component associated
    /// to <paramref name="ac"/>. Returns an <code>null</code> accessible
    /// context if there is no parent.
    /// </summary>
    JavaObjectHandle GetAccessibleParentFromContext(int vmid, JavaObjectHandle ac);

    #region AccessibleRelationSet

    StatusResult GetAccessibleRelationSet(int vmid, JavaObjectHandle accessibleContext, out AccessibleRelationSetInfo relationSetInfo);

    #endregion

    #region AccessibleHypertext

    StatusResult GetAccessibleHypertext(int vmid, JavaObjectHandle accessibleContext, out AccessibleHypertextInfo hypertextInfo);
    bool ActivateAccessibleHyperlink(int vmid, JavaObjectHandle accessibleContext, JavaObjectHandle accessibleHyperlink);
    int GetAccessibleHyperlinkCount(int vmid, JavaObjectHandle accessibleContext);

    StatusResult GetAccessibleHypertextExt(
      int vmid,
      JavaObjectHandle accessibleContext,
      int nStartIndex,
      out AccessibleHypertextInfo hypertextInfo);

    int GetAccessibleHypertextLinkIndex(int vmid, JavaObjectHandle hypertext, int nIndex);

    StatusResult GetAccessibleHyperlink(
      int vmid,
      JavaObjectHandle hypertext,
      int nIndex,
      out AccessibleHyperlinkInfo hyperlinkInfo);

    #endregion

    #region Accessible KeyBindings, Icons and Actions

    StatusResult GetAccessibleKeyBindings(int vmid, JavaObjectHandle accessibleContext, out AccessibleKeyBindings keyBindings);
    StatusResult GetAccessibleIcons(int vmid, JavaObjectHandle accessibleContext, out AccessibleIcons icons);
    StatusResult GetAccessibleActions(int vmid, JavaObjectHandle accessibleContext, [Out] AccessibleActions actions);

    StatusResult DoAccessibleActions(
      int vmid,
      JavaObjectHandle accessibleContext,
      ref AccessibleActionsToDo actionsToDo,
      out int failure);

    #endregion

    #region AccessibleText

    StatusResult GetAccessibleTextInfo(int vmid, JavaObjectHandle at, out AccessibleTextInfo textInfo, int x, int y);
    StatusResult GetAccessibleTextItems(int vmid, JavaObjectHandle at, out AccessibleTextItemsInfo textItems, int index);
    StatusResult GetAccessibleTextSelectionInfo(int vmid, JavaObjectHandle at, out AccessibleTextSelectionInfo textSelection);
    StatusResult GetAccessibleTextAttributes(int vmid, JavaObjectHandle at, int index, [Out] AccessibleTextAttributesInfo attributes);

    StatusResult GetAccessibleTextRect(int vmid, JavaObjectHandle at, out AccessibleTextRectInfo rectInfo, int index);
    StatusResult GetAccessibleTextLineBounds(int vmid, JavaObjectHandle at, int index, out int startIndex, out int endIndex);
    StatusResult GetAccessibleTextRange(int vmid, JavaObjectHandle at, int start, int end, [Out] char[] text, short len);

    #endregion

    StatusResult GetCurrentAccessibleValueFromContext(int vmid, JavaObjectHandle av, StringBuilder value, short len);
    StatusResult GetMaximumAccessibleValueFromContext(int vmid, JavaObjectHandle av, StringBuilder value, short len);
    StatusResult GetMinimumAccessibleValueFromContext(int vmid, JavaObjectHandle av, StringBuilder value, short len);

    void AddAccessibleSelectionFromContext(int vmid, JavaObjectHandle asel, int i);
    void ClearAccessibleSelectionFromContext(int vmid, JavaObjectHandle asel);
    JavaObjectHandle GetAccessibleSelectionFromContext(int vmid, JavaObjectHandle asel, int i);
    int GetAccessibleSelectionCountFromContext(int vmid, JavaObjectHandle asel);
    bool IsAccessibleChildSelectedFromContext(int vmid, JavaObjectHandle asel, int i);
    void RemoveAccessibleSelectionFromContext(int vmid, JavaObjectHandle asel, int i);
    void SelectAllAccessibleSelectionFromContext(int vmid, JavaObjectHandle asel);

    #region AccessibleTable

    StatusResult GetAccessibleTableInfo(int vmid, JavaObjectHandle ac, [Out] AccessibleTableInfo tableInfo);
    StatusResult GetAccessibleTableCellInfo(int vmid, JavaObjectHandle at, int row, int column, [Out] AccessibleTableCellInfo tableCellInfo);
    StatusResult GetAccessibleTableRowHeader(int vmid, JavaObjectHandle acParent, [Out] AccessibleTableInfo tableInfo);
    StatusResult GetAccessibleTableColumnHeader(int vmid, JavaObjectHandle acParent, [Out] AccessibleTableInfo tableInfo);
    JavaObjectHandle GetAccessibleTableRowDescription(int vmid, JavaObjectHandle acParent, int row);
    JavaObjectHandle GetAccessibleTableColumnDescription(int vmid, JavaObjectHandle acParent, int column);
    int GetAccessibleTableRowSelectionCount(int vmid, JavaObjectHandle table);
    bool IsAccessibleTableRowSelected(int vmid, JavaObjectHandle table, int row);

    StatusResult GetAccessibleTableRowSelections(int vmid, JavaObjectHandle table, int count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] selections);

    int GetAccessibleTableColumnSelectionCount(int vmid, JavaObjectHandle table);
    bool IsAccessibleTableColumnSelected(int vmid, JavaObjectHandle table, int column);

    StatusResult GetAccessibleTableColumnSelections(int vmid, JavaObjectHandle table, int count, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] selections);

    /// <summary>
    /// Return the row number for a cell at a given index
    /// </summary>
    int GetAccessibleTableRow(int vmid, JavaObjectHandle table, int index);

    /// <summary>
    /// Return the column number for a cell at a given index
    /// </summary>
    int GetAccessibleTableColumn(int vmid, JavaObjectHandle table, int index);

    /// <summary>
    /// Return the index of a cell at a given row and column
    /// </summary>
    int GetAccessibleTableIndex(int vmid, JavaObjectHandle table, int row, int column);

    #endregion

    #region Additional utility methods

    StatusResult SetTextContents(int vmid, JavaObjectHandle ac, string text);
    JavaObjectHandle GetParentWithRole(int vmid, JavaObjectHandle ac, [MarshalAs(UnmanagedType.LPWStr)] string role);

    JavaObjectHandle GetParentWithRoleElseRoot(int vmid, JavaObjectHandle ac, [MarshalAs(UnmanagedType.LPWStr)] string role);

    JavaObjectHandle GetTopLevelObject(int vmid, JavaObjectHandle ac);
    int GetObjectDepth(int vmid, JavaObjectHandle ac);
    JavaObjectHandle GetActiveDescendent(int vmid, JavaObjectHandle ac);

    StatusResult GetVirtualAccessibleName(int vmid, JavaObjectHandle ac, StringBuilder name, int len);

    StatusResult GetTextAttributesInRange(int vmid, JavaObjectHandle accessibleContext, int startIndex, int endIndex, [Out] AccessibleTextAttributesInfo attributes, out short len);

    StatusResult GetCaretLocation(int vmid, JavaObjectHandle ac, out AccessibleTextRectInfo rectInfo, int index);

    int GetVisibleChildrenCount(int vmid, JavaObjectHandle accessibleContext);

    StatusResult GetVisibleChildren(int vmid, JavaObjectHandle accessibleContext, int startIndex, out VisibleChildrenInfo children);

    #endregion

    StatusResult GetVersionInfo(int vmid, out AccessBridgeVersionInfo info);

    #region Event handling routines

    /// <summary>
    /// Unused.
    /// </summary>
    event PropertyChangeEventHandler PropertyChange;

    /// <summary>
    /// Occurs when a JVM has shutdown.
    /// </summary>
    event JavaShutdownEventHandler JavaShutdown;

    /// <summary>
    /// Occurs when an accessible component has gained the input focus.
    /// </summary>
    event FocusGainedEventHandler FocusGained;
    /// <summary>
    /// Occurs when an accessible component has lost the input focus.
    /// </summary>
    event FocusLostEventHandler FocusLost;

    /// <summary>
    /// Occurs when the caret location inside an accessible text component has changed.
    /// </summary>
    event CaretUpdateEventHandler CaretUpdate;

    /// <summary>
    /// Occurs when the mouse button has been clicked on an accessible component.
    /// </summary>
    event MouseClickedEventHandler MouseClicked;
    /// <summary>
    /// Occurs when the mouse cursor has moved over the region of an accessible component.
    /// </summary>
    event MouseEnteredEventHandler MouseEntered;
    /// <summary>
    /// Occurs when the mouse cursor has exited the region of an accessible component.
    /// </summary>
    event MouseExitedEventHandler MouseExited;
    /// <summary>
    /// Occurs when the mouse button has been pressed of an accessible component.
    /// </summary>
    event MousePressedEventHandler MousePressed;
    /// <summary>
    /// Occurs when the mouse button has been released of an accessible component.
    /// </summary>
    event MouseReleasedEventHandler MouseReleased;

    event MenuCanceledEventHandler MenuCanceled;
    event MenuDeselectedEventHandler MenuDeselected;
    event MenuSelectedEventHandler MenuSelected;
    event PopupMenuCanceledEventHandler PopupMenuCanceled;
    event PopupMenuWillBecomeInvisibleEventHandler PopupMenuWillBecomeInvisible;
    event PopupMenuWillBecomeVisibleEventHandler PopupMenuWillBecomeVisible;

    event PropertyNameChangeEventHandler PropertyNameChange;
    event PropertyDescriptionChangeEventHandler PropertyDescriptionChange;
    event PropertyStateChangeEventHandler PropertyStateChange;
    event PropertyValueChangeEventHandler PropertyValueChange;
    event PropertySelectionChangeEventHandler PropertySelectionChange;
    event PropertyTextChangeEventHandler PropertyTextChange;
    event PropertyCaretChangeEventHandler PropertyCaretChange;
    event PropertyVisibleDataChangeEventHandler PropertyVisibleDataChange;
    event PropertyChildChangeEventHandler PropertyChildChange;
    /// <summary>
    /// Occurs the active/selected item of a tree/list/table has changed.
    /// </summary>
    event PropertyActiveDescendentChangeEventHandler PropertyActiveDescendentChange;

    event PropertyTableModelChangeEventHandler PropertyTableModelChange;

    #endregion
  }

  #region Managed Event Handlers Delegate Definitions

  public delegate void PropertyChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    [MarshalAs(UnmanagedType.LPWStr)] string property,
    [MarshalAs(UnmanagedType.LPWStr)] string oldValue,
    [MarshalAs(UnmanagedType.LPWStr)] string newValue);

  public delegate void JavaShutdownEventHandler(int vmid);

  public delegate void FocusGainedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void FocusLostEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void CaretUpdateEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void MouseClickedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void MouseEnteredEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void MouseExitedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void MousePressedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void MouseReleasedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void MenuCanceledEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void MenuDeselectedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void MenuSelectedEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void PopupMenuCanceledEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void PopupMenuWillBecomeInvisibleEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);
  public delegate void PopupMenuWillBecomeVisibleEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void PropertyNameChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    [MarshalAs(UnmanagedType.LPWStr)] string oldName,
    [MarshalAs(UnmanagedType.LPWStr)] string newName);

  public delegate void PropertyDescriptionChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    [MarshalAs(UnmanagedType.LPWStr)] string oldDescription,
    [MarshalAs(UnmanagedType.LPWStr)] string newDescription);

  public delegate void PropertyStateChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    [MarshalAs(UnmanagedType.LPWStr)] string oldState,
    [MarshalAs(UnmanagedType.LPWStr)] string newState);

  public delegate void PropertyValueChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    [MarshalAs(UnmanagedType.LPWStr)] string oldValue,
    [MarshalAs(UnmanagedType.LPWStr)] string newValue);

  public delegate void PropertySelectionChangeEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void PropertyTextChangeEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void PropertyCaretChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    int oldPosition,
    int newPosition);

  public delegate void PropertyVisibleDataChangeEventHandler(int vmid, JavaObjectHandle evt, JavaObjectHandle source);

  public delegate void PropertyChildChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    JavaObjectHandle oldChild,
    JavaObjectHandle newChild);

  public delegate void PropertyActiveDescendentChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle source,
    JavaObjectHandle oldActiveDescendent,
    JavaObjectHandle newActiveDescendent);

  public delegate void PropertyTableModelChangeEventHandler(
    int vmid,
    JavaObjectHandle evt,
    JavaObjectHandle src,
    [MarshalAs(UnmanagedType.LPWStr)] string oldValue,
    [MarshalAs(UnmanagedType.LPWStr)] string newValue);
  #endregion
}