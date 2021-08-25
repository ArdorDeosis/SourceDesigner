using System;
using System.Linq;

namespace SourceDesigner
{
    public static class EnumExtensions
    {
        // TODO: better exception
        public static string ToCode(this Enum value) =>
            value.GetAttribute<CodeRepresentationAttribute>()?.Code ??
            throw new Exception("No code representation defined!");


        public static string ToCode(this MethodModifier modifiers) => string.Concat(
            EnumUtility.GetAll<MethodModifier>()
                .Where(modifier =>
                    modifier != MethodModifier.None &&
                    modifiers.HasFlag(modifier))
                .Select(modifier => $"{modifier.ToCode()} "));

        public static string ToCode(this ParameterModifier modifiers) => string.Concat(
            EnumUtility.GetAll<ParameterModifier>()
                .Where(modifier =>
                    modifier != ParameterModifier.None &&
                    modifiers.HasFlag(modifier))
                .Select(modifier => $"{modifier.ToCode()} "));

        private static T? GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var memberInfos = enumValue.GetType().GetMember(enumValue.ToString());
            var attributes = memberInfos[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}