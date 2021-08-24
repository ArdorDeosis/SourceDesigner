using System.Collections.Generic;

namespace SourceDesigner
{
    public class MethodNode
    {
        public string Name { get; }
        public string ReturnType { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public MethodModifier Modifiers { get; set; } = MethodModifier.None;
        public List<ParameterNode> Parameters { get; init; } = new();
        public List<StatementNode> Statements { get; init; } = new();
    }
}