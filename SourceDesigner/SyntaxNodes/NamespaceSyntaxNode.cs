using System;
using System.Collections.Generic;

namespace SourceDesigner.SyntaxNodes
{
    public class NamespaceSyntaxNode
    {
        public string Name { get; init; }

        public UsingDirectiveSyntaxNode[] UsingDirectives { get; init; } = Array.Empty<UsingDirectiveSyntaxNode>();
        public NamespaceSyntaxNode[] Namespaces { get; init; } = Array.Empty<NamespaceSyntaxNode>();
        public ClassSyntaxNode[] Classes { get; init; } = Array.Empty<ClassSyntaxNode>();
        public StructSyntaxNode[] Structs { get; init; } = Array.Empty<StructSyntaxNode>();
        public RecordSyntaxNode[] Records { get; init; } = Array.Empty<RecordSyntaxNode>();
        public InterfaceSyntaxNode[] Interfaces { get; init; } = Array.Empty<InterfaceSyntaxNode>();
        public EnumSyntaxNode[] Enums { get; init; } = Array.Empty<EnumSyntaxNode>();
    }
}