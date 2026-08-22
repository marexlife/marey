namespace Marey.AST;

internal sealed class TranslationUnit : ASTNode
{
    private ClassNode _classNode = new();

    internal override void Parse(ParsePacket parsePacket)
    {
        _classNode.Parse(parsePacket);
    }
}