namespace SourceDesigner
{
    public abstract class CodeNodeBase : ICodeNode
    {
        public string ToCode() => ToCode(new CodeStyle());

        public abstract string ToCode(CodeStyle style);
    }
}