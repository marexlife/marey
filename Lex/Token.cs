namespace Marey.Lex;

internal record struct Token(TokenKind TokenKind, TokenPos TokenPos, string Lexeme);