using Marey.Lex;

namespace Marey.Ast;

internal sealed class FieldNode : ClassItem
{
    private FieldNodeKind? _fieldNodeKind = null;

    internal override void Parse(ParsePacket packet)
    {
        ParseBool(packet);
    }

    // is for the start, not final
    private void ParseBool(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Var);
        packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.Colon);
        packet.AdvanceIfEqual(TokenKind.Bool);
        packet.AdvanceIfEqual(TokenKind.Assignment);
        packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.StatementEnd);
    }
}