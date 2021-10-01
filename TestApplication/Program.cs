using System;
using System.Collections.Generic;
using System.Linq;
using SourceDesigner.SyntaxNodes;
using Enum = System.Enum;

namespace TestApplication
{
    internal static class Program
    {
        public static List<(Enum, string)> ListRetrievedFromTheCompilation = new()
        {
            (TestEnum.Value1, "value 1"),
            (TestEnum.Value2, "value 2"),
            (TestEnum.Value3, "value 3"),
        };

        private static void Main()
        {
            var myClass = new ClassSyntax("EnumExtensions")
            {
                AccessModifier = AccessModifier.Public,
                Modifiers = ClassModifier.Static | ClassModifier.Partial,
                Methods =
                {
                    new Method("string", "ToStringRepresentation")
                    {
                        AccessModifier = AccessModifier.Public,
                        Modifiers = MethodModifier.Static,
                        Parameters = new MethodParameter[]
                        {
                            new("int", "value") { Modifier = MethodParameterModifier.This }
                        },
                        Body = new SwitchExpressionSyntax ("value")
                        {
                            DefaultValue = ExpressionSyntax.FromString("throw new Exception()"),
                            ValueExpressionPairs = ListRetrievedFromTheCompilation.ToDictionary(
                                tuple => tuple.Item1.ToString(),
                                tuple => (ExpressionSyntax)tuple.Item2
                            )
                        }
                    }
                }
            };


            Console.WriteLine(myClass.ToCode());
        }
    }
}