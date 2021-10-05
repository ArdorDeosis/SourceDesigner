using System;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum TypeModifier
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
        
        [CodeRepresentation("readonly")]
        Readonly = 1 << 4,
        
        [CodeRepresentation("partial")]
        Partial = 1 << 5,
    }
}