namespace SourceDesigner.SyntaxNodes
{
    class ExpressionBodiedPropertySyntaxNode : PropertySyntaxNode
    {
        private readonly ExpressionBodySyntaxNode body;

        public ExpressionSyntaxNode Expression
        {
            get => body.Expression;
            init => body = new ExpressionBodySyntaxNode { Expression = value };
        }

        public override string ToCode(CodeStyle style) => $"{GetPropertyHeader()} {body.ToCode(style)};";
    }
}