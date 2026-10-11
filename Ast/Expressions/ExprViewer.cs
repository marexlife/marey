namespace Marey.Ast.Expressions;

internal sealed class ExprViewer(List<Expr> expressions)
{
    internal int Progress { get; private set; } = 0;
    internal Expr Current => expressions[Progress];
    internal Expr? Peak => At(Progress + 1);

    internal void Advance() => ++Progress;

    internal Expr? Next()
    {
        return At(++Progress);
    }

    internal Expr? At(int target)
    {
        return target < expressions.Count ?
                expressions[target] : null;
    }

    internal bool IsNextMorePowerful
    {
        get
        {
            if (Peak == null)
            {
                throw new
                    Exception("Should not have been called.");
            }

            return
                Current.GetBindingPower() <
                Peak.GetBindingPower();
        }
    }
}