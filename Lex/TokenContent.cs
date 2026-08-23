namespace Marey.Lex;

internal sealed record TokenContent(string Lexeme, TokenKind Kind)
{
    internal TokenContent(string lexeme) : this(lexeme, LexemeToKind(lexeme))
    {
    }

    private static TokenKind LexemeToKind(string lexeme) => KeywordConfig.MapStringToTokenKind(lexeme);
}