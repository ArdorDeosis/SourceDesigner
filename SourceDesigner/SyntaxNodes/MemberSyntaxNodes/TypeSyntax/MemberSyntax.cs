namespace SourceDesigner.SyntaxNodes
{
    public abstract class MemberSyntax : SyntaxNodeBase
    {
        public MemberSyntax(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
    }
}