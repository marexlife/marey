using Marey.Ast.InMethod;
using Marey.Lex;

namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private List<InMethodNode> _inMethodNodes = [];

    internal override void Parse(ParsePacket packet)
    {
        bool breakOut = false;

        while (!breakOut)
        {
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

    private void AddAndParseSubNode<T>(ParsePacket packet) where T : InMethodNode
    {
        var newInMethodNode = new VarDeclNode();

        newInMethodNode.Parse(packet);

        _inMethodNodes.Add(newInMethodNode);
    }
}