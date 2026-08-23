using Marey.Lex;

namespace Marey.Ast.Decls;

internal abstract class VarDecl : IParseable
{
    private string? _declName;
    private string? _valueString;
    private VarNodeKind? _varNodeKind;

    public virtual void Parse(ParsePacket packet)
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