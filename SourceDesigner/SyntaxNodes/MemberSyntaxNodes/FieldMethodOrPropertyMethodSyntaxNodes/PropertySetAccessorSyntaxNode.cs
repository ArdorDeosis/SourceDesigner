using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class PropertySetAccessorSyntaxNode : PropertyAccessorSyntaxNode
    {
        public PropertySetterType Type { get; init; } = PropertySetterType.Set;
        protected override string Keyword => Type.EnumToCode();
    }
}