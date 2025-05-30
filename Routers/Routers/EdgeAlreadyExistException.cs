// <copyright file="EdgeAlreadyExistException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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