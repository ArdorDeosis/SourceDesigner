using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SourceDesigner.SyntaxNodes;

namespace FastJsonConversion.Generator
{
    [Generator]
    public class JsonConvertMethodGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            var classSyntaxNodes = context.Compilation.SyntaxTrees
                .Select(syntaxTree => syntaxTree.GetRoot())
                .SelectMany(node => node.DescendantNodesAndSelf()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(classNode => classNode.AttributeLists
                        .SelectMany(list => list.Attributes)
                        .Any(attribute => attribute.Name.ToString()
                            is nameof(FastJsonConversionAttribute)
                            or "FastJsonConversion")));
            foreach (var classDeclarationSyntax in classSyntaxNodes)
            {
                // make method
                var properties = classDeclarationSyntax.Members.OfType<PropertyDeclarationSyntax>();
                var jsonConversionMethod = new Method("string", "ToJson")
                {
                    Body = Expression.FromString(
                        $"\"{{{string.Join(",", properties.Select(PropertyToJson))}}}\""
                    )
                };
                var namespaces = FindParentsOfType(classDeclarationSyntax, typeof(NamespaceDeclarationSyntax))
                    .OfType<NamespaceDeclarationSyntax>()
                    .Select(namespaceSyntax => new NamespaceSyntaxNode(namespaceSyntax.Name.ToString()))
                    .ToList();
                for (var index = 0; index < namespaces.Count - 1; index++)
                    namespaces[index].Namespaces.Add(namespaces[index + 1]);
                namespaces.Last().Classes.Add(new Class(classDeclarationSyntax.Identifier.ToString())
                {
                    AccessModifier = AccessModifier.Public,
                    Modifiers = ClassModifier.Partial,
                    Methods = {jsonConversionMethod}
                });
                context.AddSource(
                    $"{classDeclarationSyntax.Identifier}.ToJson.Generated.cs",
                    namespaces.First().ToCode());
            }

            context.ReportDiagnostic(Diagnostic.Create(
                new DiagnosticDescriptor("FastJson", "FastJson source generation finished", ";_;", "FastJsonCategory",
                    DiagnosticSeverity.Error, true), Location.None));
        }

        private static List<SyntaxNode> FindParentsOfType(SyntaxNode node, params Type[] types)
        {
            var result = new Stack<SyntaxNode>();
            var current = node;
            while (current != null)
            {
                if (types.Contains(current.GetType()))
                    result.Push(current);
                current = current.Parent;
            }

            return result.ToList();
        }

        private static string PropertyToJson(PropertyDeclarationSyntax property)
        {
            // TODO: type specific stuff
            return $"\"{property.Identifier}\":{{{property.Identifier}}}";
        }
    }
}