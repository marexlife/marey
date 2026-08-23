namespace Marey.Ast;

internal interface IAstNode
{
    internal void Parse(ParsePacket parsePacket);
    internal string Emit();
}