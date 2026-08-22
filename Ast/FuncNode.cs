namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private List<StatementNode> _statementNodes = [];

    internal override void Parse(ParsePacket packet)
    {
        Action action = packet.Kind switch
        {

        };

        throw new NotImplementedException();
    }
}