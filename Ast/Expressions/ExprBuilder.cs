namespace Marey.Ast.Expressions;

internal sealed class ExprBuilder(List<Expr> expressions)
{
    private ExprViewer _exprViewer = new(expressions);

    public void Build()
    {
        for (; _exprViewer.Peak != null; _exprViewer.Advance())
        {
            
        }
    }
}