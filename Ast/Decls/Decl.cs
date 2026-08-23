namespace Marey.Ast.Decls;

internal abstract class Decl : IParseable
{
    protected string? DeclName { get; set; }

    public abstract void Parse(ParsePacket packet);
}