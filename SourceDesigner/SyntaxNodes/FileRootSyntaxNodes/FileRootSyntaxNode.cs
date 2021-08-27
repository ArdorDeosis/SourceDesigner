using System;

namespace SourceDesigner.SyntaxNodes
{
    // TODO
    public class FileRootSyntaxNode
    {
        public UsingDirectiveSyntaxNode[] UsingDirectives { get; init; } = Array.Empty<UsingDirectiveSyntaxNode>();
        public NamespaceSyntaxNode[] Namespaces { get; init; } = Array.Empty<NamespaceSyntaxNode>();
        public ClassSyntaxNode[] Classes { get; init; } = Array.Empty<ClassSyntaxNode>();
        public StructSyntaxNode[] Structs { get; init; } = Array.Empty<StructSyntaxNode>();
        public RecordSyntaxNode[] Records { get; init; } = Array.Empty<RecordSyntaxNode>();
        public InterfaceSyntaxNode[] Interfaces { get; init; } = Array.Empty<InterfaceSyntaxNode>();
        public EnumSyntaxNode[] Enums { get; init; } = Array.Empty<EnumSyntaxNode>();
    }
}