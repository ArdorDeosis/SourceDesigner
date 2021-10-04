namespace SourceDesigner.SyntaxNodes
{
    public class VariableDeclarationStatementSyntax : StatementSyntax
    {
        private readonly AssignmentSyntax? assignment;

        public VariableDeclarationStatementSyntax(string name)
        {
            Name = name;
        }
        
        public VariableDeclarationStatementSyntax(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public ExpressionSyntax? Value
        {
            init => assignment = value != null ? new AssignmentSyntax { ExpressionSyntax = value } : null;
        }

        public string Name { get; init; }
        
        public string Type { get; init; } = "var";


        public override string ToCode(CodeStyle style)
        {
            return assignment != null
                ? $"{Type} {Name}{assignment.ToCode(style)};"
                : $"{Type} {Name};";
        }
    }
}