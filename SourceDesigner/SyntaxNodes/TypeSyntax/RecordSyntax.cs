namespace SourceDesigner.SyntaxNodes
{
    public class RecordSyntax : TypeSyntax
    {
        public RecordSyntax(string name) : base(name) { }

        protected override string Keyword => "record";
    }
}