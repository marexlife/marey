using Marey.Lex;

namespace Marey.Ast.Decls;

internal sealed class FieldNode : Decl, IClassItem
{
    public override void Parse(ParsePacket packet)
    {
        ParseBool(packet);
    }

    // is for the start, not final
    private void ParseBool(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Var);
        DeclName = packet.AdvanceIfEqual().Lexeme;
        packet.AdvanceIfEqual([TokenKind.Colon, TokenKind.Bool, TokenKind.Assignment]);
        packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.StatementEnd);
    }
}