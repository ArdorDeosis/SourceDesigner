namespace SourceDesigner.SyntaxNodes.FileRootSyntaxNodes
{
    public class UsingDirectiveSyntaxNode : SyntaxNodeBase
    {
        public string Directive { get; init; }

        public override string ToCode(CodeStyle style) => $"using {Directive};";
    }
}