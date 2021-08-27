using System;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class MethodSyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }
        public string ReturnType { get; init; }
        public AccessModifier AccessModifier { get; init; } = AccessModifier.Internal;
        public MethodModifier Modifiers { get; init; } = MethodModifier.None;
        public MethodParameterSyntaxNode[] Parameters { get; init; } = Array.Empty<MethodParameterSyntaxNode>();
        
        public BodySyntaxNode? Body { get; init; }

        public override string ToCode(CodeStyle style) =>
            $"{GetMethodHeader(style)}{(Body != null ? $" {Body.ToCode(style)}" : ";")}";

        private string GetMethodHeader(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{ReturnType} {Name} ({GetParameterList(style)})";
        
        private string GetParameterList(CodeStyle style) =>
            string.Join(", ", Parameters.Select(parameterNode => parameterNode.ToCode(style)));

    }
}