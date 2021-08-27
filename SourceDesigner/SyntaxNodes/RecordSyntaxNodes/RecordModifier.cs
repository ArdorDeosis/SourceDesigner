using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum RecordModifier
    {
        None = 0,
        
        [CodeRepresentation("new")]
        New = 1 << 0,
        
        [CodeRepresentation("abstract")]
        Abstract = 1 << 1,
        
        [CodeRepresentation("sealed")]
        Sealed = 1 << 2,
        
        [CodeRepresentation("partial")]
        Partial = 1 << 3,
    }
}