using Marey.Lex;

namespace Marey.Ast;

internal sealed class ExprBuilder(TokenStream stream)
{
    internal void Build()
    {
        var tokens = FillUp();

        
    }

    private List<Expr> FillUp()
    {
        List<Expr> expressions = [];

        for (int i = stream.Progress; stream.MismatchesAt(i, TokenKind.StatementEnd); ++i)
        {
            expressions.Add(ExprFactory.NewExpr(stream.At(i)));
        }

        return expressions;
    }
}