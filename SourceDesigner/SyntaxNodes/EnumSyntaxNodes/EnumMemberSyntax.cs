namespace SourceDesigner.SyntaxNodes
{
    // TODO: make generic to encompass base type? int, byte etc.
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