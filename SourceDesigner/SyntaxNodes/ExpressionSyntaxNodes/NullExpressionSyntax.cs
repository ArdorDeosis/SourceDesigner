namespace SourceDesigner.SyntaxNodes
{
    public class NullExpressionSyntax : ExpressionSyntax
    {
        public override string ToCode(CodeStyle style) => "null";
    }
}