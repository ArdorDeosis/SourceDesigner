using System;

namespace TestApplication
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value) => Value = value;

        public string Value { get; }
    }
}