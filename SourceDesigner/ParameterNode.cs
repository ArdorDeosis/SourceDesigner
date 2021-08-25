namespace SourceDesigner
{
    public class ParameterNode : CodeNodeBase
    {
        public string Type { get; init; }
        public string Name { get; init; }
        public ParameterModifier Modifier { get; init; }
        public string? DefaultValue { get; set; }

        private string DefaultValueString => DefaultValue != null ? $" = {DefaultValue}" : "";
        
        public override string ToCode(CodeStyle style)
        {
            return $"{Modifier.ToCode()}{Type} {Name}{DefaultValueString}";
        }
    }
}