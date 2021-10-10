using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.SyntaxNodes.FileRootSyntaxNodes;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class NamespaceSyntaxBase : SyntaxNodeBase
    {
        public List<UsingDirectiveSyntaxNode> UsingDirectives { get; init; } = new();
        public List<NamespaceSyntax> Namespaces { get; init; } = new();
        public List<EnumOrTypeSyntax> Members { get; init; } = new();

        protected string GetBodyCodeBlock(CodeStyle style)
        {
            List<string> members = new();
            if (UsingDirectives.Count > 0)
                members.Add(string.Join(Environment.NewLine, UsingDirectives.Select(usingDirective => usingDirective.ToCode(style))));
            members.AddRange(Namespaces.Select(member => member.ToCode(style)));
            members.AddRange(Members.Select(member => member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }
    }
}