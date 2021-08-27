using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class PropertyAccessorSyntaxNode : SyntaxNodeBase
    {
        public AccessModifier? AccessModifier { get; set; }
        public BodySyntaxNode? Body { get; init; }

        protected abstract string Keyword { get; }

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier?.EnumToCode().WithTrailingSpace() ?? ""} {Keyword}" +
            (Body != null ? $" {Body.ToCode(style)}" : ";");
    }
}