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

namespace CodeGen.Interop {
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  public static class Constants {
    public const int MAX_STRING_SIZE = 1024;
    public const int SHORT_STRING_SIZE = 256;
    public const int MAX_RELATIONS = 5;
    public const int MAX_VISIBLE_CHILDREN = 256;
    public const int MAX_ACTION_INFO = 256;
    public const int MAX_ACTIONS_TO_DO = 32;
    public const int MAX_KEY_BINDINGS = 10;
    public const int MAX_ICON_INFO = 8;
    public const int MAX_RELATION_TARGETS = 25;
    public const int MAX_HYPERLINKS = 64; // maximum number of hyperlinks returned
  }
}