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

    internal void Emit(EmitPack pack)
    {
        pack.Add(_parentClassName ?? throw new EmitBeforeParseException());

        foreach (var classItem in _classItems)
        {
            classItem.Emit(pack);
        }
    }

    internal void Parse(TokenStream pack)
    {
        pack.AdvanceIfEqualOrThrow(TokenKind.Extends);
        _parentClassName = pack.AdvanceIfEqualOrThrow(TokenKind.Ident);
        pack.AdvanceIfEqualOrThrow(TokenKind.StatementEnd);

        while (!pack.IsFinished)
        {
            var currentKind = pack.Kind.FromEnumToString();

            IAstNodeItem classItem = pack.Kind switch
            {
                TokenKind.Fun => new FuncNode(),
                TokenKind.Var => new VarDecl(),
                _ => throw new UnreachableException(
                    $"Kind was: {currentKind}"
                ),
            };

            classItem.Parse(pack);
            _classItems.Add(classItem);
        }
    }
}