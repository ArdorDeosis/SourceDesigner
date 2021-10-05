using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class MethodSyntax : SyntaxNodeBase
    {
        public MethodSyntax(string returnType, string name)
        {
            ReturnType = returnType;
            Name = name;
        }

        public string Name { get; init; }
        public string ReturnType { get; init; }
        public AccessModifier AccessModifier { get; init; } = AccessModifier.Internal;
        public MethodModifier Modifiers { get; init; } = MethodModifier.None;
        public List<MethodParameter> Parameters { get; init; } = new();
        public MethodBodySyntax? Body { get; init; }
        public List<GenericTypeParameter> GenericTypeParameters { get; init; } = new();

        public override string ToCode(CodeStyle style) =>
            $"{GetMethodHeader(style)}{(Body != null ? $" {Body.ToCode(style)}" : ";")}";

        private string GetMethodHeader(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{ReturnType} {Name}" +
            $"{GenericTypeParameters.ToGenericTypeParametersCode(style)} ({GetParameterList(style)})" +
            $"{GenericTypeParameters.ToGenericTypeConstraintCode(style).WithLeadingSpace()}";

        private string GetParameterList(CodeStyle style) =>
            string.Join(", ", Parameters.Select(parameterNode => parameterNode.ToCode(style)));
    }
}