using Marey.Ast.InMethod;

namespace Marey.Ast;

internal sealed class MethodNode : ClassItem
{
    private List<InMethodNode> _statementNodes = [];

    internal override void Parse(ParsePacket packet)
    {
        InMethodNode inMethodNode = packet.Kind switch
        {
            TokenKind.Var => new VarDeclNode(),
            _ => throw new NotImplementedException(),
        };

        throw new NotImplementedException();
    }
}