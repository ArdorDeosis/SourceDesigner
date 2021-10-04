namespace SourceDesigner.SyntaxNodes
{
    public class ReturnStatementSyntax : StatementSyntax
    {
        public ReturnStatementSyntax(ExpressionSyntax expressionSyntax)
        {
            ExpressionSyntax = expressionSyntax;
        }
        private ExpressionSyntax ExpressionSyntax { get; }

        public override string ToCode(CodeStyle style) => $"return {ExpressionSyntax.ToCode(style)};";
    }
}