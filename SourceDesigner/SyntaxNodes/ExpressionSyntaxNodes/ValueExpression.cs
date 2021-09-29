namespace SourceDesigner.SyntaxNodes
{
    public abstract class ValueExpression<T> : Expression
    {
        protected ValueExpression(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}