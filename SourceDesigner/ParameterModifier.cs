using System;

namespace SourceDesigner
{
    [Flags]
    public enum ParameterModifier
    {
        None,
        This,
        Ref,
        In,
        Out,
        Params
    }
}