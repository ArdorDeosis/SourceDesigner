using System;
using System.Collections.Generic;
using System.Text;

namespace SourceDesigner.SyntaxNodes
{
    public class SwitchExpressionSyntaxNode : ExpressionSyntaxNode
    {
        public string Value { get; init; }
        public Dictionary<string, ExpressionSyntaxNode> ValueExpressionPairs { get; init; } = new();
        public ExpressionSyntaxNode? DefaultValue { get; init; }

        public override string ToCode(CodeStyle style)
        {
            var builder = new StringBuilder();
            builder.Append($"{Value} switch {{{Environment.NewLine}");
            foreach (var (value, expression) in ValueExpressionPairs)
                builder.Append($"{style.Indentation}{value} => {expression.ToCode(style)},{Environment.NewLine}");
            if (DefaultValue != null)
                builder.Append($"{style.Indentation}_ => {DefaultValue.ToCode(style)}{Environment.NewLine}");
            builder.Append('}');
            return builder.ToString();
        }
    }
}