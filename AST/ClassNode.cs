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
            ClassItem item = parsePacket.CurrentTokenKind switch
            {
                TokenKind.Fun => new MethodNode(),
                TokenKind.Var => new FieldNode(),
                _ => throw new UnreachableException(),
            };

            item.Parse(parsePacket);
            _classItems.Add(item);
        }

        throw new NotImplementedException();
    }
}