using System.Collections.Generic;
using System.Linq;

namespace SourceDesigner.SyntaxNodes
{
    public abstract class MethodBodySyntax : SyntaxNodeBase
    {
        public static implicit operator MethodBodySyntax(ExpressionSyntax expressionSyntax) =>
            new ExpressionBodySyntax {ExpressionSyntax = expressionSyntax};
        
        public static implicit operator MethodBodySyntax(StatementSyntax[] statements) =>
            new StatementBodySyntax() {Statements = statements.ToList()};
        
        public static implicit operator MethodBodySyntax(List<StatementSyntax> statements) =>
            new StatementBodySyntax() {Statements = statements};
    }
}