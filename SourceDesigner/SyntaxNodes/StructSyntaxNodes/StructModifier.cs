using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum StructModifier
    {
        None = 0,
        
        [CodeRepresentation("new")]
        New = 1 << 0,
        
        [CodeRepresentation("readonly")]
        Readonly = 1 << 1,
        
        [CodeRepresentation("partial")]
        Partial = 1 << 2,
    }
}