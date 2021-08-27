using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public enum PropertySetterType
    {
        [CodeRepresentation("set")]
        Set,

        [CodeRepresentation("init")]
        Init
    }
}