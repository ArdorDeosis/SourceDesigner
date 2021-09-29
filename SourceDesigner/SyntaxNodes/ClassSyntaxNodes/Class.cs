using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
    public class Class : SyntaxNodeBase
    {
        public string? Name { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public ClassModifier Modifiers { get; set; } = ClassModifier.None;

        public List<Class> Classes { get; init; } = new();
        public List<StructSyntaxNode> Structs { get; init; } = new();
        public List<RecordSyntaxNode> Records { get; init; } = new();
        public List<InterfaceSyntaxNode> Interfaces { get; init; } = new();
        public List<EnumSyntaxNode> Enums { get; init; } = new();
        public List<Method> Methods { get; init; } = new();
        public List<FieldSyntaxNode> Fields { get; init; } = new();
        public List<PropertySyntaxNode> Properties { get; init; } = new();
        
        public Class()
        {
        }
        
        public Class(string? name)
        {
            Name = name;
        }

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}class {Name}{Environment.NewLine}" +
            GetBodyCodeBlock(style).WrapInBracesAndIndent(style);

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