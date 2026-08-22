using Marey.Ast.InMethod;
using Marey.Lex;

namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private List<InMethodNode> _inMethodNodes = [];
    private string? functionName;

    internal override void Parse(ParsePacket packet)
    {
        bool breakOut = false;

        while (!breakOut)
        {
            functionName = packet.Token.Lexeme;

            if (packet.Token.TokenKind != TokenKind.OpenBracket)
            {
                throw new InvalidNodeException("expected '(' here");
            }

            if (packet.Token.TokenKind != TokenKind.CloseBracket)
            {
                throw new InvalidNodeException(
                    "arguments are not supported yet, put an ')' there"
                );
            }

            Action action = packet.Kind switch
            {
                TokenKind.Var => () => AddAndParseSubNode<VarDeclNode>(packet),
                TokenKind.EndBrace => () => breakOut = true,
                TokenKind.Fun => throw new InvalidNodeException(
                    "Functions declared in methods are not supported"
                ),
                _ => throw new NotImplementedException(),
            };

            action.Invoke();
        }
    }

    private void ProcessSignature()
    {

    }

    private void AddAndParseSubNode<T>(ParsePacket packet) where T : InMethodNode
    {
        var newInMethodNode = new VarDeclNode();

        newInMethodNode.Parse(packet);

        _inMethodNodes.Add(newInMethodNode);
    }
}