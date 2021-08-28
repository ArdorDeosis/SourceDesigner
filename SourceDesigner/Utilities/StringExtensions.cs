using System;
using System.Text.RegularExpressions;

namespace SourceDesigner.Utilities
{
    public static class StringExtensions
    {
        public static string Indent(this string input, CodeStyle style)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (style == null)
                throw new ArgumentNullException(nameof(style));
            return Regex.Replace(input, "^", style.Indentation, RegexOptions.Multiline);
        }

        public static string WrapInBracesAndIndent(this string input, CodeStyle style)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (style == null)
                throw new ArgumentNullException(nameof(style));
            return string.IsNullOrEmpty(input)
                ? $"{{{Environment.NewLine}}}"
                : $"{{{Environment.NewLine}{input.Indent(style)}{Environment.NewLine}}}";
        }

        public static string WithTrailingSpace(this string input) => input switch
        {
            "" => "",
            not null => $"{input} ",
            _ => throw new ArgumentNullException(nameof(input))
        };

        public static string WithLeadingSpace(this string input) => input switch
        {
            "" => "",
            not null => $" {input}",
            _ => throw new ArgumentNullException(nameof(input))
        };
    }
}