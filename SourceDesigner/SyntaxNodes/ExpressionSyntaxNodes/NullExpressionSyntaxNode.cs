namespace SourceDesigner.SyntaxNodes
{
    public class NullExpressionSyntaxNode : ExpressionSyntaxNode
    {
        public override string ToCode(CodeStyle style) => "null";
    }
}