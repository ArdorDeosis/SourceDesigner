namespace SourceDesigner.SyntaxNodes
{
    internal class DoubleExpressionSyntax : ValueExpressionSyntax<double>
    {
        internal DoubleExpressionSyntax(double value) : base(value)
        {
        }

        public override string ToCode(CodeStyle style) => $"{Value:G17}";
    }
}