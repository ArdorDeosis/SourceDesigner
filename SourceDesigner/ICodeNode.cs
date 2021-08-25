namespace SourceDesigner
{
    public interface ICodeNode
    {
        public string ToCode();

        public string ToCode(CodeStyle style);
    }
}