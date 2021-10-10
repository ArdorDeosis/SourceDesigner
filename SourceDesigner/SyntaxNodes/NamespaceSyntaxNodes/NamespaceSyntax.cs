using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class NamespaceSyntax : NamespaceSyntaxBase
    {
        public NamespaceSyntax(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public override string ToCode(CodeStyle style) => 
            $"namespace {Name}{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";
    }
}