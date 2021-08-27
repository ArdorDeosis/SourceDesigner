using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class FieldSyntaxNode : SyntaxNodeBase
    {
        private readonly AssignmentSyntaxNode? assignment;
        
        public string Name { get; init; }
        public string Type { get; init; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public FieldModifier Modifiers { get; set; } = FieldModifier.None;
        
        public ExpressionSyntaxNode? AssignmentValue
        {
            get => assignment?.Expression;
            init => assignment = value != null ? new AssignmentSyntaxNode { Expression = value } : assignment = null;
        }

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Type} {Name}" +
            (assignment != null ? $" {assignment.ToCode(style)};" : ";");
    }
}