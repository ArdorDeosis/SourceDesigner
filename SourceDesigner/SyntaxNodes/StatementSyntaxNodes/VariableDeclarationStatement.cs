namespace SourceDesigner.SyntaxNodes
{
    public class VariableDeclarationStatement : Statement
    {
        private VariableExpressionSyntax variable;
        private Assignment? assignment;

        public string VariableName
        {
            init => variable = new VariableExpressionSyntax() { VariableName = value };
        }

        public ExpressionSyntax? Value
        {
            init => assignment = value != null ? new Assignment { ExpressionSyntax = value } : null;
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