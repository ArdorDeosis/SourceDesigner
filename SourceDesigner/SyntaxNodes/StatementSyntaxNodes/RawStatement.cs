namespace SourceDesigner.SyntaxNodes
{
    internal class RawStatement : Statement
    {
        internal RawStatement(string statement)
        {
            Statement = statement;
        }  
        internal string Statement { get; }
        public override string ToCode(CodeStyle style) => Statement;
    }
}