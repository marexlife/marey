using Marey.Ast.Expressions;

namespace Marey.Ast;

internal sealed class ExprBuild
{
    internal int Progress { get; private set; } = 0;
    internal Expr Current => _expressions[Progress];
    internal Expr? Next
    {
        get
        {
            var target = Progress + 1;

            return
                target < _expressions.Count ?
                _expressions[target] : null;
        }
    }

    private List<Expr> _expressions = [];

    internal bool IsNextMorePowerful
    {
        get
        {
            if (Next == null)
            {
                throw new Exception("Should not have been called.");
            }

            return Current.GetBindingPower() < Next.GetBindingPower();
        }
    }
}