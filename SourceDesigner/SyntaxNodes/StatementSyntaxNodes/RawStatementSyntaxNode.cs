namespace SourceDesigner.SyntaxNodes
{
    internal class RawStatementSyntaxNode : StatementSyntaxNode
    {
        internal RawStatementSyntaxNode(string statement)
        {
            Statement = statement;
        }  
        internal string Statement { get; }
        public override string ToCode(CodeStyle style) => Statement;
    }
}