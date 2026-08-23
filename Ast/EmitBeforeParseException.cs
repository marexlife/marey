namespace Marey.Ast;

internal sealed class EmitBeforeParseException(string message = "") :
    Exception(message);