using Marey.Ast.InMethod;

namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private List<InMethodNode> _inMethodNodes = [];

    internal override void Parse(ParsePacket packet)
    {
        InMethodNode newInMethodNode = packet.Kind switch
        {
            TokenKind.Var => new VarDeclNode(),
            TokenKind.Fun => throw new InvalidNodeException(
                "Functions declared in methods are not supported"
            ),
            _ => throw new NotImplementedException(),
        };

        

        throw new NotImplementedException();
    }
}