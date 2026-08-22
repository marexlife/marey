namespace Marey.Lex;

public record struct SourcePos(int Line, int Column)
{
    public override string ToString()
    {
        return $"Line {Line}, Column {Column}";
    }
}