namespace Marey.Lex;

internal enum TokenKind : byte
{
    None = 0,

    // functions
    Fun,

    // local variables or fields
    Var,

    StatementEnd,
}