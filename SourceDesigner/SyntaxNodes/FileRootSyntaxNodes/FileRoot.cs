using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceDesigner.SyntaxNodes.FileRootSyntaxNodes
{
    public class FileRoot : SyntaxNodeBase
    {
        public List<UsingDirectiveSyntaxNode> UsingDirectives { get; } = new();
        public List<Namespace> Namespaces { get; } = new();
        public List<ClassSyntax> Classes { get; } = new();
        public List<StructSyntax> Structs { get; } = new();
        public List<RecordSyntax> Records { get; } = new();
        public List<InterfaceSyntax> Interfaces { get; } = new();
        public List<EnumSyntax> Enums { get; } = new();
        
        public override string ToCode(CodeStyle style)
        {
            List<string> members = new();
            if (UsingDirectives.Count > 0)
                members.Add(string.Join(Environment.NewLine, UsingDirectives.Select(usingDirective => usingDirective.ToCode(style))));
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