namespace Marey;

internal sealed class TranslationUnit : ASTNode
{
    private ClassNode? _classNode;
    private string? fileName;

    internal override void Parse(List<Token> tokens)
    {
        throw new NotImplementedException();
    }
}