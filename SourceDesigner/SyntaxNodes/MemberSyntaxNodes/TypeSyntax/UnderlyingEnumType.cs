namespace SourceDesigner.SyntaxNodes
{
    public enum UnderlyingEnumType
    {
        [CodeRepresentation("byte")]
        Byte,
        [CodeRepresentation("sbyte")]
        SByte,
        [CodeRepresentation("short")]
        Short,
        [CodeRepresentation("ushort")]
        UShort,
        [CodeRepresentation("int")]
        Int,
        [CodeRepresentation("uint")]
        UInt,
        [CodeRepresentation("long")]
        Long,
        [CodeRepresentation("ulong")]
        ULong
    }
}