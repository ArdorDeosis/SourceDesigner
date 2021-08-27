using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class AbstractMethodSyntaxNode : MethodSyntaxNode
    {
        public override string ToCode(CodeStyle style) => 
            $"{AccessModifier.EnumToCode()} abstract {Modifiers.FlagEnumToCode().AddTrailingSpace()}{ReturnType} {Name} ({GetParameterList(style)});";
    }
}