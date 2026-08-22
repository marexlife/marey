namespace Marey.Lex;

internal sealed record Token(SourcePos Pos, string Lexeme)
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
        "float" => TokenKind.Float,
        "bool" => TokenKind.Bool,
        "int" => TokenKind.Int,
        _ => TokenKind.Ident,
    };
}