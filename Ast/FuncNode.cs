using System.Diagnostics;
using Marey.Lex;
using Marey.Ast.Decls;

namespace Marey.Ast;

internal sealed class FuncNode : ClassItem
{
    private readonly List<Decl> _inMethodNodes = [];
    private string? functionName;

    internal override void Parse(ParsePacket packet)
    {
        ParseFuncSignature(packet);
        ParseFuncBody(packet);
    }

    private void ParseFuncSignature(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Fun);
        functionName = packet.AdvanceIfEqual().Lexeme;

        packet.AdvanceIfEqual(TokenKind.OpenBracket);
        packet.AdvanceIfEqual(TokenKind.CloseBracket);
        packet.AdvanceIfEqual(TokenKind.OpenBrace);
    }

    private void ParseFuncBody(ParsePacket packet)
    {
        bool breakOut = false;

        while (!breakOut)
        {
            switch (packet.Kind)
            {
                case TokenKind.Var: AddAndParseSubNode<LocalVarDeclNode>(packet); break;
                case TokenKind.CloseBrace: breakOut = true; break;
                case TokenKind.Fun:
                    throw new InvalidTokenException(
                    packet.Token.Pos,
                    "Functions declared in methods are not supported");
                default:
                    throw new UnreachableException();
            }
        }
    }

    private void AddAndParseSubNode<T>(ParsePacket packet) where T : Decl
    {
        var newInMethodNode = new LocalVarDeclNode();

        newInMethodNode.Parse(packet);

        _inMethodNodes.Add(newInMethodNode);
    }
}