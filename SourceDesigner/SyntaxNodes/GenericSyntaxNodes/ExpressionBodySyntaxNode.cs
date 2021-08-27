using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class ExpressionBodySyntaxNode : BodySyntaxNode
    {
        public ExpressionSyntaxNode Expression { get; init; }

        public override string ToCode(CodeStyle style) => style.NewLineBeforeExpressionBody
            ? $"=>{Environment.NewLine}{Expression.ToCode(style).Indent(style)};"
            : $"=> {Expression.ToCode(style)};";
    }
}