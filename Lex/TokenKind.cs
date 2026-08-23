namespace Marey.Lex;

internal enum TokenKind : byte
{
    None = 0,
    Ident,

    // functions
    Fun,

    // local variables or fields
    Var,

    StatementEnd,

    OpenBrace,
    CloseBrace,
    OpenBracket,
    CloseBracket,

    Assignment,
    Colon,

    Float,
    Bool,
    Int,
    Extends,
}