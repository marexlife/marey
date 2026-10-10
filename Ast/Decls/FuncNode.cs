using System.Diagnostics;
using Marey.Lex;
using Marey.Ast.Decls;

namespace Marey.Ast;

internal sealed class FuncNode : IAstNodeItem
{
    private readonly List<IAstNodeItem> _inMethodNodes = [];
    private string? _functionName;
    private TypeKind? _returnType;

    private void ParseFuncSignature(TokenStream packet)
    {
        packet.AdvanceIfEqualOrThrow(TokenKind.Fun);
        _functionName = packet.AdvanceIfEqualOrThrow();

        packet.AdvanceIfEqualOrThrow(TokenKind.OpenBracket);
        packet.AdvanceIfEqualOrThrow(TokenKind.CloseBracket);

        switch (packet.Kind)
        {
            case TokenKind.Colon:
                packet.Advance();
                _returnType = packet.Kind.ConvertToType(packet);
                packet.Advance();
                packet.AdvanceIfEqualOrThrow(TokenKind.OpenBrace);
                break;
            case TokenKind.OpenBrace:
                packet.Advance();
                break;
            default:
                throw new InvalidTokenException(packet.Pos,
                    "expected { or : after function's");
        }
    }

    private void ParseFuncBody(TokenStream packet)
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

    private void AddAndParseSubNode<T>(TokenStream packet) where T : IAstNodeItem, new()
    {
        var newInMethodNode = new T();

        newInMethodNode.Parse(packet);

        _inMethodNodes.Add(newInMethodNode);
    }

    void AstNode.Parse(TokenStream packet)
    {
        ParseFuncSignature(packet);
        ParseFuncBody(packet);
    }

    void AstNode.Emit(EmitPack pack)
    {
        throw new NotImplementedException();
    }
}