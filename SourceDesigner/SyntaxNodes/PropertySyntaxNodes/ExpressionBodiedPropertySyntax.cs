namespace SourceDesigner.SyntaxNodes
{
    class ExpressionBodiedPropertySyntax : PropertySyntax
    {
        private readonly ExpressionBodySyntax bodySyntax;

        public ExpressionSyntax ExpressionSyntax
        {
            get => bodySyntax.ExpressionSyntax;
            init => bodySyntax = new ExpressionBodySyntax { ExpressionSyntax = value };
        }

        public override string ToCode(CodeStyle style) => $"{GetPropertyHeader()} {bodySyntax.ToCode(style)};";

        public ExpressionBodiedPropertySyntax(string type, string name) : base(type, name)
        {
        }
    }
}