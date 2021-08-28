namespace SourceDesigner.SyntaxNodes
{
    public class ReturnStatementSyntaxNode : StatementSyntaxNode
    {
        private ExpressionSyntaxNode Expression { get; init; }

        public override string ToCode(CodeStyle style) => $"return {Expression.ToCode(style)};";
    }
}