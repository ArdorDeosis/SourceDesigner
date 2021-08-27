using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum ClassModifier
    {
        None = 0,
        
        [CodeRepresentation("new")]
        New = 1 << 0,
        
        [CodeRepresentation("static")]
        Static = 1 << 1,
        
        [CodeRepresentation("abstract")]
        Abstract = 1 << 2,
        
        [CodeRepresentation("sealed")]
        Sealed = 1 << 3,
        
        [CodeRepresentation("partial")]
        Partial = 1 << 4,
    }
}