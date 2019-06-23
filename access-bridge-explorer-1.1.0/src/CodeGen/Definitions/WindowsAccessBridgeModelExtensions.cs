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
using System.Linq;
using CodeGen.Interop;

namespace CodeGen.Definitions {
  public static class WindowsAccessBridgeModelExtensions { 
    /// <summary>
    /// Returns <code>true</code> if <paramref name="name"/> is the name of a
    /// known struct definition.
    /// </summary>
    public static bool IsStructName(this WindowsAccessBridgeModel model, string name) {
      return model.Structs.Any(c => c.Name == name);
    }

    /// <summary>
    /// Returns <code>true</code> if <paramref name="name"/> is the name of a
    /// known class definition.
    /// </summary>
    public static bool IsClassName(this WindowsAccessBridgeModel model, string name) {
      return model.Classes.Any(c => c.Name == name);
    }

    /// <summary>
    /// Returns <code>true</code> if the <see cref="TypeReference"/> <paramref
    /// name="type"/> is a direct reference to a struct.
    /// </summary>
    public static bool IsStruct(this WindowsAccessBridgeModel model, TypeReference type) {
      var name = type as NameTypeReference;
      if (name == null)
        return false;
      return model.IsStructName(name.Name);
    }

    /// <summary>
    /// Returns <code>true</code> if the <see cref="TypeReference"/> <paramref
    /// name="type"/> is a direct reference to a class.
    /// </summary>
    public static bool IsClass(this WindowsAccessBridgeModel model, TypeReference type) {
      var name = type as NameTypeReference;
      if (name == null)
        return false;
      return model.IsClassName(name.Name);
    }

    /// <summary>
    /// Returns <code>true</code> if the <code>struct</code> named <paramref
    /// name="name"/> requires a wrapper struct definition for P/Invoke calls,
    /// or <code>false</code> if it can be used directly.
    /// </summary>
    public static bool StructNameNeedsWrapper(this WindowsAccessBridgeModel model, string name) {
      var definition = model.Structs.FirstOrDefault(x => x.Name == name);
      return definition == null ? false : model.StructNeedsWrapper(definition);
    }

    /// <summary>
    /// Returns <code>true</code> if the <code>class</code> named <paramref
    /// name="name"/> requires a wrapper struct definition for P/Invoke calls,
    /// or <code>false</code> if it can be used directly.
    /// </summary>
    public static bool ClassNameNeedsWrapper(this WindowsAccessBridgeModel model, string name) {
      var definition = model.Classes.FirstOrDefault(x => x.Name == name);
      return definition == null ? false : model.ClassNeedsWrapper(definition);
    }

    /// <summary>
    /// Returns <code>true</code> if the <code>struct</code> <paramref
    /// name="definition"/> requires a wrapper struct definition for P/Invoke
    /// calls, or <code>false</code> if it can be used directly.
    /// </summary>
    public static bool StructNeedsWrapper(this WindowsAccessBridgeModel model, StructDefinition definition) {
      return model.TypeDefinitionNeedsWrapper(definition);
    }

    /// <summary>
    /// Returns <code>true</code> if the <code>class</code> <paramref
    /// name="definition"/> requires a wrapper class definition for P/Invoke
    /// calls, or <code>false</code> if it can be used directly.
    /// </summary>
    public static bool ClassNeedsWrapper(this WindowsAccessBridgeModel model, ClassDefinition definition) {
      return model.TypeDefinitionNeedsWrapper(definition);
    }

    /// <summary>
    /// Returns <code>true</code> if the <see cref="TypeDefinition"/> <paramref
    /// name="definition"/> requires a wrapper definition for P/Invoke calls, or
    /// <code>false</code> if it can be used directly.
    /// </summary>
    public static bool TypeDefinitionNeedsWrapper(this WindowsAccessBridgeModel model, TypeDefinition definition) {
      return definition.Fields.Any(field => model.TypeReferenceNeedsWrapper(field.Type));
    }

    /// <summary>
    /// Returns <code>true</code> if the <see cref="TypeReference"/> <paramref
    /// name="reference"/> requires a wrapper definition for P/Invoke calls, or
    /// <code>false</code> if it can be used directly.
    /// </summary>
    public static bool TypeReferenceNeedsWrapper(this WindowsAccessBridgeModel model, TypeReference reference) {
      if (reference is NameTypeReference) {
        return model.NameTypeReferenceNeedsWrapper((NameTypeReference)reference);
      } else if (reference is ArrayTypeReference) {
        return model.TypeReferenceNeedsWrapper(((ArrayTypeReference)reference).ElementType);
      } else {
        throw new InvalidOperationException("Unknown type reference type");
      }
    }

    private static bool NameTypeReferenceNeedsWrapper(this WindowsAccessBridgeModel model, NameTypeReference reference) {
      var name = reference.Name;
      if (name == typeof (JavaObjectHandle).Name)
        return true;

      if (model.Classes.Any(c => c.Name == reference.Name && model.ClassNeedsWrapper(c)))
        return true;

      if (model.Structs.Any(c => c.Name == reference.Name && model.StructNeedsWrapper(c)))
        return true;

      return false;
    }
  }
}