using System.Collections.Generic;
using System.Linq;

namespace SourceDesigner
{
    public class MethodNode : CodeNodeBase
    {
        public MethodNode(string name, string returnType)
        {
            Name = name;
            ReturnType = returnType;
        }

        public string Name { get; }
        public string ReturnType { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public MethodModifier Modifiers { get; set; } = MethodModifier.None;
        public List<ParameterNode> Parameters { get; init; } = new();
        public List<StatementNode> Statements { get; init; } = new();

        public override string ToCode(CodeStyle style)
        {
            // TODO: statements
            return $"{AccessModifier.ToCode()} {Modifiers.ToCode()}{ReturnType} {Name} ({GetParameterList(style)})\n{{\n}}";
        }
        
        private string GetParameterList(CodeStyle style) =>
            string.Join(", ", Parameters.Select(parameterNode => parameterNode.ToCode(style)));
    }
}