using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class InterfaceSyntax : SyntaxNodeBase
    {
        public string Name { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public ClassModifier Modifiers { get; set; } = ClassModifier.None;

        public ClassSyntax[] Classes { get; init; } = Array.Empty<ClassSyntax>();
        public StructSyntax[] Structs { get; init; } = Array.Empty<StructSyntax>();
        public RecordSyntax[] Records { get; init; } = Array.Empty<RecordSyntax>();
        public InterfaceSyntax[] Interfaces { get; init; } = Array.Empty<InterfaceSyntax>();
        public EnumSyntax[] Enums { get; init; } = Array.Empty<EnumSyntax>();
        public Method[] Methods { get; init; } = Array.Empty<Method>();
        public Property[] Properties { get; init; } = Array.Empty<Property>();

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}interface {Name}" +
            $"{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetBodyCodeBlock(CodeStyle style)
        {
            List<string> members = new();
            members.AddRange(Interfaces.Select(member => member.ToCode(style)));
            members.AddRange(Classes.Select(member => member.ToCode(style)));
            members.AddRange(Records.Select(member => member.ToCode(style)));
            members.AddRange(Structs.Select(member => member.ToCode(style)));
            members.AddRange(Enums.Select(member => member.ToCode(style)));
            members.AddRange(Properties.Select(member => member.ToCode(style)));
            members.AddRange(Methods.Select(member => member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }
    }
}