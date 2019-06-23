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

namespace CodeGen {
  public class ElementCountAttribute : Attribute {
    private readonly string _fieldName;

    public ElementCountAttribute(string fieldName) {
      _fieldName = fieldName;
    }

    public string FieldName {
      get { return _fieldName; }
    }
  }
}
