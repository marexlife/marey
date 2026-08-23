namespace Marey.Ast;

internal sealed class EmitPack
{
    internal string Stream { get; private set; } = string.Empty;

    internal void Add(string added)
    {
        Stream += added;
    }
}