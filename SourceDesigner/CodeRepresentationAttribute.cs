using System;

namespace SourceDesigner
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class CodeRepresentationAttribute : Attribute
    {
        internal string Code { get; }

        internal CodeRepresentationAttribute(string code)
        {
            Code = code;
        }
    }
}