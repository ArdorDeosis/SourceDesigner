namespace SourceDesigner.SyntaxNodes
{
    // Note: this could be generic to encompass base type
    public class EnumMemberSyntax : SyntaxNodeBase
    {
        private readonly AssignmentSyntax? assignment;

        public EnumMemberSyntax(string name)
        {
            Name = name;
        }

        public string Name { get; }
        
        public int? Value
        {
            get => (assignment?.ExpressionSyntax as IntExpressionSyntax)?.Value;
            init => assignment = value != null ? new AssignmentSyntax { ExpressionSyntax = value } : assignment = null;
        }
        
        public override string ToCode(CodeStyle style) => assignment != null 
            ? $"{Name} {assignment.ToCode(style)}," 
            : $"{Name},";
    }
}