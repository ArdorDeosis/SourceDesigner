namespace SourceDesigner
{
    public class ParameterNode
    {
        public string Type { get; init; }
        public string Name { get; init; }
        public ParameterModifier Modifier { get; init; }
        public string? DefaultValue { get; set; }
    }
}