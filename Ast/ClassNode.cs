using System.Diagnostics;
using Marey.Lex;

namespace Marey.Ast;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode : AstNode
{
    private List<ClassItem> _classItems = [];

    internal override void Parse(ParsePacket parsePacket)
    {
        for (int i = 0; i < parsePacket.Progress; ++i)
        {
            ClassItem classItem = parsePacket.Kind switch
            {
                TokKind.Fun => new MethodNode(),
                TokKind.Var => new FieldNode(),
                _ => throw new UnreachableException(),
            };

            classItem.Parse(parsePacket);
            _classItems.Add(classItem);
        }

        throw new NotImplementedException();
    }
}