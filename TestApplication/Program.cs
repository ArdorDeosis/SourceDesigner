using System;
using SourceDesigner.SyntaxNodes;

namespace TestApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var file = new ClassSyntaxNode ("EnumExtensions")
            {
                AccessModifier = AccessModifier.Public,
                Modifiers = ClassModifier.Static | ClassModifier.Partial,
                Methods = 
                {
                    new MethodSyntaxNode
                    {
                        Name = "MyMethod",
                        ReturnType = "string",
                        AccessModifier = AccessModifier.Public,
                        Modifiers = MethodModifier.Static,
                        Parameters = new MethodParameterSyntaxNode[]
                        {
                            new()
                            {
                                Type = "int",
                                Name = "value",
                                Modifier = MethodParameterModifier.This
                            }
                        },
                        Body = new ExpressionBodySyntaxNode
                        {
                            Expression = new SwitchExpressionSyntaxNode
                            {
                                DefaultValue = ExpressionSyntaxNode.FromString("throw new Exception()"),
                                SwitchValueName = "value",
                                ValueExpressionPairs =
                                {
                                    { "1", "one" },
                                    { "2", "two" },
                                    { "3", "three" },
                                }
                            }
                        }
                    }
                }
            };
            Console.WriteLine(file.ToCode());
        }
    }
}