using System.Linq;

namespace SourceDesigner.SyntaxNodes
{
    public class ThrowExceptionExpression : ExpressionSyntaxNode
    {
        public string ExceptionType { get; init; } = "Exception";

        public string Message
        {
            init => ExceptionConstructorParameters = new ExpressionSyntaxNode[] { value };
        }

        public ExpressionSyntaxNode[] ExceptionConstructorParameters { get; init; }
        public override string ToCode(CodeStyle style) => $"throw new {ExceptionType}({GetParameterList(style)})";

        private string GetParameterList(CodeStyle style) => string.Join(", ", ExceptionConstructorParameters
            .Select(parameter => parameter.ToCode(style)));
    }
}