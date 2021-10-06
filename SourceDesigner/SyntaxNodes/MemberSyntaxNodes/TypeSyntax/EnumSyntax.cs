using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class EnumSyntax : MemberSyntax
    {
        public EnumSyntax(string name) : base(name)
        {
        }

        public UnderlyingEnumType UnderlyingType { get; init; } = UnderlyingEnumType.Int;

        public List<EnumMemberSyntax> Members { get; init; } = new();

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} enum {Name} : {UnderlyingType.EnumToCode()}{Environment.NewLine}" +
            GetBodyCodeBlock(style).WrapInBracesAndIndent(style);

        private string GetBodyCodeBlock(CodeStyle style) =>
            string.Join(Environment.NewLine, Members.Select(member => $"{member.ToCode(style)}"));
    }
}