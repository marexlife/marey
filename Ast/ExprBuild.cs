using Marey.Ast.Expressions;

namespace Marey.Ast;

internal static class ExprBuild
{
    internal static Expr BuildExpression(List<Expr> expressions)
    {
        var expr = new Expr();
        Expr? previous = null;
        var previousWasMorePowerful = false;

        foreach (var expression in expressions)
        {
            switch (expression)
            {
                
            }
        }

        return expr;
    }
}