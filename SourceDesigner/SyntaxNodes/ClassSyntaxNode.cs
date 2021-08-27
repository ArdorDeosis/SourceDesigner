using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class ClassSyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public ClassModifier Modifiers { get; set; } = ClassModifier.None;

        public ClassSyntaxNode[] Classes { get; init; } = Array.Empty<ClassSyntaxNode>();
        public StructSyntaxNode[] Structs { get; init; } = Array.Empty<StructSyntaxNode>();
        public RecordSyntaxNode[] Records { get; init; } = Array.Empty<RecordSyntaxNode>();
        public InterfaceSyntaxNode[] Interfaces { get; init; } = Array.Empty<InterfaceSyntaxNode>();
        public EnumSyntaxNode[] Enums { get; init; } = Array.Empty<EnumSyntaxNode>();
        public MethodSyntaxNode[] Methods { get; init; } = Array.Empty<MethodSyntaxNode>();
        public FieldSyntaxNode[] Fields { get; init; } = Array.Empty<FieldSyntaxNode>();
        public PropertySyntaxNode[] Properties { get; init; } = Array.Empty<PropertySyntaxNode>();

        public override string ToCode(CodeStyle style)
        {
            // TODO: all the other members
            List<string> members = new();
            members.AddRange(Classes.Select(@class => Environment.NewLine + @class.ToCode(style).Indent(style)));
            members.AddRange(Methods.Select(method => Environment.NewLine + method.ToCode(style).Indent(style)));
            
            return $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().AddTrailingSpace()}class {Name}{Environment.NewLine}" +
                   $"{{{string.Join($"{Environment.NewLine}{Environment.NewLine}", members)}{Environment.NewLine}}}";
        }
    }
}