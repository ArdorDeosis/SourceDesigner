namespace SourceDesigner.SyntaxNodes
{
    public class IntExpressionSyntaxNode : ValueExpressionSyntaxNode<int>
    {
        public IntExpressionSyntaxNode(int value) : base(value)
        {
        }
        
        public static implicit operator IntExpressionSyntaxNode(int value) => new(value);

        public override string ToCode(CodeStyle style) => $"{Value}";
    }
}