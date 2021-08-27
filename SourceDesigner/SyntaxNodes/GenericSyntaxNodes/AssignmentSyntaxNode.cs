namespace SourceDesigner.SyntaxNodes
{
    public class AssignmentSyntaxNode : PropertySyntaxNode
    {
        public ExpressionSyntaxNode Expression { get; init; }
        
        public override string ToCode(CodeStyle style) => $"= {Expression.ToCode(style)}";
    }
}