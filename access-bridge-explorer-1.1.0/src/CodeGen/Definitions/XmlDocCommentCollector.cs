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

using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace CodeGen.Definitions {
  public class XmlDocCommentCollector {
    public XDocument Document { get; set; }

    public XmlDocDefinition CreateMethodDefinition(MethodInfo methodInfo) {
      Debug.Assert(methodInfo.DeclaringType != null, "methodInfo.DeclaringType != null");
      var sb = new StringBuilder();
      sb.Append("M:");
      sb.Append(methodInfo.DeclaringType.FullName);
      sb.Append(".");
      sb.Append(methodInfo.Name);
      var parameters = methodInfo.GetParameters();
      if (parameters.Length > 0) {
        sb.Append("(");
        int index = 0;
        foreach (var p in parameters) {
          if (index > 0) {
            sb.Append(",");
          }
          index++;
          sb.Append(p.ParameterType.FullName);
        }
        sb.Append(")");
      }

      return CreateMemberDefinition(sb.ToString());
    }

    public XmlDocDefinition CreateEventDefinition(EventInfo eventInfo) {
      Debug.Assert(eventInfo.DeclaringType != null, "eventInfo.DeclaringType != null");
      var sb = new StringBuilder();
      sb.Append("E:");
      sb.Append(eventInfo.DeclaringType.FullName);
      sb.Append(".");
      sb.Append(eventInfo.Name);

      return CreateMemberDefinition(sb.ToString());
    }

    public XmlDocDefinition CreateMemberDefinition(string id) {
      Debug.Assert(Document.Root != null, "Document.Root != null");
      var element = Document.Root
        .Descendants("member")
        .Where(x => x.Attribute("name") != null && x.Attribute("name").Value == id)
        .FirstOrDefault();

      if (element == null)
        return null;

      var summary = element.Element("summary");
      return new XmlDocDefinition {
        Summary = summary != null ? summary.ToString() : ""
      };
    }
  }
}
