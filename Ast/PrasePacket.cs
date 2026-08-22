namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket(TokenStream tokenStream)
{
    internal TokenStream Tokens { get; } = tokenStream;

    internal int Progress { get; set; }

    internal void Advance() => ++Progress;

    internal void AdvanceIfEqual(Token token)
    {
        if (Kind == token.Kind) Advance();
        else throw new InvalidTokenException(Pos, $"expected {token.Lexeme}, got {Token.Lexeme}");
    }

    internal Token Token => Tokens[Progress];

    internal TokenKind Kind => Token.Kind;

    internal SourcePos Pos => Token.Pos;
}