namespace SourceDesigner.SyntaxNodes
{
    public abstract class EnumOrTypeSyntax : MemberSyntax
    {
        public EnumOrTypeSyntax(string name) : base(name)
        {
        }
    }
}