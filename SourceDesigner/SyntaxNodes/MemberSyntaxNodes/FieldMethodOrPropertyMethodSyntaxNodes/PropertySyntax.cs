using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class PropertySyntax : FieldMethodOrPropertySyntax
    {
        protected PropertySyntax(string type, string name) : base(type, name) { }

        protected string GetPropertyHeader() =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}";
    }
}