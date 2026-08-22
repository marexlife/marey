namespace Marey.Lexer;

internal enum TokenKind : byte
{
    None = 0,

    // functions
    Fun,

    // local variables or fields
    Var,

    StatementEnd,
}