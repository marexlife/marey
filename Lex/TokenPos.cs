namespace Marey.Lex;

internal record struct SourcePos(int Line, int Column)
{
    public override string ToString()
    {
        return $"Line {Line}, Column {Column}";
    }
}