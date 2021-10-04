namespace SourceDesigner.SyntaxNodes
{
    internal class RawStatementSyntax : StatementSyntax
    {
        internal RawStatementSyntax(string statement)
        {
            Statement = statement;
        }  
        internal string Statement { get; }
        public override string ToCode(CodeStyle style) => Statement;
    }
}