namespace Marey.Ast;

internal abstract class AstNode
{
    internal abstract void Parse(ParsePacket parsePacket);
}