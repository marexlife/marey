namespace Marey.AST;

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

    internal Token CurrentToken => Tokens[Progress];

    internal TokenKind CurrentTokenKind => Tokens[Progress].TokenKind;
}