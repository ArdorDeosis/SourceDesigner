using System;
using System.Collections.Generic;

namespace SourceDesigner.SyntaxNodes
{
    class StatementBodiedMethodSyntaxNode : ConcreteMethodSyntaxNode
    {
        public StatementSyntaxNode[] Statements { get; init; } = Array.Empty<StatementSyntaxNode>();

        // TODO: statements
        public override string ToCode(CodeStyle style) =>
            $"{GetMethodHeader(style)}{Environment.NewLine}{{{Environment.NewLine}}}";
    }
}