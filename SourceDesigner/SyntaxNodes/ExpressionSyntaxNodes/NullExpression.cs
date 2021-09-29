namespace SourceDesigner.SyntaxNodes
{
    public class NullExpression : Expression
    {
        public override string ToCode(CodeStyle style) => "null";
    }
}