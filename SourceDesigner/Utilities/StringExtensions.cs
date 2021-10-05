using System;
using System.Text.RegularExpressions;

namespace SourceDesigner.Utilities
{
    public static class StringExtensions
    {
        public static bool IsMultiLine(this string input) => input.Contains('\n');

        public static string Indent(this string input, CodeStyle style)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (style == null)
                throw new ArgumentNullException(nameof(style));
            return Regex.Replace(input, @"^(?!\s*$)", style.Indentation, RegexOptions.Multiline)
                .RemoveTrailingWhitespace();
        }

        public static string RemoveTrailingWhitespace(this string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return Regex.Replace(input, @"[ \t]*(?=\r?\n|$)", string.Empty);
        }

        public static string WrapInBracesAndIndent(this string input, CodeStyle style)
        {
            if (style == null)
                throw new ArgumentNullException(nameof(style));
            return input switch
            {
                not null when new Regex(@"^[ \t]*$").IsMatch(input) => $"{{{Environment.NewLine}}}",
                not null => $"{{{Environment.NewLine}{input.Indent(style)}{Environment.NewLine}}}",
                _ => throw new ArgumentNullException(nameof(input)),
            };
        }

        public static string WithTrailingSpace(this string input) => input switch
        {
            "" => "",
            not null when new Regex(@"^(.|\n?\r)* $").IsMatch(input) => input,
            not null => $"{input} ",
            _ => throw new ArgumentNullException(nameof(input))
        };

        public static string WithLeadingSpace(this string input) => input switch
        {
            "" => "",
            not null when new Regex(@"^ (.|\n?\r)*$").IsMatch(input) => input,
            not null => $" {input}",
            _ => throw new ArgumentNullException(nameof(input))
        };
    }
}