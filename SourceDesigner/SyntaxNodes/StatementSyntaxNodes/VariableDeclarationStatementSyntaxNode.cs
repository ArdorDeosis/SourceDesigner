namespace SourceDesigner.SyntaxNodes
{
    public class VariableDeclarationStatementSyntaxNode : StatementSyntaxNode
    {
        private VariableExpressionSyntaxNode variable;
        private AssignmentSyntaxNode? assignment;

        public string VariableName
        {
            init => variable = new VariableExpressionSyntaxNode() { VariableName = value };
        }

        public ExpressionSyntaxNode? Value
        {
            init => assignment = value != null ? new AssignmentSyntaxNode { Expression = value } : null;
        }

        public string Type { get; init; } = "var";


        public override string ToCode(CodeStyle style)
        {
            return assignment != null
                ? $"{Type} {variable.ToCode(style)}{assignment.ToCode(style)};"
                : $"{Type} {variable.ToCode(style)};";
        }
    }
}