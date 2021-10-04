namespace SourceDesigner.SyntaxNodes
{
    public abstract class ExpressionSyntax : SyntaxNodeBase
    {
        public static implicit operator ExpressionSyntax(string value) => new StringExpressionSyntax(value);

        public static implicit operator ExpressionSyntax(int value) => new IntExpressionSyntax(value);
        
        public static implicit operator ExpressionSyntax(double value) => new DoubleExpressionSyntax(value);

        public static ExpressionSyntax FromString(string expression) => new RawExpressionSyntax(expression);
    }
}