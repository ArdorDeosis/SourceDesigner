namespace SourceDesigner.SyntaxNodes
{
    public class AssignmentSyntaxNode : PropertySyntaxNode
    {
        public Expression Expression { get; init; }
        
        public override string ToCode(CodeStyle style) => $"= {Expression.ToCode(style)}";
    }
}