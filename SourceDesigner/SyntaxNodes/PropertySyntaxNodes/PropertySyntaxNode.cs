using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class PropertySyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }
        public string Type { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public PropertyModifier Modifiers { get; set; } = PropertyModifier.None;

        protected string GetPropertyHeader() =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}";
    }
}