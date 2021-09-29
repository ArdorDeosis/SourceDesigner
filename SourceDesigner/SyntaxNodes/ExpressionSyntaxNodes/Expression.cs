namespace SourceDesigner.SyntaxNodes
{
    public abstract class Expression : SyntaxNodeBase
    {
        public static implicit operator Expression(string value) => new StringExpression(value);

        public static implicit operator Expression(int value) => new IntExpression(value);
        
        public static implicit operator Expression(double value) => new DoubleExpression(value);

        public static Expression FromString(string expression) => new RawExpression(expression);
    }
}