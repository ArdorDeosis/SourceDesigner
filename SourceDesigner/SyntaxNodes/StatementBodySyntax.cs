using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class StatementBodySyntax : MethodBodySyntax
    {
        public List<StatementSyntax> Statements { get; init; } = new();

        public override string ToCode(CodeStyle style) =>
            string.Join(Environment.NewLine, Statements.Select(statement => statement.ToCode(style)))
                .WrapInBracesAndIndent(style);
    }
}