using System;
using System.Collections.Generic;
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
            $"{GetPropertyHeader()}{Environment.NewLine}{GetAccessorsCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetAccessorsCodeBlock(CodeStyle style)
        {
            List<string> accessorBodies = new();
            if (Getter != null)
                accessorBodies.Add(Getter.ToCode(style));
            if(Setter != null)
                accessorBodies.Add(Setter.ToCode(style));
            return string.Join(Environment.NewLine, accessorBodies);
        }
    }
}