namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket
{
    internal required List<Token> Tokens { get; init; }
    internal int TokenJumpCount
    {
        set
        {
            Progress += value;
        }
    }
    internal int Progress { get; private set; }

    internal Token Token => Tokens[Progress];

    internal TokenKind Kind => Token.TokenKind;
}