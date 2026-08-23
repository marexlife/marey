namespace Marey.Ast;

internal interface IAstNode
{
    internal void Parse(ParsePack parsePacket);
    internal void Emit(EmitPack target);
}