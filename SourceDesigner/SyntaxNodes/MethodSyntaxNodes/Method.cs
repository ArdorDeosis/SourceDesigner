using System;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class Method : SyntaxNodeBase
    {
        public Method(string returnType, string name)
        {
            ReturnType = returnType;
            Name = name;
        }
        
        public string Name { get; init; }
        public string ReturnType { get; init; }
        public AccessModifier AccessModifier { get; init; } = AccessModifier.Internal;
        public MethodModifier Modifiers { get; init; } = MethodModifier.None;
        public MethodParameter[] Parameters { get; init; } = Array.Empty<MethodParameter>();
        
        public MethodBody? Body { get; init; }

        public override string ToCode(CodeStyle style) =>
            $"{GetMethodHeader(style)}{(Body != null ? $" {Body.ToCode(style)}" : ";")}";

        private string GetMethodHeader(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{ReturnType} {Name} ({GetParameterList(style)})";
        
        private string GetParameterList(CodeStyle style) =>
            string.Join(", ", Parameters.Select(parameterNode => parameterNode.ToCode(style)));

    }
}