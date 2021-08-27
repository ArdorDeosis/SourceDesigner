namespace SourceDesigner
{
    public record CodeStyle
    {
        public int SpacesPerIndentation { get; init; } = 4;
        public bool NewLineBeforeExpressionBody { get; init; } = false;

        public static CodeStyle Default => new();
        
        public string Indentation => new(' ', SpacesPerIndentation);
    }
}