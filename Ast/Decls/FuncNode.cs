using System.Diagnostics;
using Marey.Lex;
using Marey.Ast.Decls;

namespace Marey.Ast;

internal sealed class FuncNode : IAstNodeItem
{
    private readonly List<IAstNodeItem> _inMethodNodes = [];
    private string? _functionName;
    private TypeKind? _returnType;

    private void ParseFuncSignature(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Fun);
        _functionName = packet.AdvanceIfEqual();

        packet.AdvanceIfEqual(TokenKind.OpenBracket);
        packet.AdvanceIfEqual(TokenKind.CloseBracket);

        switch (packet.Kind)
        {
            case TokenKind.Colon:
                packet.Advance();
                _returnType = packet.Kind.ConvertToType(packet);
                packet.Advance();
                packet.AdvanceIfEqual(TokenKind.OpenBrace);
                break;
            case TokenKind.OpenBrace:
                packet.Advance();
                break;
            default:
                throw new InvalidTokenException(packet.Pos,
                    "expected { or : after function's");
        }
    }

    private void ParseFuncBody(ParsePacket packet)
    {
        bool breakOut = false;

        while (!breakOut)
        {
            switch (packet.Kind)
            {
                case TokenKind.Var:
                    AddAndParseSubNode<VarDecl>(packet);
                    break;
                case TokenKind.CloseBrace:
                    breakOut = true;
                    packet.Advance();
                    break;
                case TokenKind.Fun:
                    throw new InvalidTokenException(
                    packet.Token.Pos,
                    "Functions declared in methods are not supported");
                default:
                    throw new UnreachableException();
            }
        }
    }

    private void AddAndParseSubNode<T>(ParsePacket packet) where T : IAstNodeItem, new()
    {
        var newInMethodNode = new T();

        newInMethodNode.Parse(packet);

        _inMethodNodes.Add(newInMethodNode);
    }

    void IAstNode.Parse(ParsePacket packet)
    {
        ParseFuncSignature(packet);
        ParseFuncBody(packet);
    }

    void IAstNode.Emit(EmitPack pack)
    {
        throw new NotImplementedException();
    }
}