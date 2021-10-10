using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.Utilities;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class TypeSyntax : EnumOrTypeSyntax
    {
        public TypeSyntax(string name) : base(name) { }

        public string BaseType
        {
            init => BaseTypes = new List<string> {value};
        }

        public List<string> BaseTypes { get; set; } = new();
        
        public List<GenericTypeParameter> GenericTypeParameters { get; init; } = new();
        
        public List<MemberSyntax> Members { get; init; } = new();
        
        protected abstract string Keyword { get; }

        public override string ToCode(CodeStyle style) =>
            $"{AccessModifier.EnumToCode()} {Modifiers.FlagEnumToCode().WithTrailingSpace()}{Keyword} {Name}" +
            $"{GetBaseTypesAndGenericConstraints(style)}" +
            $"{Environment.NewLine}{GetBodyCodeBlock(style).WrapInBracesAndIndent(style)}";

        private string GetBodyCodeBlock(CodeStyle style)
        {
            return string.Join($"{Environment.NewLine}{Environment.NewLine}", Members
                .OrderBy(Type).ThenBy(Modifier).ThenBy(Access));

            // TODO: pull comparer into code style
            int Type(MemberSyntax member) => member switch
            {
                InterfaceSyntax => 0,
                EnumSyntax => 1,
                ClassSyntax => 2,
                RecordSyntax => 3,
                StructSyntax => 4,
                PropertySyntax => 5,
                FieldSyntax => 6,
                MethodSyntax => 7,
                _ => 8
            };
            int Modifier(MemberSyntax member) => member.Modifiers switch
            {
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Const) => 0,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Static) => 1,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Readonly) => 2,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Abstract) => 3,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Virtual) => 4,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Partial) => 5,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Override) => 6,
                SyntaxNodes.Modifier.None  => 7,
                _ when member.Modifiers.HasFlag(SyntaxNodes.Modifier.Sealed) => 8,
                _ => 9
            };
            int Access(MemberSyntax member) => member.AccessModifier switch
            {
                AccessModifier.Public => 0,
                AccessModifier.Internal => 1,
                AccessModifier.Protected => 2,
                AccessModifier.ProtectedInternal => 3,
                AccessModifier.PrivateProtected => 4,
                AccessModifier.Private => 5,
                _ => 6
            };
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