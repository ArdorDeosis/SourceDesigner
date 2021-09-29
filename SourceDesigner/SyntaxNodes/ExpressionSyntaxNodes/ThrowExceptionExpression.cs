using System.Linq;

namespace SourceDesigner.SyntaxNodes
{
    public class ThrowExceptionExpression : Expression
    {
        public string ExceptionType { get; init; } = "Exception";

        public string Message
        {
            init => ExceptionConstructorParameters = new Expression[] { value };
        }

        public Expression[] ExceptionConstructorParameters { get; init; }
        public override string ToCode(CodeStyle style) => $"throw new {ExceptionType}({GetParameterList(style)})";

        private string GetParameterList(CodeStyle style) => string.Join(", ", ExceptionConstructorParameters
            .Select(parameter => parameter.ToCode(style)));
    }
}