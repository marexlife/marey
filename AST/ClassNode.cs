using System.Diagnostics;

namespace Marey;

/// <summary>
///     One is automatically per file
/// </summary>
internal sealed class ClassNode : ASTNode
{
    private List<ClassItem> _classItems = [];

    internal override void Flush()
    {
        throw new NotImplementedException();
    }

    internal override void Parse(List<Token> tokens)
    {
        SelectClassItems(tokens);

        IteratorOver(tokens);
    }

    void SelectClassItems(List<Token> tokens)
    {
        foreach (Token token in tokens)
        {
            switch (token.TokenKind)
            {
                case TokenKind.Fun:
                    break;
                case TokenKind.EndFun:
                    break;
                default: throw new UnreachableException();
            }
        }
    }

    void IteratorOver(List<Token> tokens)
    {
        foreach (ClassItem classItem in _classItems)
        {
            classItem.Parse(tokens);
        }
    }
}