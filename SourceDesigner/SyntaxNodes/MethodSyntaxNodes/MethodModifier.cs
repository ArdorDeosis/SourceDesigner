﻿using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum MethodModifier
    {
        None = 0,

        [CodeRepresentation("new")]
        New = 1 << 0,
        
        [CodeRepresentation("abstract")]
        Abstract = 1 << 1,

        [CodeRepresentation("virtual")]
        Virtual = 1 << 2,

        [CodeRepresentation("override")]
        Override = 1 << 3,

        [CodeRepresentation("sealed")]
        Sealed = 1 << 4,

        [CodeRepresentation("static")]
        Static = 1 << 5,
    }
}