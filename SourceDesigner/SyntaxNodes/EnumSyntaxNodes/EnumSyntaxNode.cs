using System;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class EnumSyntaxNode : SyntaxNodeBase
    {
        // TODO: base type?
        public string Name { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public EnumMemberSyntaxNode[] Members { get; init; }
        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} enum {Name}{Environment.NewLine}" +
            GetBodyCodeBlock(style).WrapInBracesAndIndent(style);

        private string GetBodyCodeBlock(CodeStyle style) =>
            string.Join(Environment.NewLine, Members.Select(member => $"{member.ToCode(style)}"));
    }
}