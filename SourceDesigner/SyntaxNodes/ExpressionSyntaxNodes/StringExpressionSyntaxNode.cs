namespace SourceDesigner.SyntaxNodes
{
    public class StringExpressionSyntaxNode : ValueExpressionSyntaxNode<string>
    {
        public StringExpressionSyntaxNode(string value) : base(value)
        {
        }
        
        public static implicit operator StringExpressionSyntaxNode(string value) => new(value);

        public override string ToCode(CodeStyle style) => $"\"{Value}\"";
    }
}