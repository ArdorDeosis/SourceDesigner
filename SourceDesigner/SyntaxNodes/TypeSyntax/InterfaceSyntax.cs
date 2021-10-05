namespace SourceDesigner.SyntaxNodes
{
    public class InterfaceSyntax : TypeSyntax
    {
        public InterfaceSyntax(string name) : base(name) { }
        
        protected override string Keyword => "interface";
    }
}