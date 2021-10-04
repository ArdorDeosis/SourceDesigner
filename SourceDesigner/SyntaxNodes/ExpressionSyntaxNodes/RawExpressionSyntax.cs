namespace SourceDesigner.SyntaxNodes
{
    internal class RawExpressionSyntax : ExpressionSyntax
    {
        internal RawExpressionSyntax(string expression)
        {
            Expression = expression;
        }  
        internal string Expression { get; }
        public override string ToCode(CodeStyle style) => Expression;
    }
}