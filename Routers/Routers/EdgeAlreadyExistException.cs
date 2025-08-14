// <copyright file="EdgeAlreadyExistException.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

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