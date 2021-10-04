using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class ExpressionBodySyntax : MethodBodySyntax
    {
        public ExpressionSyntax ExpressionSyntax { get; init; }

        public override string ToCode(CodeStyle style) => style.NewLineBeforeExpressionBody
            ? $"=>{Environment.NewLine}{ExpressionSyntax.ToCode(style).Indent(style)};"
            : $"=> {ExpressionSyntax.ToCode(style)};";
    }
}