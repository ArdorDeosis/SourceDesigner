using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class PropertySyntax : SyntaxNodeBase
    {
        protected PropertySyntax(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }
        public AccessModifier AccessModifier { get; } = AccessModifier.Internal;
        public PropertyModifier Modifiers { get; } = PropertyModifier.None;

        protected string GetPropertyHeader() =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}";
    }
}