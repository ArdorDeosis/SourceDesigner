using System;
using System.Linq;

namespace SourceDesigner.Utilities
{
    public static class EnumExtensions
    {
        // TODO: better exceptions
        public static string EnumToCode(this Enum value)
        {
            return value.GetAttribute<CodeRepresentationAttribute>()?.Code ??
                   throw new Exception("No code representation defined!");
        }

        public static string FlagEnumToCode<T>(this T value) where T : Enum
        {
            var singleValues = EnumUtilities.GetAll<T>()
                .Where(modifier => !modifier.Equals((T)(object)0))
                .ToArray();
            if (value.Equals((T)(object)0))
                return "";
            if (singleValues.Contains(value))
                return value.GetAttribute<CodeRepresentationAttribute>()?.Code ??
                       throw new Exception("No code representation defined!");
            return string.Join(" ",
                singleValues
                    .Where(modifier => value.HasFlag(modifier))
                    .Select(modifier => $"{modifier.FlagEnumToCode()}"));
        }

        private static T? GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var memberInfos = enumValue.GetType().GetMember(enumValue.ToString());
            var attributes = memberInfos[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}