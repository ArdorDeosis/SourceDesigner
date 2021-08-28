using System;

namespace SourceDesigner.SyntaxNodes
{
    public class ConditionalOperatorExpression : ExpressionSyntaxNode
    {
        public ExpressionSyntaxNode ConditionExpression { get; init; }
        public ExpressionSyntaxNode TrueExpression { get; init; }
        public ExpressionSyntaxNode FalseExpression { get; init; }
        public override string ToCode(CodeStyle style) =>
            $"{ConditionExpression.ToCode(style)}{Environment.NewLine}" +
            $"? {TrueExpression.ToCode(style)}{Environment.NewLine}" +
            $": {FalseExpression.ToCode(style)}";
    }
}