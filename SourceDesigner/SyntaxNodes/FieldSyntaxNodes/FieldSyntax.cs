using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class FieldSyntax : SyntaxNodeBase
    {
        private readonly AssignmentSyntax? assignment;

        public FieldSyntax(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public FieldModifier Modifiers { get; set; } = FieldModifier.None;
        
        public ExpressionSyntax? AssignmentValue
        {
            get => assignment?.ExpressionSyntax;
            init => assignment = value != null ? new AssignmentSyntax { ExpressionSyntax = value } : assignment = null;
        }

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}" +
            (assignment != null ? $" {assignment.ToCode(style)};" : ";");
    }
}