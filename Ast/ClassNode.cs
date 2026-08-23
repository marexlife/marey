using System.Diagnostics;
using Marey.Ast.Decls;
using Marey.Lex;

namespace Marey.Ast;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode : IParseable
{
    private List<IClassItem> _classItems = [];

    public void Parse(ParsePacket packet)
    {
        IClassItem classItem = packet.Kind switch
        {
            TokenKind.Fun => new FuncNode(),
            TokenKind.Var => new FieldNode(),
            _ => throw new UnreachableException(),
        };

        classItem.Parse(packet);
        _classItems.Add(classItem);
    }
}