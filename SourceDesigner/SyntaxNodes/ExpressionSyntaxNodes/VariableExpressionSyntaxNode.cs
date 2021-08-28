namespace SourceDesigner.SyntaxNodes
{
    public class VariableExpressionSyntaxNode : ExpressionSyntaxNode
    {
        public string VariableName { get; init; }
        public override string ToCode(CodeStyle style) => VariableName;
    }
}