namespace Marey.Lex;

internal sealed record Token(SourcePos Pos, string Lexeme)
{
    internal TokenContent Content { get; } = new(Lexeme);

    internal TokenKind Kind => Content.Kind;
}