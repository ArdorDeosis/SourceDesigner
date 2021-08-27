using System;
using System.Collections.Generic;
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
        public override string ToCode(CodeStyle style)
        {
            return $"{AccessModifier.EnumToCode()} enum {Name}{Environment.NewLine}{{{Environment.NewLine}" +
                   $"{string.Join(Environment.NewLine, GetMembersAsCode(style)).Indent(style)}{Environment.NewLine}}}";
        }

        private IEnumerable<string> GetMembersAsCode(CodeStyle style) =>
            Members.Select(member => $"{member.ToCode(style)}");
    }
}