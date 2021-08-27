namespace SourceDesigner.SyntaxNodes
{
    internal class RawExpressionSyntaxNode : ExpressionSyntaxNode
    {
        internal RawExpressionSyntaxNode(string expression)
        {
            Expression = expression;
        }  
        internal string Expression { get; }
        public override string ToCode(CodeStyle style) => Expression;
    }
}