namespace SourceDesigner.SyntaxNodes
{
    public abstract class ValueExpressionSyntaxNode<T> : ExpressionSyntaxNode
    {
        protected ValueExpressionSyntaxNode(T value)
        {
            Value = value;
        }

        protected T Value { get; }
    }
}