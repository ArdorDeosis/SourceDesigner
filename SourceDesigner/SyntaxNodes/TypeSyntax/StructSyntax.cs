namespace SourceDesigner.SyntaxNodes
{
    public class StructSyntax : TypeSyntax
    {
        public StructSyntax(string name) : base(name) { }

        protected override string Keyword => "struct";
    }
}