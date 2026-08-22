namespace Marey.Ast;

internal sealed class TranslationUnit : AstNode
{
    private ClassNode _classNode = new();

    internal override void Parse(ParsePacket parsePacket)
    {
        _classNode.Parse(parsePacket);
    }
}