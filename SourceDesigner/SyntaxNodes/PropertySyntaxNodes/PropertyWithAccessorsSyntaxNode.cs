using System;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class PropertyWithAccessorsSyntaxNode : PropertySyntaxNode
    {
        private readonly AssignmentSyntaxNode? assignment;

        public ExpressionSyntaxNode? AssignmentValue
        {
            get => assignment?.Expression;
            init => assignment = value != null ? new AssignmentSyntaxNode { Expression = value } : assignment = null;
        }

        public PropertyGetAccessorSyntaxNode? Getter { get; init; }
        public PropertySetAccessorSyntaxNode? Setter { get; init; }

        public override string ToCode(CodeStyle style) =>
            $"{GetPropertyHeader()}{Environment.NewLine}{{{Environment.NewLine}" +
            (Getter != null ? $"{Getter.ToCode(style).Indent(style)}{Environment.NewLine}" : "") +
            (Setter != null ? $"{Setter.ToCode(style).Indent(style)}{Environment.NewLine}" : "") +
            (assignment != null ? $"}} {assignment.ToCode(style)};" : "}");
    }
}