using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SourceDesigner.SyntaxNodes
{
    internal static class GenericTypeParameterExtensions
    {
        internal static string ToGenericTypeParametersCode(this IEnumerable<GenericTypeParameter> parameterList) =>
            ToGenericTypeParametersCode(parameterList, CodeStyle.Default);

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        internal static string ToGenericTypeParametersCode(this IEnumerable<GenericTypeParameter> parameterList,
            CodeStyle style) =>
            parameterList.Any()
                ? $"<{string.Join(", ", parameterList.Select(parameter => parameter.Name))}>"
                : "";

        internal static string ToGenericTypeConstraintCode(this IEnumerable<GenericTypeParameter> parameterList) =>
            ToGenericTypeConstraintCode(parameterList, CodeStyle.Default);

        internal static string ToGenericTypeConstraintCode(this IEnumerable<GenericTypeParameter> parameterList, CodeStyle style) =>
            string.Join(" ", parameterList
                .Where(parameter => parameter.Constraints.Count > 0)
                .Select(parameter => parameter.ToGenericTypeConstraintCode(style)!));
    }
}