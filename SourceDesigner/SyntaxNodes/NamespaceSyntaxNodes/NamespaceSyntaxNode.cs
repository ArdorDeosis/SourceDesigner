using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class NamespaceSyntaxNode : SyntaxNodeBase
    {
        public string Name { get; init; }

        public UsingDirectiveSyntaxNode[] UsingDirectives { get; init; } = Array.Empty<UsingDirectiveSyntaxNode>();
        public NamespaceSyntaxNode[] Namespaces { get; init; } = Array.Empty<NamespaceSyntaxNode>();
        public ClassSyntaxNode[] Classes { get; init; } = Array.Empty<ClassSyntaxNode>();
        public StructSyntaxNode[] Structs { get; init; } = Array.Empty<StructSyntaxNode>();
        public RecordSyntaxNode[] Records { get; init; } = Array.Empty<RecordSyntaxNode>();
        public InterfaceSyntaxNode[] Interfaces { get; init; } = Array.Empty<InterfaceSyntaxNode>();
        public EnumSyntaxNode[] Enums { get; init; } = Array.Empty<EnumSyntaxNode>();
        
        public override string ToCode(CodeStyle style)
        {
            // TODO: not quite correct line breaks
            var usingDirectiveCode = GetUsingDirectivesAsCode(style);
            var memberCode = GetUsingDirectivesAsCode(style);
            return $"namespace {Name}{Environment.NewLine}{{{Environment.NewLine}{usingDirectiveCode.Indent(style)}" +
                   (string.IsNullOrWhiteSpace(usingDirectiveCode) ? "" : $"{Environment.NewLine}{Environment.NewLine}") +
                   usingDirectiveCode.Indent(style) + (string.IsNullOrWhiteSpace(memberCode) ? "" : $"{Environment.NewLine}") +
                   "}";
        }

        private string GetUsingDirectivesAsCode(CodeStyle style) => 
            string.Join(Environment.NewLine, UsingDirectives.Select(usingDirective => usingDirective.ToCode(style)));

        private string GetMembersAsCode(CodeStyle style)
        {
            List<string> members = new();
            members.AddRange(Namespaces.Select(member => member.ToCode(style)));
            members.AddRange(Interfaces.Select(member => member.ToCode(style)));
            members.AddRange(Classes.Select(member => member.ToCode(style)));
            members.AddRange(Records.Select(member => member.ToCode(style)));
            members.AddRange(Structs.Select(member => member.ToCode(style)));
            members.AddRange(Enums.Select(member => member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }
    }
}