using System;

namespace SourceDesigner
{
    [Flags]
    public enum MethodModifier
    {
        None,

        [CodeRepresentation("abstract")]
        Abstract,

        [CodeRepresentation("new")]
        New,

        [CodeRepresentation("override")]
        Override,

        [CodeRepresentation("sealed")]
        Sealed,

        [CodeRepresentation("static")]
        Static,
    }
}