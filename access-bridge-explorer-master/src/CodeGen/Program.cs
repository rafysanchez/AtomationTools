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
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CodeGen {
  class Program {
    static void Main(string[] args) {
      var programLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
      Debug.Assert(programLocation != null, "programLocation != null");

      var path1 = Path.Combine(programLocation, @"..\..\..\WindowsAccessBridgeInterop\Generated.cs");
      if (args.Length >= 1) {
        path1 = Path.Combine(Environment.CurrentDirectory, args[0]);
      }
      var path2 = Path.Combine(programLocation, @"..\..\..\WindowsAccessBridgeInterop\Generated.Internal.cs");
      if (args.Length >= 2) {
        path2 = Path.Combine(Environment.CurrentDirectory, args[1]);
      }
      var path3 = Path.Combine(programLocation, @"..\..\..\WindowsAccessBridgeInterop\Generated.Internal.Legacy.cs");
      if (args.Length >= 3) {
        path3 = Path.Combine(Environment.CurrentDirectory, args[2]);
      }

      var codeGen = new CodeGen(new CodeGenOptions {
        PublicClassesOutputFileName = path1,
        InternalClassesOutputFileName = path2,
        InternalLegacyClassesOutputFileName = path3,
      });
      codeGen.Generate();
    }
  }
}
