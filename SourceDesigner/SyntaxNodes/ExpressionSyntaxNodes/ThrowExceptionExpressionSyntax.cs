using System.Linq;

namespace SourceDesigner.SyntaxNodes
{
    public class ThrowExceptionExpressionSyntax : ExpressionSyntax
    {
        public string ExceptionType { get; init; } = "Exception";

        public string Message
        {
            init => ExceptionConstructorParameters = new ExpressionSyntax[] { value };
        }

        public ExpressionSyntax[] ExceptionConstructorParameters { get; init; }
        public override string ToCode(CodeStyle style) => $"throw new {ExceptionType}({GetParameterList(style)})";

        private string GetParameterList(CodeStyle style) => string.Join(", ", ExceptionConstructorParameters
            .Select(parameter => parameter.ToCode(style)));
    }
}