using System;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum Modifier
    {
        None = 0,
        
        [CodeRepresentation("const")]
        Const = 1 << 0,
        
        [CodeRepresentation("static")]
        Static = 1 << 1,
        
        [CodeRepresentation("new")]
        New = 1 << 2,
        
        [CodeRepresentation("override")]
        Override = 1 << 3,
        
        [CodeRepresentation("virtual")]
        Virtual = 1 << 4,
        
        [CodeRepresentation("abstract")]
        Abstract = 1 << 5,
        
        [CodeRepresentation("sealed")]
        Sealed = 1 << 6,
        
        [CodeRepresentation("readonly")]
        Readonly = 1 << 7,
        
        [CodeRepresentation("partial")]
        Partial = 1 << 8,
    }
}