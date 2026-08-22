namespace Marey;

/// <summary>
/// One is automatically per file
/// </summary>
internal sealed class ClassNode : ASTNode
{
    private string? _className;
    private List<ClassItemNode> _classItem = [];

    internal override void Parse(List<Token> tokens)
    {
        throw new NotImplementedException();
    }
}