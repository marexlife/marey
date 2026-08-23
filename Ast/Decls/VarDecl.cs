using Marey.Lex;

namespace Marey.Ast.Decls;

internal sealed class VarDecl : IAstNodeItem
{
    private string? _declName;
    private string? _valueString;
    private TypeKind? _varNodeKind;

    void IAstNode.Emit(EmitPack pack)
    {
        throw new NotImplementedException();
    }

    void IAstNode.Parse(ParsePack packet)
    {
        packet.AdvanceIfEqual(TokenKind.Var);
        _declName = packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.Colon);

        _varNodeKind = packet.Kind switch
        {
            TokenKind.Bool => TypeKind.Bool,
            TokenKind.Int => TypeKind.Int,
            TokenKind.Float => TypeKind.Float,
            _ => throw new InvalidTokenException(packet.Pos, "Invalid Type"),
        };

        packet.Advance();

        packet.AdvanceIfEqual(TokenKind.Assignment);

        _valueString = packet.AdvanceIfEqual();
        packet.AdvanceIfEqual(TokenKind.StatementEnd);
    }
}