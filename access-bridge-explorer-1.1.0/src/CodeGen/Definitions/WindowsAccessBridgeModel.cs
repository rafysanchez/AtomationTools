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

namespace CodeGen.Definitions {
  public class WindowsAccessBridgeModel {
    private readonly List<FunctionDefinition> _functions = new List<FunctionDefinition>();
    private readonly List<EventDefinition> _events = new List<EventDefinition>();
    private readonly List<EnumDefinition> _enums = new List<EnumDefinition>();
    private readonly List<StructDefinition> _structs = new List<StructDefinition>();
    private readonly List<ClassDefinition> _classes = new List<ClassDefinition>();

    public List<FunctionDefinition> Functions {
      get { return _functions; }
    }

    public List<EventDefinition> Events {
      get { return _events; }
    }

    public List<EnumDefinition> Enums {
      get { return _enums; }
    }

    public List<StructDefinition> Structs {
      get { return _structs; }
    }

    public List<ClassDefinition> Classes {
      get { return _classes; }
    }
  }
}