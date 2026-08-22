using Marey.Lex;

namespace Marey.Ast;

internal sealed class FieldNode : ClassItem
{
    private FieldNodeKind? _fieldNodeKind = null;

    internal override void Parse(ParsePacket packet)
    {
        if (packet.Kind == TokenKind.Var) packet.Advance();
        else throw new InvalidTokenException(packet.Pos, "");
    }
}