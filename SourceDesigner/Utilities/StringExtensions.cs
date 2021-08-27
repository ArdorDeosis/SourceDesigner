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

        public static string AddTrailingSpace(this string input) => input switch
        {
            "" => "",
            not null => $"{input} ",
            _ => throw new ArgumentNullException(nameof(input))
        };

        public static bool IsValidIdentifier(this string value) => 
            Regex.IsMatch(value, "^@?[a-zA-Z_][a-zA-Z0-9_]*$");

        public static bool IsValidTypeName(this string value) => 
            Regex.IsMatch(value, @"^(?:[a-zA-Z_][a-zA-Z0-9_]*)(?:\.[a-zA-Z_][a-zA-Z0-9_]*)*$");
    }
}