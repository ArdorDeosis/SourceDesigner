using System;

namespace SourceDesigner
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