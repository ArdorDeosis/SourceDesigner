using System;

namespace SourceDesigner.SyntaxNodes
{
    public class ConditionalOperatorExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax ConditionExpressionSyntax { get; init; }
        public ExpressionSyntax TrueExpressionSyntax { get; init; }
        public ExpressionSyntax FalseExpressionSyntax { get; init; }
        public override string ToCode(CodeStyle style) =>
            $"{ConditionExpressionSyntax.ToCode(style)}{Environment.NewLine}" +
            $"? {TrueExpressionSyntax.ToCode(style)}{Environment.NewLine}" +
            $": {FalseExpressionSyntax.ToCode(style)}";
    }
}