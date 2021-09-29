using System;

namespace SourceDesigner.SyntaxNodes
{
    public class ConditionalOperatorExpression : Expression
    {
        public Expression ConditionExpression { get; init; }
        public Expression TrueExpression { get; init; }
        public Expression FalseExpression { get; init; }
        public override string ToCode(CodeStyle style) =>
            $"{ConditionExpression.ToCode(style)}{Environment.NewLine}" +
            $"? {TrueExpression.ToCode(style)}{Environment.NewLine}" +
            $": {FalseExpression.ToCode(style)}";
    }
}