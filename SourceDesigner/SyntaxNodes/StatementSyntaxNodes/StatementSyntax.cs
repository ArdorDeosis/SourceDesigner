namespace SourceDesigner.SyntaxNodes
{
    public abstract class StatementSyntax : SyntaxNodeBase
    {
        public static StatementSyntax FromText(string statement) => new RawStatementSyntax(statement);

        public static StatementSyntax Return(ExpressionSyntax expressionSyntax) => new ReturnStatementSyntax(expressionSyntax);
    }
}