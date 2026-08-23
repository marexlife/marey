namespace Marey.Ast;

internal interface IAstNode
{
    internal void Parse(ParsePacket parsePacket);
    internal void Emit(out string target);
}