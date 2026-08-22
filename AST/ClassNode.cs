using System.Diagnostics;

namespace Marey.AST;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode : ASTNode
{
    private List<ClassItem> _classItems = [];

    internal override void Parse(ParsePacket parsePacket)
    {
        for (int i = 0; i < parsePacket.Progress; ++i)
        {
            ClassItem classItem = parsePacket.CurrentTokenKind switch
            {
                TokenKind.Fun => new MethodNode(),
                TokenKind.Var => new FieldNode(),
                _ => throw new UnreachableException(),
            };

            classItem.Parse(parsePacket);
            _classItems.Add(classItem);
        }

        throw new NotImplementedException();
    }
}