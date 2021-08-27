namespace SourceDesigner.SyntaxNodes
{
    public class DoubleExpressionSyntaxNode : ValueExpressionSyntaxNode<double>
    {
        public DoubleExpressionSyntaxNode(double value) : base(value)
        {
        }
        
        public static implicit operator DoubleExpressionSyntaxNode(double value) => new(value);

        // TODO: this formatting might be a problem, needs tests
        public override string ToCode(CodeStyle style) => $"{Value:R}";
    }
}