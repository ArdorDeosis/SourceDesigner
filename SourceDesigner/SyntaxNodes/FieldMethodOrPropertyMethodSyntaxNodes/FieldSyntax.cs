using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class FieldSyntax : FieldMethodOrPropertySyntax
    {
        private readonly AssignmentSyntax? assignment;

        public FieldSyntax(string type, string name) : base(type, name) { }
        
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