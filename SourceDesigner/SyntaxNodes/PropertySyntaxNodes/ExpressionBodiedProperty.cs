namespace SourceDesigner.SyntaxNodes
{
    class ExpressionBodiedProperty : Property
    {
        private readonly ExpressionBody body;

        public ExpressionSyntax ExpressionSyntax
        {
            get => body.ExpressionSyntax;
            init => body = new ExpressionBody { ExpressionSyntax = value };
        }

        public override string ToCode(CodeStyle style) => $"{GetPropertyHeader()} {body.ToCode(style)};";

        public ExpressionBodiedProperty(string type, string name) : base(type, name)
        {
        }
    }
}