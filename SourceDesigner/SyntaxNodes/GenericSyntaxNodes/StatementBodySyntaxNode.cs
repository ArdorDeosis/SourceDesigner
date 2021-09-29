using System;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class StatementBodySyntaxNode : SyntaxNodeBase
    {
        public Statement[] Statements { get; init; } = Array.Empty<Statement>();

        public override string ToCode(CodeStyle style) =>
            string.Join(Environment.NewLine, Statements.Select(statement => statement.ToCode(style)))
                .WrapInBracesAndIndent(style);
    }
}