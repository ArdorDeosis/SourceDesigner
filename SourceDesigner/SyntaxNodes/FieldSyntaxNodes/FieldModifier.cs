using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum FieldModifier
    {
        None = 0,
        
        [CodeRepresentation("new")]
        New = 1 << 0,
        
        [CodeRepresentation("static")]
        Static = 1 << 1,
        
        [CodeRepresentation("readonly")]
        Readonly = 1 << 2,
        
        [CodeRepresentation("const")]
        Const = 1 << 3,
    }
}