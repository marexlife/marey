namespace Marey;

internal sealed class TranslationUnit : ASTNode
{
    private ClassNode _classNode = new();

    internal override void Parse(List<Token> tokens, out int jumpCount)
    {
        _classNode.Parse(tokens, out jumpCount);
    }
}