using System.Diagnostics;
using Marey.Ast.Decls;
using Marey.Lex;

namespace Marey.Ast;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode
{
    private List<IAstNodeItem> _classItems = [];
    private string? _parentClassName;

    internal string Emit()
    {
        throw new NotImplementedException();
    }

    internal void Parse(ParsePacket packet)
    {
        packet.AdvanceIfEqual(TokenKind.Extends);
        _parentClassName = packet.AdvanceIfEqual(TokenKind.Ident);
        packet.AdvanceIfEqual(TokenKind.StatementEnd);

        while (!packet.IsFinished)
        {
            var currentKind = packet.Kind.FromEnumToString();

            IAstNodeItem classItem = packet.Kind switch
            {
                TokenKind.Fun => new FuncNode(),
                TokenKind.Var => new VarDecl(),
                _ => throw new UnreachableException(
                    $"Kind was: {currentKind}"
                ),
            };

            classItem.Parse(packet);
            _classItems.Add(classItem);
        }
    }
}