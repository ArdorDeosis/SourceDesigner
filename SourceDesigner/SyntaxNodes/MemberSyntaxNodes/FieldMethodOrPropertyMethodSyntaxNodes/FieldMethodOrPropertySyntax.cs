namespace SourceDesigner.SyntaxNodes
{
    public abstract class FieldMethodOrPropertySyntax : MemberSyntax
    {
        public FieldMethodOrPropertySyntax(string type, string name) : base(name)
        {
            Type = type;
        }

        public string Type { get; init; }
    }
}