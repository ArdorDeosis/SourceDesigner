using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum MethodModifier
    {
        None = 0,

        [CodeRepresentation("virtual")]
        Virtual = 1 << 0,

        [CodeRepresentation("new")]
        New = 1 << 1,

        [CodeRepresentation("override")]
        Override = 1 << 2,

        [CodeRepresentation("sealed")]
        Sealed = 1 << 3,

        [CodeRepresentation("static")]
        Static = 1 << 4,
    }
}