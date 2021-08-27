namespace SourceDesigner.SyntaxNodes
{
    public interface ISyntaxNode
    {
        public string ToCode();

        public string ToCode(CodeStyle style);
    }
}