using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class StructSyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public StructModifier Modifiers { get; set; } = StructModifier.None;

        public ClassSyntaxNode[] Classes { get; init; } = Array.Empty<ClassSyntaxNode>();
        public StructSyntaxNode[] Structs { get; init; } = Array.Empty<StructSyntaxNode>();
        public RecordSyntaxNode[] Records { get; init; } = Array.Empty<RecordSyntaxNode>();
        public InterfaceSyntaxNode[] Interfaces { get; init; } = Array.Empty<InterfaceSyntaxNode>();
        public EnumSyntaxNode[] Enums { get; init; } = Array.Empty<EnumSyntaxNode>();
        public MethodSyntaxNode[] Methods { get; init; } = Array.Empty<MethodSyntaxNode>();
        public FieldSyntaxNode[] Fields { get; init; } = Array.Empty<FieldSyntaxNode>();
        public PropertySyntaxNode[] Properties { get; init; } = Array.Empty<PropertySyntaxNode>();

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}class {Name}{Environment.NewLine}" +
            $"{{{string.Join($"{Environment.NewLine}{Environment.NewLine}", GetMembersAsCode(style)).Indent(style)}{Environment.NewLine}}}";

        private IEnumerable<string> GetMembersAsCode(CodeStyle style)
        {
            List<string> members = new();
            members.AddRange(Interfaces.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Classes.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Records.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Structs.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Enums.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Fields.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Properties.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Methods.Select(member => Environment.NewLine + member.ToCode(style)));
            return members;
        }
    }
}