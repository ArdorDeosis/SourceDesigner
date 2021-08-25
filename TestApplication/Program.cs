using System;
using System.Collections.Generic;
using SourceDesigner;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var method = new MethodNode("MyMethod", "string")
            {
                AccessModifier = AccessModifier.Public,
                Modifiers = MethodModifier.Static,
                Parameters = new List<ParameterNode>
                {
                    new()
                    {
                        Type = "SomeType",
                        Name = "value",
                        Modifier = ParameterModifier.This
                    },
                    new()
                    {
                        Type = "string",
                        Name = "someParameter"
                    }
                }
            };
            Console.WriteLine(method.ToCode());
        }
    }
}