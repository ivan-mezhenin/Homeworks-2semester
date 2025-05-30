

namespace Routers;

/// <summary>
/// Graph is not connected.
/// </summary>
public class EdgeAlreadyExistException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EdgeAlreadyExistException"/> class.
    /// </summary>
    /// <param name="message">message to return.</param>
    public EdgeAlreadyExistException(string message)
        : base(message)
    {
    }
}