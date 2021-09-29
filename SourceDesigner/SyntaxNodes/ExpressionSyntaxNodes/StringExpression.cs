namespace SourceDesigner.SyntaxNodes
{
    public class StringExpression : ValueExpression<string>
    {
        public StringExpression(string value) : base(value)
        {
        }
        
        public static implicit operator StringExpression(string value) => new(value);

        public override string ToCode(CodeStyle style) => $"\"{Value}\"";
    }
}