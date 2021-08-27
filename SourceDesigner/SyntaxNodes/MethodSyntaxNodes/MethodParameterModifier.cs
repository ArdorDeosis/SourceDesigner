using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    [Flags]
    public enum MethodParameterModifier
    {
        None = 0,
        
        [CodeRepresentation("this")]
        This = 1 << 0,
        
        [CodeRepresentation("ref")]
        Ref = 1 << 1,
        
        [CodeRepresentation("in")]
        In = 1 << 2,
        
        [CodeRepresentation("out")]
        Out = 1 << 3,
        
        [CodeRepresentation("params")]
        Params = 1 << 4,
    }
}