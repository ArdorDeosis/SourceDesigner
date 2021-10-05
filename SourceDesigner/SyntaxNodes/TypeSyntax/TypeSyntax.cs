using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class TypeSyntax : MemberSyntax
    {
        public TypeSyntax(string name) : base(name) { }

        public TypeModifier Modifiers { get; set; } = TypeModifier.None;

        public string BaseType
        {
            init => BaseTypes = new List<string> {value};
        }

        public List<string> BaseTypes { get; set; } = new();
        
        public List<GenericTypeParameter> GenericTypeParameters { get; init; } = new();
        
        public List<ClassSyntax> Classes { get; init; } = new();
        public List<StructSyntax> Structs { get; init; } = new();
        public List<RecordSyntax> Records { get; init; } = new();
        public List<InterfaceSyntax> Interfaces { get; init; } = new();
        public List<EnumSyntax> Enums { get; init; } = new();
        public List<MethodSyntax> Methods { get; init; } = new();
        public List<FieldSyntax> Fields { get; init; } = new();
        public List<PropertySyntax> Properties { get; init; } = new();
        
        protected abstract string Keyword { get; }

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Keyword} {Name}" +
            $"{GetBaseTypesAndGenericConstraints(style)}" +
            $"{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetBodyCodeBlock(CodeStyle style)
        {
            List<string> members = new();
            members.AddRange(Interfaces.Select(member => member.ToCode(style)));
            members.AddRange(Classes.Select(member => member.ToCode(style)));
            members.AddRange(Records.Select(member => member.ToCode(style)));
            members.AddRange(Structs.Select(member => member.ToCode(style)));
            members.AddRange(Enums.Select(member => member.ToCode(style)));
            members.AddRange(Fields.Select(member => member.ToCode(style)));
            members.AddRange(Properties.Select(member => member.ToCode(style)));
            members.AddRange(Methods.Select(member => member.ToCode(style)));
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", members);
        }

        private string GetBaseTypesAndGenericConstraints(CodeStyle style)
        {
            var output = string.Join(" ", 
                string.Join(", ", BaseTypes), 
                GenericTypeParameters.ToGenericTypeConstraintCode(style));
            return output.Length > 0 ? " : " + output : "";
        }
    }
}