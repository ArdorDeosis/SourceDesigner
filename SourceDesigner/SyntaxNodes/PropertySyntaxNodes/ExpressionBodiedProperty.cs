namespace SourceDesigner.SyntaxNodes
{
    class ExpressionBodiedProperty : Property
    {
        private readonly ExpressionBodySyntax bodySyntax;

        public ExpressionSyntax ExpressionSyntax
        {
            get => bodySyntax.ExpressionSyntax;
            init => bodySyntax = new ExpressionBodySyntax { ExpressionSyntax = value };
        }

        public override string ToCode(CodeStyle style) => $"{GetPropertyHeader()} {bodySyntax.ToCode(style)};";

        public ExpressionBodiedProperty(string type, string name) : base(type, name)
        {
        }
    }
}