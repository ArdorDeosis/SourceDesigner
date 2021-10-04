using System;
using System.Collections.Generic;
using System.Text;

namespace SourceDesigner.SyntaxNodes
{
    public class SwitchExpressionSyntax : ExpressionSyntax
    {
        public SwitchExpressionSyntax(string switchValueName)
        {
            SwitchValueName = switchValueName;
        }

        public string SwitchValueName { get; }
        public Dictionary<string, ExpressionSyntax> ValueExpressionPairs { get; init; } = new();
        public ExpressionSyntax? DefaultValue { get; init; }

        public override string ToCode(CodeStyle style)
        {
            var builder = new StringBuilder();
            builder.Append($"{SwitchValueName} switch {{{Environment.NewLine}");
            foreach (var (value, expression) in ValueExpressionPairs)
                builder.Append($"{style.Indentation}{value} => {expression.ToCode(style)},{Environment.NewLine}");
            if (DefaultValue != null)
                builder.Append($"{style.Indentation}_ => {DefaultValue.ToCode(style)}{Environment.NewLine}");
            builder.Append('}');
            return builder.ToString();
        }
    }
}