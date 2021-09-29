using System;
using SourceDesigner.SyntaxNodes;

namespace TestApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var myClass = new Class("EnumExtensions")
            {
                AccessModifier = AccessModifier.Public,
                Modifiers = ClassModifier.Static | ClassModifier.Partial,
                Methods =
                {
                    new Method("string", "MyMethod")
                    {
                        AccessModifier = AccessModifier.Public,
                        Modifiers = MethodModifier.Static,
                        Parameters = new MethodParameter[]
                        {
                            new()
                            {
                                Type = "int",
                                Name = "value",
                                Modifier = MethodParameterModifier.This
                            }
                        },
                        Body = new SwitchExpression
                        {
                            DefaultValue = Expression.FromString("throw new Exception()"),
                            SwitchValueName = "value",
                            ValueExpressionPairs =
                            {
                                {"1", "one"},
                                {"2", "two"},
                                {"3", "three"},
                            }
                        }
                    }
                }
            };
            Console.WriteLine(myClass.ToCode());
        }
    }
}