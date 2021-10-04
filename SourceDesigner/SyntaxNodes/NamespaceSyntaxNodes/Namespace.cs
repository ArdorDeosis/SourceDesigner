using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.SyntaxNodes.FileRootSyntaxNodes;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public class Namespace : SyntaxNodeBase
    {
        public Namespace(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public List<UsingDirectiveSyntaxNode> UsingDirectives { get; init; } = new();
        public List<Namespace> Namespaces { get; init; } = new();
        public List<ClassSyntax> Classes { get; init; } = new();
        public List<StructSyntax> Structs { get; init; } = new();
        public List<RecordSyntax> Records { get; init; } = new();
        public List<InterfaceSyntax> Interfaces { get; init; } = new();
        public List<EnumSyntax> Enums { get; init; } = new();
        
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