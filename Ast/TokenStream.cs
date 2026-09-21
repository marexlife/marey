namespace Marey.Ast;

using Marey.Lex;

internal sealed class TokenStream(List<Token> tokens)
{
    internal List<Token> Tokens { get; } = tokens;

    internal int Progress { get; set; }

    internal bool IsFinished => Progress >= Tokens.Count;
    internal void Advance() => ++Progress;


    internal void AdvanceIfEqual(TokenKind[] comparers)
    {
        foreach (var comparer in comparers)
        {
            AdvanceIfEqualOrThrow(comparer);
        }
    }

    internal bool IsEqual(TokenKind comparer) => Kind == comparer;

    internal string AdvanceIfEqualOrThrow(TokenKind comparer = TokenKind.Ident)
    {
        if (Kind == comparer)
        {
            var preAdvanceToken = Token;

            Advance();

            return preAdvanceToken.Lexeme;
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