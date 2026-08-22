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
        functionName = packet.Token.Lexeme;

        if (packet.Token.TokenKind == TokenKind.OpenBracket)
        {
            ++packet.Progress;
        }
        else
        {
            throw new InvalidNodeException($"expected '(' here {packet.Token.TokenPos}");
        }

        if (packet.Token.TokenKind == TokenKind.CloseBracket)
        {
            ++packet.Progress;
        }
        else
        {
            throw new InvalidNodeException(
                "arguments are not supported yet, put an ')' there"
            );
        }
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
                    throw new InvalidNodeException(
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