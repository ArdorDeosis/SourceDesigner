namespace SourceDesigner.SyntaxNodes
{
    public class FileRootSyntax : NamespaceSyntaxBase
    {
        public override string ToCode(CodeStyle style) => GetBodyCodeBlock(style);
    }
}