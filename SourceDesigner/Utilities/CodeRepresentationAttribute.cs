using System;

namespace SourceDesigner.Utilities
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CodeRepresentationAttribute : Attribute
    {
        public string Code { get; }

        public CodeRepresentationAttribute(string code)
        {
            Code = code;
        }
    }
}