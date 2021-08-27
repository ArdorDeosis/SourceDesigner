namespace SourceDesigner.SyntaxNodes
{
    public abstract class ExpressionSyntaxNode : SyntaxNodeBase
    {
        public static implicit operator ExpressionSyntaxNode(string value) => new StringExpressionSyntaxNode(value);

        public static implicit operator ExpressionSyntaxNode(int value) => new IntExpressionSyntaxNode(value);
        
        public static implicit operator ExpressionSyntaxNode(double value) => new DoubleExpressionSyntaxNode(value);
    }
}