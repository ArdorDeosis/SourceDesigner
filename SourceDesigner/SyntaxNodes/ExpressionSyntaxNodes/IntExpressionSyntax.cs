namespace SourceDesigner.SyntaxNodes
{
    internal class IntExpressionSyntax : ValueExpressionSyntax<int>
    {
        internal IntExpressionSyntax(int value) : base(value)
        {
        }

        public override string ToCode(CodeStyle style) => $"{Value}";
    }
}