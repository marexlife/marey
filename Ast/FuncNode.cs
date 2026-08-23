using Marey.Ast.InMethod;
using Marey.Lex;

namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private readonly List<InMethodNode> _inMethodNodes = [];
    private string? functionName;

    internal override void Parse(ParsePacket packet)
    {
        ParseFuncSignature(packet);
        ParseFuncBody(packet);
    }

    private void ParseFuncSignature(ParsePacket packet)
    {
        functionName = packet.AdvanceIfEqual().Lexeme;

        packet.AdvanceIfEqual([
            TokenKind.OpenBracket,
            TokenKind.CloseBracket,
            TokenKind.OpenBrace
        ]);
    }

    private void ParseFuncBody(ParsePacket packet)
    {
        bool breakOut = false;

        while (!breakOut)
        {
            switch (packet.Kind)
            {
                case TokenKind.Var: AddAndParseSubNode<VarDeclNode>(packet); break;
                case TokenKind.CloseBrace: breakOut = true; break;
                case TokenKind.Fun:
                    throw new InvalidTokenException(
                    packet.Token.Pos,
                    "Functions declared in methods are not supported");
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private void AddAndParseSubNode<T>(ParsePacket packet) where T : InMethodNode
    {
        var newInMethodNode = new VarDeclNode();

        newInMethodNode.Parse(packet);

        _inMethodNodes.Add(newInMethodNode);
    }
}