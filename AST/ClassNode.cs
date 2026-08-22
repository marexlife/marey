namespace Marey;

/// <summary>
/// One is automatically per file
/// </summary>
internal sealed class ClassNode : ASTNode
{
    internal string _className { get; set; }
    internal List<ClassItemNode> ClassItem { get; set; } = [];

    internal override void Parse()
    {
        throw new NotImplementedException();
    }
}