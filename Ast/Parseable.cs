namespace Marey.Ast;

internal interface IParsable
{
    internal void Parse(TokenStream parsePacket);
    internal void Emit(EmitPack target);
}