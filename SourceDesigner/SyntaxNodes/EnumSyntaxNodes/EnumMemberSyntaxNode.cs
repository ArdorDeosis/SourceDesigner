namespace SourceDesigner.SyntaxNodes
{
    public class EnumMemberSyntaxNode : SyntaxNodeBase
    {
        private readonly AssignmentSyntaxNode? assignment;
        public string Name { get; init; }
        public int? Value
        {
            get => (assignment?.Expression as IntExpression)?.Value;
            init => assignment = value != null ? new AssignmentSyntaxNode { Expression = value } : assignment = null;
        }
        public override string ToCode(CodeStyle style) => assignment != null 
            ? $"{Name} {assignment.ToCode(style)}," 
            : $"{Name},";
    }
}