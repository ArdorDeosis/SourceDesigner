using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class MethodSyntax : FieldMethodOrPropertySyntax
    {
        public MethodSyntax(string type, string name) : base(type, name) { }
        public List<MethodParameter> Parameters { get; init; } = new();
        public MethodBodySyntax? Body { get; init; }
        public List<GenericTypeParameter> GenericTypeParameters { get; init; } = new();

        public override string ToCode(CodeStyle style) =>
            $"{GetMethodHeader(style)}{(Body != null ? $" {Body.ToCode(style)}" : ";")}";

        private string GetMethodHeader(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}" +
            $"{GenericTypeParameters.ToGenericTypeParametersCode(style)} ({GetParameterList(style)})" +
            $"{GenericTypeParameters.ToGenericTypeConstraintCode(style).WithLeadingSpace()}";

        private string GetParameterList(CodeStyle style) =>
            string.Join(", ", Parameters.Select(parameterNode => parameterNode.ToCode(style)));
    }
}