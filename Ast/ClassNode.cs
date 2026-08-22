using System.Diagnostics;
using Marey.Lex;

namespace Marey.Ast;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode : AstNode
{
    private List<ClassItem> _classItems = [];

    internal override void Parse(ParsePacket packet)
    {
        ClassItem classItem = packet.Kind switch
        {
            TokenKind.Fun => new MethodNode(),
            TokenKind.Var => new FieldNode(),
            _ => throw new UnreachableException(),
        };

        classItem.Parse(packet);
        _classItems.Add(classItem);
    }
}