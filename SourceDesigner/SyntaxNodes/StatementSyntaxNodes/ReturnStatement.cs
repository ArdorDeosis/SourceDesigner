namespace SourceDesigner.SyntaxNodes
{
    public class ReturnStatement : Statement
    {
        public ReturnStatement(Expression expression)
        {
            Expression = expression;
        }
        private Expression Expression { get; }

        public override string ToCode(CodeStyle style) => $"return {Expression.ToCode(style)};";
    }
}