using System;
using System.Collections.Generic;
using SourceDesigner.SyntaxNodes;

namespace TestApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var @class = new ClassSyntaxNode
            {
                AccessModifier = AccessModifier.Public,
                Modifiers = ClassModifier.Static | ClassModifier.Partial,
                Name = "EnumExtensions",
                Methods = new MethodSyntaxNode[]
                {
                    new ExpressionBodiedMethodSyntaxNode
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
                        Expression = new SwitchExpressionSyntaxNode
                        {
                            DefaultValue = new RawExpressionSyntaxNode("throw new Exception()"),
                            Value = "value",
                            ValueExpressionPairs = new Dictionary<string, ExpressionSyntaxNode>
                            {
                                { "1", "one" },
                                { "2", "two" },
                                { "3", "three" },
                            }
                        }
                    }
                }
            };
            Console.WriteLine(@class.ToCode());
        }
    }
}