namespace Marey.Lex;

public record Token(SourcePos Pos, string Lexeme)
{
    internal TokenKind Kind => Lexeme switch
    {
        "{" => TokenKind.OpenBrace,
        "(" => TokenKind.OpenBracket,
        ")" => TokenKind.CloseBracket,
        "}" => TokenKind.CloseBrace,
        "fun" => TokenKind.Fun,
        "var" => TokenKind.Var,
        ";" => TokenKind.StatementEnd,
        _ => TokenKind.Ident,
    };
}