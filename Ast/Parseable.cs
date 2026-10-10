namespace Marey.Ast;

internal abstract class AstNode
{
    internal abstract void Parse(TokenStream parsePacket);
    internal abstract void Emit(EmitPack target);
}