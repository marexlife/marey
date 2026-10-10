namespace Marey.Ast.Expressions;

internal class BinOp : Operator
{
    internal required Operand Lhs { get; init; }
    internal required Operand Rhs { get; init; }
}