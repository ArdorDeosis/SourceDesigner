namespace SourceDesigner.SyntaxNodes
{
    public class Assignment : SyntaxNodeBase
    {
        public ExpressionSyntax ExpressionSyntax { get; init; }
        
        public override string ToCode(CodeStyle style) => $"= {ExpressionSyntax.ToCode(style)}";
    }
}