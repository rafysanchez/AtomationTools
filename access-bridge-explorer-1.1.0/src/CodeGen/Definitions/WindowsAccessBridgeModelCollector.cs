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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using CodeGen.Interop.NativeStructures;
using WindowsAccessBridgeDefinition = CodeGen.Interop.WindowsAccessBridgeDefinition;

namespace CodeGen.Definitions {
  public class WindowsAccessBridgeModelCollector {
    private XmlDocCommentCollector _xmlDoc;

    public WindowsAccessBridgeModel CollectModel() {
      var model = new WindowsAccessBridgeModel();
      _xmlDoc = OpenXmlDocComment();
      CollectFunctions(model);
      CollectEvents(model);
      CollectEnums(model);
      CollectStructs(model);
      CollectClasses(model);
      return model;
    }

    private XmlDocCommentCollector OpenXmlDocComment() {
      var type = typeof (WindowsAccessBridgeDefinition);
      var path = type.Assembly.Location;
      var xmlDocFile = Path.ChangeExtension(path, ".xml");
      using (var file = File.OpenRead(xmlDocFile)) {
        var doc = XDocument.Load(file);
        var result = new XmlDocCommentCollector();
        result.Document = doc;
        return result;
      }
    }

    private void CollectFunctions(WindowsAccessBridgeModel model) {
      var type = typeof(WindowsAccessBridgeDefinition);
      var functions = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
      model.Functions.AddRange(functions.Where(f => !f.IsSpecialName).OrderBy(f => f.Name).Select(f => CollectFunction(f)));
    }

    private void CollectEvents(WindowsAccessBridgeModel model) {
      var type = typeof(WindowsAccessBridgeDefinition);
      var events = type.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
      model.Events.AddRange(events.OrderBy(f => f.Name).Select(x => CollectEvent(x)));
    }

    private void CollectEnums(WindowsAccessBridgeModel model) {
      var sampleType = typeof(AccessibleKeyCode);
      var types = typeof(WindowsAccessBridgeDefinition).Assembly.GetExportedTypes()
        .Where(t => t.Namespace == sampleType.Namespace)
        .Where(t => t.IsValueType && t.IsEnum);
      model.Enums.AddRange(types.OrderBy(f => f.Name).Select(t => CollectEnum(t)));
    }

    private void CollectStructs(WindowsAccessBridgeModel model) {
      var sampleStruct = typeof(AccessibleContextInfo);
      var types = typeof(WindowsAccessBridgeDefinition).Assembly.GetExportedTypes()
        .Where(t => t.Namespace == sampleStruct.Namespace)
        .Where(t => t.IsValueType && !t.IsEnum);
      model.Structs.AddRange(types.OrderBy(f => f.Name).Select(t => CollectStruct(t)));
    }

    private void CollectClasses(WindowsAccessBridgeModel model) {
      var sampleStruct = typeof(AccessibleContextInfo);
      var types = typeof(WindowsAccessBridgeDefinition).Assembly.GetExportedTypes()
        .Where(t => t.Namespace == sampleStruct.Namespace)
        .Where(t => t.IsClass);
      model.Classes.AddRange(types.OrderBy(f => f.Name).Select(t => CollectClass(t)));
    }

    private StructDefinition CollectStruct(Type type) {
      return new StructDefinition {
        Name = type.Name,
        Fields = CollectFields(type).ToList(),
      };
    }

    private EnumDefinition CollectEnum(Type type) {
      return new EnumDefinition {
        Name = type.Name,
        IsFlags = type.GetCustomAttributes(typeof(FlagsAttribute), false).Any(),
        Type = (NameTypeReference)ConvertType(type.GetEnumUnderlyingType()),
        Members = CollectEnumMembers(type).ToList(),
      };
    }

    private ClassDefinition CollectClass(Type type) {
      return new ClassDefinition {
        Name = type.Name,
        Fields = CollectFields(type).ToList(),
      };
    }

    private IEnumerable<FieldDefinition> CollectFields(Type type) {
      return type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
        .Select(x => new FieldDefinition {
          Name = x.Name,
          Type = ConvertType(x, x.FieldType),
          MarshalAs = ConvertMashalAs(x)
        });
    }

    private IEnumerable<EnumMemberDefinition> CollectEnumMembers(Type type) {
      return type.GetFields(BindingFlags.Public | BindingFlags.Static)
        .Select(x => new EnumMemberDefinition {
          Name = x.Name,
          Value = x.GetRawConstantValue().ToString()
          //Type = ConvertType(x.FieldType)
        });
    }

    private FunctionDefinition CollectFunction(MethodInfo methodInfo) {
      return new FunctionDefinition {
        Name = methodInfo.Name,
        ReturnType = ConvertType(methodInfo.ReturnType),
        Parameters = CollectParameters(methodInfo.GetParameters()).ToList(),
        XmlDocDefinition = _xmlDoc.CreateMethodDefinition(methodInfo)
      };
    }

    private FunctionDefinition CollectDelegateType(Type delegateType) {
      var methodInfo = delegateType.GetMethod("Invoke");
      return new FunctionDefinition {
        Name = delegateType.Name,
        ReturnType = ConvertType(methodInfo.ReturnType),
        Parameters = CollectParameters(methodInfo.GetParameters()).ToList(),
        MarshalAs = ConvertMashalAs(delegateType)
      };
    }

    private EventDefinition CollectEvent(EventInfo eventInfo) {
      return new EventDefinition {
        Name = eventInfo.Name,
        Type = ConvertType(eventInfo.EventHandlerType),
        DelegateFunction = CollectDelegateType(eventInfo.EventHandlerType),
        XmlDocDefinition = _xmlDoc.CreateEventDefinition(eventInfo)
      };
    }

    private IEnumerable<ParameterDefinition> CollectParameters(ParameterInfo[] parameters) {
      foreach (var p in parameters) {
        yield return new ParameterDefinition {
          Name = p.Name,
          Type = ConvertType(p.ParameterType),
          MarshalAs = ConvertMashalAs(p),
          IsOutAttribute = !p.ParameterType.IsByRef && p.IsOut,
          IsOut = p.ParameterType.IsByRef && p.IsOut,
          IsRef = p.ParameterType.IsByRef && !p.IsOut,
        };
      }
    }

    private MarshalAsAttribute ConvertMashalAs(ICustomAttributeProvider provider) {
      return (MarshalAsAttribute)provider.GetCustomAttributes(typeof(MarshalAsAttribute), false).FirstOrDefault();
    }

    private TypeReference ConvertType(Type type) {
      return ConvertType(null, type);
    }

    private TypeReference ConvertType(FieldInfo field, Type type) {
      if (type.IsByRef)
        type = type.GetElementType();

      var name = type.Name;
      if (type == typeof(void))
        name = "void";
      else if (type == typeof(bool))
        name = "bool";
      else if (type == typeof(string))
        name = "string";
      else if (type == typeof(float))
        name = "float";
      else if (type == typeof(double))
        name = "double";
      else if (type == typeof(int))
        name = "int";
      else if (type == typeof(short))
        name = "short";
      else if (type == typeof(long))
        name = "long";
      else if (type == typeof(uint))
        name = "uint";
      else if (type == typeof(ushort))
        name = "ushort";
      else if (type == typeof(ulong))
        name = "ulong";
      else if (type == typeof(byte))
        name = "byte";
      else if (type == typeof(char))
        name = "char";

      if (type.IsArray) {
        return new ArrayTypeReference {
          ElementType = ConvertType(type.GetElementType()),
          ElementCountAttribute = field == null ? null : (ElementCountAttribute)field.GetCustomAttributes(typeof(ElementCountAttribute), false).FirstOrDefault()
        };
      }

      return new NameTypeReference { Name = name };
    }
  }
}