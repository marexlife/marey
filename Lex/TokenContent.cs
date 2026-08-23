namespace Marey.Lex;

internal sealed record TokenContent(string Lexeme, TokenKind Kind)
{
    internal TokenContent(string lexeme) : this(lexeme, LexemeToKind(lexeme))
    {
    }

    private static TokenKind LexemeToKind(string lexeme) => lexeme switch
    {
        "{" => TokenKind.OpenBrace,
        "(" => TokenKind.OpenBracket,
        ")" => TokenKind.CloseBracket,
        "}" => TokenKind.CloseBrace,
        "=" => TokenKind.Assignment,
        "fun" => TokenKind.Fun,
        "var" => TokenKind.Var,
        ";" => TokenKind.StatementEnd,
        ":" => TokenKind.Colon,
        "float" => TokenKind.Float,
        "bool" => TokenKind.Bool,
        "int" => TokenKind.Int,
        _ => TokenKind.Ident,
    };
}