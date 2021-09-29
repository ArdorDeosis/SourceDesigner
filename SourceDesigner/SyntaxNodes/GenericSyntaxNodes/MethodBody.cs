namespace SourceDesigner.SyntaxNodes
{
    public abstract class MethodBody : SyntaxNodeBase
    {
        public static implicit operator MethodBody(Expression expression) =>
            new ExpressionBody {Expression = expression};
    }
}