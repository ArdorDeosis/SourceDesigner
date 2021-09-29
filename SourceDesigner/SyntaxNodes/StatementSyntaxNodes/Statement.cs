namespace SourceDesigner.SyntaxNodes
{
    public abstract class Statement : SyntaxNodeBase
    {
        public static Statement FromText(string statement) => new RawStatement(statement);

        public static Statement Return(Expression expression) => new ReturnStatement(expression);
    }
}