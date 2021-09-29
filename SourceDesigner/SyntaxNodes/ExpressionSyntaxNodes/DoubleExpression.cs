namespace SourceDesigner.SyntaxNodes
{
    public class DoubleExpression : ValueExpression<double>
    {
        public DoubleExpression(double value) : base(value)
        {
        }
        
        public static implicit operator DoubleExpression(double value) => new(value);

        // TODO: this formatting might be a problem, needs tests
        public override string ToCode(CodeStyle style) => $"{Value:R}";
    }
}