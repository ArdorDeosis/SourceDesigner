namespace SourceDesigner.SyntaxNodes
{
    public class RawExpressionSyntaxNode : ExpressionSyntaxNode
    {
        public RawExpressionSyntaxNode(string expression)
        {
            Expression = expression;
        }

        public static implicit operator RawExpressionSyntaxNode(string value) => new(value);  
        public string Expression { get; }
        public override string ToCode(CodeStyle style) => Expression;
    }
}