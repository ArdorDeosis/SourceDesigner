using System;
using System.Collections.Generic;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class PropertyWithAccessors : Property
    {
        private readonly Assignment? assignment;

        public ExpressionSyntax? AssignmentValue
        {
            get => assignment?.ExpressionSyntax;
            init => assignment = value != null ? new Assignment { ExpressionSyntax = value } : assignment = null;
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
            if (Setter != null)
                accessorBodies.Add(Setter.ToCode(style));
            return string.Join(Environment.NewLine, accessorBodies);
        }

        public PropertyWithAccessors(string type, string name) : base(type, name)
        {
        }
    }
}