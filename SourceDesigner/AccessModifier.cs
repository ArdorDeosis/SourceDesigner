namespace SourceDesigner
{
    public enum AccessModifier
    {
        [CodeRepresentation("private")]
        Private,
        
        [CodeRepresentation("private protected")]
        PrivateProtected,
        
        [CodeRepresentation("protected")]
        Protected,
        
        [CodeRepresentation("internal")]
        Internal,
        
        [CodeRepresentation("protected internal")]
        ProtectedInternal,
        
        [CodeRepresentation("public")]
        Public
    }
}