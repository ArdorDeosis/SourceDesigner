using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class NamespaceSyntaxNode : SyntaxNodeBase
    {
        public NamespaceSyntaxNode(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public List<UsingDirectiveSyntaxNode> UsingDirectives { get; } = new();
        public List<NamespaceSyntaxNode> Namespaces { get; } = new();
        public List<Class> Classes { get; } = new();
        public List<StructSyntaxNode> Structs { get; } = new();
        public List<RecordSyntaxNode> Records { get; } = new();
        public List<InterfaceSyntaxNode> Interfaces { get; } = new();
        public List<EnumSyntaxNode> Enums { get; } = new();
        
        public override string ToCode(CodeStyle style) => 
            $"namespace {Name}{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetBodyCodeBlock(CodeStyle style)
        {
            List<string> members = new();
            if (UsingDirectives.Count > 0)
                members.Add(GetUsingDirectivesCodeBlock(style));
            members.AddRange(Namespaces.Select(member => member.ToCode(style)));
            members.AddRange(Interfaces.Select(member => member.ToCode(style)));
            members.AddRange(Classes.Select(member => member.ToCode(style)));
            members.AddRange(Records.Select(member => member.ToCode(style)));
            members.AddRange(Structs.Select(member => member.ToCode(style)));
            members.AddRange(Enums.Select(member => member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }
        
        private string GetUsingDirectivesCodeBlock(CodeStyle style) => 
            string.Join(Environment.NewLine, UsingDirectives.Select(usingDirective => usingDirective.ToCode(style)));
    }
}