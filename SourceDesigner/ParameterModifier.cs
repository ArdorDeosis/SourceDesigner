using System;

namespace SourceDesigner
{
    [Flags]
    public enum ParameterModifier
    {
        None,
        
        [CodeRepresentation("this")]
        This,
        
        [CodeRepresentation("ref")]
        Ref,
        
        [CodeRepresentation("in")]
        In,
        
        [CodeRepresentation("out")]
        Out,
        
        [CodeRepresentation("params")]
        Params
    }
}