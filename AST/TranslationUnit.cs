namespace Marey;

internal sealed class TranslationUnit : ASTNode
{
    private ClassNode _classNode = new();

    internal override void Parse(List<Token> tokens, ref int progress)
    {
        _classNode.Parse(tokens, ref progress);
    }
}