namespace SourceDesigner.SyntaxNodes
{
    public class AssignmentSyntax : SyntaxNodeBase
    {
        public ExpressionSyntax ExpressionSyntax { get; init; }

        public static implicit operator AssignmentSyntax(ExpressionSyntax expression) =>
            new AssignmentSyntax() { ExpressionSyntax = expression };
        
        public override string ToCode(CodeStyle style) => $"= {ExpressionSyntax.ToCode(style)}";
    }
}