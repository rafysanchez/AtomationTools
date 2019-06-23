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
using System.Diagnostics.CodeAnalysis;

namespace CodeGen.Interop.NativeStructures {
  [Flags]
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  public enum AccessibleInterfaces {
    cAccessibleValueInterface = 1, // 1 << 1 (TRUE)
    cAccessibleActionInterface = 2, // 1 << 2
    cAccessibleComponentInterface = 4, // 1 << 3
    cAccessibleSelectionInterface = 8, // 1 << 4
    cAccessibleTableInterface = 16, // 1 << 5
    cAccessibleTextInterface = 32, // 1 << 6
    cAccessibleHypertextInterface = 64 // 1 << 7
  }
}