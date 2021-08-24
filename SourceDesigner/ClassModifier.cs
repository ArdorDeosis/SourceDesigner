using System;

namespace SourceDesigner
{
    [Flags]
    public enum ClassModifier
    {
        None,
        New,
        Static,
        Abstract,
        Sealed,
        Partial,
    }
}