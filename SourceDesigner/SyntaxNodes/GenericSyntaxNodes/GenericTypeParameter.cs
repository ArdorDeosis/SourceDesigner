using System.Collections.Generic;
using System.Linq;

namespace SourceDesigner.SyntaxNodes
{
    public class GenericTypeParameter
    {
        public GenericTypeParameter(string name)
        {
            Name = name;
        }

        public GenericTypeParameter(string name, params string[] constraints)
        {
            Name = name;
            Constraints = constraints.ToList();
        }

        public string Name { get; init; }
        public List<string> Constraints { get; init; } = new();

        internal string? ToGenericTypeConstraintCode(CodeStyle style) => Constraints.Count switch
        {
            > 0 => $"where {Name} : {string.Join(", ", Constraints)}",
            _ => null
        };
    }
}