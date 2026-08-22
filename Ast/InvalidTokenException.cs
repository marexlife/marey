using Marey.Lex;

namespace Marey.Ast;

internal sealed class InvalidTokenException(TokenPos tokenPos, string message) :
    Exception($"On {tokenPos}\n{message}");