namespace Marey.Lex;

internal sealed class SourcePos
{
    internal int _line = 1;

    internal int _column = 1;

    internal void Advance(char sourceCodeChar)
    {
        if (sourceCodeChar == '\n')
        {
            ++_line;
            _column = 0;
        }
        else
        {
            ++_column;
        }
    }

    public override string ToString()
    {
        return $"{_line}:{_column}";
    }
}