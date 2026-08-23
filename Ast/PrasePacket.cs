namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket(TokenStream tokenStream)
{
    internal TokenStream Tokens { get; } = tokenStream;

    internal int Progress { get; set; }

    internal void Advance() => ++Progress;

    internal void ForAdvanceIfEqual(TokenKind[] comparers)
    {
        foreach (var comparer in comparers)
        {
            AdvanceIfEqual(comparer);
        }
    }

    internal bool IsEqual(TokenKind comparer) => Kind == comparer;

    internal Token AdvanceIfEqual(TokenKind comparer = TokenKind.Ident)
    {
        if (Kind == comparer)
        {
            var preAdvanceToken = Token;

            Advance();

            return preAdvanceToken;
        }
        else
        {
            throw new InvalidTokenException(
                Pos, $"expected {comparer.FromEnumToString()}, got {Token.Lexeme}");
        }
    }

    internal Token Token => Tokens[Progress];

    internal TokenKind Kind => Token.Kind;

    internal SourcePos Pos => Token.Pos;
}