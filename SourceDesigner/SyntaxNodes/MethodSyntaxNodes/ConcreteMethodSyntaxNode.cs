using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class ConcreteMethodSyntaxNode : MethodSyntaxNode
    {
        protected string GetMethodHeader(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().AddTrailingSpace()}{ReturnType} {Name} ({GetParameterList(style)})";
    }
}