using Marey.Lex;

namespace Marey.Ast;

internal sealed class FieldNode : ClassItem
{
    private FieldNodeKind? _fieldNodeKind = null;

    internal override void Parse(ParsePacket packet)
    {
        packet.AdvanceIfEqual("var");
        packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(":");
        packet.AdvanceIfEqual("=");
        packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(";");
    }
}