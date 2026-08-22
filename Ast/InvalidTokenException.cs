using Marey.Lex;

namespace Marey.Ast;

internal sealed class InvalidTokenException(SourcePos tokenPos, string message) :
    Exception($"On {tokenPos}\n{message}");