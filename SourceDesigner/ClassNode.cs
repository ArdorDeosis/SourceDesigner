using System.Collections.Generic;

namespace SourceDesigner
{
    public class ClassNode
    {
        public ClassNode(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public ClassModifier Modifiers { get; set; } = ClassModifier.None;
        
        public List<ClassNode> Classes { get; init; } = new();
        public List<StructNode> Structs { get; init; } = new();
        public List<RecordNode> Records { get; init; } = new();
        public List<InterfaceNode> Interfaces { get; init; } = new();
        public List<EnumNode> Enums { get; init; } = new();
        public List<MethodNode> Methods { get; init; } = new();
        public List<FieldNode> Fields { get; init; } = new();
        public List<PropertyNode> Properties { get; init; } = new();
    }
}