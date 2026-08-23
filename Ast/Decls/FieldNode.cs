using Marey.Lex;

namespace Marey.Ast.Decls;

internal sealed class FieldNode : VarDecl, IClassItem
{
    public override void Parse(ParsePacket packet)
    {
        base.Parse(packet);
    }
}