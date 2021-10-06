using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class MethodParameter : SyntaxNodeBase
    {
        public MethodParameter(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public string Type { get; init; }
        public string Name { get; init; }
        public MethodParameterModifier Modifier { get; init; }
        public string? DefaultValue { get; set; }

        private string DefaultValueString => DefaultValue != null ? $" = {DefaultValue}" : "";

        public override string ToCode(CodeStyle style) => 
            $"{Modifier.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}{DefaultValueString}";
    }
}