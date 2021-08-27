namespace SourceDesigner.SyntaxNodes
{
    public abstract class SyntaxNodeBase : ISyntaxNode
    {
        public string ToCode() => ToCode(new CodeStyle());
        
        public abstract string ToCode(CodeStyle style);
    }
}