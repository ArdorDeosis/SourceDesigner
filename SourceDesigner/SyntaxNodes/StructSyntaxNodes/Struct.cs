using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class Struct : SyntaxNodeBase
    {
        public Struct(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public StructModifier Modifiers { get; set; } = StructModifier.None;

        public List<ClassSyntax> Classes { get; } = new();
        public List<Struct> Structs { get; } = new();
        public List<RecordSyntaxNode> Records { get; } = new();
        public List<InterfaceSyntaxNode> Interfaces { get; } = new();
        public List<EnumSyntax> Enums { get; } = new();
        public List<Method> Methods { get; } = new();
        public List<FieldSyntax> Fields { get; } = new();
        public List<Property> Properties { get; } = new();

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}struct {Name}" +
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