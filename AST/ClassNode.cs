using System.Diagnostics;

namespace Marey;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode : ASTNode
{
    private List<ClassItem> _classItems = [];

    internal override void Parse(List<Token> tokens, ref int progress)
    {
        foreach (Token token in tokens)
        {
            _classItems.Add(token.TokenKind switch
            {
                TokenKind.Fun => new MethodNode(),
                TokenKind.Var => new FieldNode(),
                _ => throw new UnreachableException(),
            });
        }

        throw new NotImplementedException();
    }
}