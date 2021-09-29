namespace SourceDesigner.SyntaxNodes
{
    public class VariableExpression : Expression
    {
        public string VariableName { get; init; }
        public override string ToCode(CodeStyle style) => VariableName;
    }
}