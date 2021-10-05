namespace SourceDesigner.SyntaxNodes
{
    public class ClassSyntax : TypeSyntax
    {
        public ClassSyntax(string name) : base(name) { }

        protected override string Keyword => "class";
    }
}