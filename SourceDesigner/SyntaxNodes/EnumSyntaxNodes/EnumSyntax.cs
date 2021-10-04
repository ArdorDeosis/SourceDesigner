using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class EnumSyntax : SyntaxNodeBase
    {
        // TODO: base type?
        public EnumSyntax(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public List<EnumMemberSyntax> Members { get; init; } = new();
        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} enum {Name}{Environment.NewLine}" +
            GetBodyCodeBlock(style).WrapInBracesAndIndent(style);

        private string GetBodyCodeBlock(CodeStyle style) =>
            string.Join(Environment.NewLine, Members.Select(member => $"{member.ToCode(style)}"));
    }
}