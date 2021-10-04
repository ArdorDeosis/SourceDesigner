namespace SourceDesigner.SyntaxNodes
{
    internal class StringExpressionSyntax : ValueExpressionSyntax<string>
    {
        internal StringExpressionSyntax(string value) : base(value)
        {
        }

        public override string ToCode(CodeStyle style) => $"\"{Value}\"";
    }
}