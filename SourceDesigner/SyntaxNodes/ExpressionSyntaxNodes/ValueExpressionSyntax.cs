namespace SourceDesigner.SyntaxNodes
{
    public abstract class ValueExpressionSyntax<T> : ExpressionSyntax
    {
        protected ValueExpressionSyntax(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}