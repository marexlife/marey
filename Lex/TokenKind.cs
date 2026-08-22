namespace Marey.Lex;

internal enum TokKind : byte
{
    None = 0,

    // functions
    Fun,

    // local variables or fields
    Var,

    StatementEnd,

    StartBrace,
    EndBrace,
}