using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class MethodSyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }
        public string ReturnType { get; init; }
        public AccessModifier AccessModifier { get; init; } = AccessModifier.Internal;
        public MethodModifier Modifiers { get; init; } = MethodModifier.None;
        public MethodParameterSyntaxNode[] Parameters { get; init; } = Array.Empty<MethodParameterSyntaxNode>();

        protected string GetParameterList(CodeStyle style) =>
            string.Join(", ", Parameters.Select(parameterNode => parameterNode.ToCode(style)));
    }
}