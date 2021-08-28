namespace SourceDesigner.SyntaxNodes
{
    public abstract class StatementSyntaxNode : SyntaxNodeBase
    {
        public static StatementSyntaxNode FromText(string statement) => new RawStatementSyntaxNode(statement);
    }
}