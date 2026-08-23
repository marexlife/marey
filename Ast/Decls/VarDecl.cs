using Marey.Lex;

namespace Marey.Ast.Decls;

internal sealed class VarDecl : IAstNodeItem
{
    private string? _declName;
    private string? _valueString;
    private VarNodeKind? _varNodeKind;

    string IAstNode.Emit()
    {
        throw new NotImplementedException();
    }

    void IAstNode.Parse(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Var);
        _declName = packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.Colon);

        _varNodeKind = packet.Kind switch
        {
            TokenKind.Bool => VarNodeKind.Bool,
            TokenKind.Int => VarNodeKind.Int,
            TokenKind.Float => VarNodeKind.Float,
            _ => throw new InvalidTokenException(packet.Pos, "Invalid Type"),
        };

        packet.Advance();

        packet.AdvanceIfEqual(TokenKind.Assignment);

        _valueString = packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.StatementEnd);
    }
}