using Marey.Ast.InMethod;

namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private List<InMethodNode> _statementNodes = [];

    internal override void Parse(ParsePacket packet)
    {
        InMethodNode action = packet.Kind switch
        {
            TokenKind
            _ => throw new NotImplementedException(),
        };

        action.Invoke();

        throw new NotImplementedException();
    }
}