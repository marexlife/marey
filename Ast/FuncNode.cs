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
        if (packet.Token.TokenKind == TokenKind.OpenBracket)
        {
            ++packet.Progress;

            functionName = packet.Token.Lexeme;
        }
        else
        {
            throw new InvalidTokenException(packet.Token.TokenPos, $"expected '('");
        }

        if (packet.Token.TokenKind == TokenKind.OpenBracket) ++packet.Progress;
        else throw new InvalidTokenException(packet.Token.TokenPos, $"expected '('");


        if (packet.Token.TokenKind == TokenKind.CloseBracket) ++packet.Progress;
        else throw new InvalidTokenException(
                packet.Token.TokenPos, "')'"
        );

        if (packet.Token.TokenKind == TokenKind.OpenBrace) ++packet.Progress;
        else throw new InvalidTokenException(
                packet.Token.TokenPos, "expected '{'"
        );
    }

    private void ParseFuncBody(ParsePacket packet)
    {
        bool breakOut = false;

        while (!breakOut)
        {
            ParseFuncSignature(packet);

            switch (packet.Kind)
            {
                case TokenKind.Var: AddAndParseSubNode<VarDeclNode>(packet); break;
                case TokenKind.EndBrace: breakOut = true; break;
                case TokenKind.Fun:
                    throw new InvalidTokenException(
                    packet.Token.TokenPos,
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