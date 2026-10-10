using Marey.Lex;

namespace Marey.Ast.Decls;

internal sealed class VarDecl : IAstNodeItem
{
    private string? _declName;
    private string? _valueString;
    private TypeKind? _varNodeKind;

    void AstNode.Emit(EmitPack pack)
    {
        throw new NotImplementedException();
    }

    void AstNode.Parse(TokenStream packet)
    {
        packet.AdvanceIfEqualOrThrow(TokenKind.Var);
        _declName = packet.AdvanceIfEqualOrThrow();
        packet.AdvanceIfEqualOrThrow(TokenKind.Colon);

        _varNodeKind = packet.Kind switch
        {
            TokenKind.Bool => TypeKind.Bool,
            TokenKind.Int => TypeKind.Int,
            TokenKind.Float => TypeKind.Float,
            _ => throw new InvalidTokenException(packet.Pos, "Invalid Type"),
        };

        packet.Advance();

        packet.AdvanceIfEqualOrThrow(TokenKind.Assignment);

        _valueString = packet.AdvanceIfEqualOrThrow();
        packet.AdvanceIfEqualOrThrow(TokenKind.StatementEnd);
    }
}