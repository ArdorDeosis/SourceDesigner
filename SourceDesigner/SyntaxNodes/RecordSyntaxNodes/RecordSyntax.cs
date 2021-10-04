using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class RecordSyntax : SyntaxNodeBase
    {
        public RecordSyntax(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public RecordModifier Modifiers { get; set; } = RecordModifier.None;

        public List<ClassSyntax> Classes { get; init; } = new();
        public List<StructSyntax> Structs { get; init; } = new();
        public List<RecordSyntax> Records { get; init; } = new();
        public List<InterfaceSyntax> Interfaces { get; init; } = new();
        public List<EnumSyntax> Enums { get; init; } = new();
        public List<Method> Methods { get; init; } = new();
        public List<FieldSyntax> Fields { get; init; } = new();
        public List<Property> Properties { get; init; } = new();

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}record {Name}" +
            $"{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetBodyCodeBlock(CodeStyle style)
        {
            List<string> members = new();
            members.AddRange(Interfaces.Select(member => member.ToCode(style)));
            members.AddRange(Classes.Select(member => member.ToCode(style)));
            members.AddRange(Records.Select(member => member.ToCode(style)));
            members.AddRange(Structs.Select(member => member.ToCode(style)));
            members.AddRange(Enums.Select(member => member.ToCode(style)));
            members.AddRange(Fields.Select(member => member.ToCode(style)));
            members.AddRange(Properties.Select(member => member.ToCode(style)));
            members.AddRange(Methods.Select(member => member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }
    }
}