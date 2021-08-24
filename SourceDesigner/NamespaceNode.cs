﻿using System.Collections.Generic;

namespace SourceDesigner
{
    public class NamespaceNode
    {
        public NamespaceNode(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public List<UsingDirective> UsingDirectives { get; init; } = new();
        public List<NamespaceNode> Namespaces { get; init; } = new();
        public List<ClassNode> Classes { get; init; } = new();
        public List<StructNode> Structs { get; init; } = new();
        public List<RecordNode> Records { get; init; } = new();
        public List<InterfaceNode> Interfaces { get; init; } = new();
        public List<EnumNode> Enums { get; init; } = new();
    }
}