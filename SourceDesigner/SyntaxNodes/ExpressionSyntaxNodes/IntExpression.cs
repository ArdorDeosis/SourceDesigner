namespace SourceDesigner.SyntaxNodes
{
    public class IntExpression : ValueExpression<int>
    {
        public IntExpression(int value) : base(value)
        {
        }
        
        public static implicit operator IntExpression(int value) => new(value);

        public override string ToCode(CodeStyle style) => $"{Value}";
    }
}