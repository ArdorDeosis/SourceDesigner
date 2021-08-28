﻿using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class InterfaceSyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public ClassModifier Modifiers { get; set; } = ClassModifier.None;

        public ClassSyntaxNode[] Classes { get; init; } = Array.Empty<ClassSyntaxNode>();
        public StructSyntaxNode[] Structs { get; init; } = Array.Empty<StructSyntaxNode>();
        public RecordSyntaxNode[] Records { get; init; } = Array.Empty<RecordSyntaxNode>();
        public InterfaceSyntaxNode[] Interfaces { get; init; } = Array.Empty<InterfaceSyntaxNode>();
        public EnumSyntaxNode[] Enums { get; init; } = Array.Empty<EnumSyntaxNode>();
        // TODO: methods and properties only without implementation (?)
        public MethodSyntaxNode[] Methods { get; init; } = Array.Empty<MethodSyntaxNode>();
        public PropertySyntaxNode[] Properties { get; init; } = Array.Empty<PropertySyntaxNode>();

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}interface {Name}" +
            $"{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetBodyCodeBlock(CodeStyle style)
        {
            List<string> members = new();
            members.AddRange(Interfaces.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Classes.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Records.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Structs.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Enums.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Properties.Select(member => Environment.NewLine + member.ToCode(style)));
            members.AddRange(Methods.Select(member => Environment.NewLine + member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }
    }
}