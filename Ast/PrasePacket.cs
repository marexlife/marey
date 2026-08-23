namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket(TokenStream tokenStream)
{
    internal TokenStream Tokens { get; } = tokenStream;

    internal int Progress { get; set; }

    internal void Advance() => ++Progress;

    internal Token AdvanceIfEqual(TokenKind tokenKind)
    {
        if (Kind == tokenKind)
        {
            var preAdvanceToken = Token;

            Advance();

            return preAdvanceToken;
        }
        else
        {
            throw new InvalidTokenException(
                Pos, $"expected {tokenKind}, got {Token.Lexeme}");
        }
    }

    internal Token Token => Tokens[Progress];

    internal TokenKind Kind => Token.Kind;

    internal SourcePos Pos => Token.Pos;
}