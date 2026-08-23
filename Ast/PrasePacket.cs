namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket(TokenStream tokenStream)
{
    internal TokenStream Tokens { get; } = tokenStream;

    internal int Progress { get; set; }

    internal void Advance() => ++Progress;

    internal void ForAdvanceIfEqual(string[] comparers)
    {
        foreach (var comparer in comparers)
        {
            AdvanceIfEqual(comparer);
        }
    }

    internal Token AdvanceIfEqual(string comparer)
    {
        TokenContent tokenContent = new(comparer);

        if (Kind == tokenContent.Kind)
        {
            var preAdvanceToken = Token;

            Advance();

            return preAdvanceToken;
        }
        else
        {
            throw new InvalidTokenException(
                Pos, $"expected {tokenContent.Lexeme}, got {Token.Lexeme}");
        }
    }

    internal Token AdvanceIfEqual()
    {
        if (Kind == TokenKind.Ident)
        {
            var preAdvanceToken = Token;

            Advance();

            return preAdvanceToken;
        }
        else
        {
            throw new InvalidTokenException(
                Pos, $"expected identifier, got {Token.Lexeme}");
        }
    }

    internal Token Token => Tokens[Progress];

    internal TokenKind Kind => Token.Kind;

    internal SourcePos Pos => Token.Pos;
}