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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using jint = System.Int32;

namespace CodeGen.Interop.NativeStructures {
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class AccessibleContextInfo {

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.MAX_STRING_SIZE)]
    public string name;          // the AccessibleName of the object
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.MAX_STRING_SIZE)]
    public string description;   // the AccessibleDescription of the object

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string role;        // localized AccesibleRole string
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string role_en_US;  // AccesibleRole string in the en_US locale
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string states;      // localized AccesibleStateSet string (comma separated)
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string states_en_US; // AccesibleStateSet string in the en_US locale (comma separated)

    public jint indexInParent;                     // index of object in parent
    public jint childrenCount;                     // # of children, if any

    public jint x;                                 // screen coords in pixels
    public jint y;                                 // "
    public jint width;                             // pixel width of object
    public jint height;                            // pixel height of object

    public jint accessibleComponent;               // flags for various additional
    public jint accessibleAction;                  //  Java Accessibility interfaces
    public jint accessibleSelection;               //  FALSE if this object doesn't
    public jint accessibleText;                    //  implement the additional interface
    //  in question

    // BOOL accessibleValue;                // old BOOL indicating whether AccessibleValue is supported
    public AccessibleInterfaces accessibleInterfaces;              // new bitfield containing additional interface flags
  }
}
