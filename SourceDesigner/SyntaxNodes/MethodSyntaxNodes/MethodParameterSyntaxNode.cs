using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class MethodParameterSyntaxNode : SyntaxNodeBase
    {
        public string Type { get; init; }
        public string Name { get; init; }
        public MethodParameterModifier Modifier { get; init; }
        public string? DefaultValue { get; set; }

        private string DefaultValueString => DefaultValue != null ? $" = {DefaultValue}" : "";

        public override string ToCode(CodeStyle style) => 
            $"{Modifier.FlagEnumToCode().AddTrailingSpace()}{Type} {Name}{DefaultValueString}";
    }
}