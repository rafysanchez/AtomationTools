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
using jfloat = System.Single;
using BOOL = System.Int32;

namespace CodeGen.Interop.NativeStructures {
  // standard attributes for text; note: tabstops are not supported
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class AccessibleTextAttributesInfo {
    public BOOL bold;
    public BOOL italic;
    public BOOL underline;
    public BOOL strikethrough;
    public BOOL superscript;
    public BOOL subscript;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string backgroundColor;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string foregroundColor;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.SHORT_STRING_SIZE)]
    public string fontFamily;
    public jint fontSize;

    public jint alignment;
    public jint bidiLevel;

    public jfloat firstLineIndent;
    public jfloat leftIndent;
    public jfloat rightIndent;
    public jfloat lineSpacing;
    public jfloat spaceAbove;
    public jfloat spaceBelow;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.MAX_STRING_SIZE)]
    public string fullAttributesString;
  }
}
