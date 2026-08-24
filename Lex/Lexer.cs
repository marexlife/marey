namespace Marey.Lex;

internal sealed class Lexer(string sourceCode)
{
    private TokenStream tokens = [];
    private string _lastWord = string.Empty;
    private SourcePos sourcePos = new();

    private char _sourceCodeChar;
    private bool _isContentToFlushAvailable = false;

    internal TokenStream Run()
    {
        foreach (var sourceCodeChar in sourceCode)
        {
            _sourceCodeChar = sourceCodeChar;

            sourcePos.Advance(sourceCodeChar);

            Action targetAction = sourceCodeChar switch
            {
                ' ' => FlushWithoutAdd,
                ';' or ':' or '{' or '}' or '(' or ')' => FlushAndAdd,
                '\n' => FlushWithoutAdd,
                _ => HandleDefaultChar,
            };

            targetAction.Invoke();
        }

        return tokens;
    }

    private void HandleDefaultChar()
    {
        _lastWord += _sourceCodeChar;
        _isContentToFlushAvailable = true;
    }

    private void FlushAndAdd()
    {
        FlushWithoutAdd();

        string toAddString = string.Empty;
        toAddString += _sourceCodeChar;
        tokens.Add(new Token(sourcePos, toAddString));
    }

    private void FlushWithoutAdd()
    {
        if (!_isContentToFlushAvailable) return;

        tokens.Add(new Token(sourcePos, _lastWord));

        _lastWord = string.Empty;
        _isContentToFlushAvailable = false;
    }
}