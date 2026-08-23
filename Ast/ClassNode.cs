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
    private string? _parentClassName;

    public void Parse(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Extends);
        _parentClassName = packet.AdvanceIfEqual(TokenKind.Ident);
        packet.AdvanceIfEqual(TokenKind.StatementEnd);

        while (!packet.IsFinished)
        {
            var currentKind = packet.Kind.FromEnumToString();

            IClassItem classItem = packet.Kind switch
            {
                TokenKind.Fun => new FuncNode(),
                TokenKind.Var => new FieldNode(),
                _ => throw new UnreachableException(
                    $"Kind was: {currentKind}"
                ),
            };

            classItem.Parse(packet);
            _classItems.Add(classItem);
        }
    }
}