using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum PropertyModifier
    {
        None = 0,
        
        [CodeRepresentation("new")]
        New = 1 << 0,
        
        [CodeRepresentation("static")]
        Static = 1 << 1,
        
        [CodeRepresentation("override")]
        Override = 1 << 2,
        
        [CodeRepresentation("virtual")]
        Virtual = 1 << 3,
    }
}