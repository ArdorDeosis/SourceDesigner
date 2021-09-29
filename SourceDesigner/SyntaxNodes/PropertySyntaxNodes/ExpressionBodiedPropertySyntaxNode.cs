namespace SourceDesigner.SyntaxNodes
{
    class ExpressionBodiedPropertySyntaxNode : PropertySyntaxNode
    {
        private readonly ExpressionBody body;

        public Expression Expression
        {
            get => body.Expression;
            init => body = new ExpressionBody { Expression = value };
        }

        public override string ToCode(CodeStyle style) => $"{GetPropertyHeader()} {body.ToCode(style)};";
    }
}