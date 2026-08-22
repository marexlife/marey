namespace Marey;

internal sealed class TranslationUnit : ASTNode
{
    private ClassNode ClassNode = new();

    internal override void Flush()
    {
        throw new NotImplementedException();
    }

    internal override void Parse(List<Token> tokens)
    {
        ClassNode.Parse(tokens);
    }
}