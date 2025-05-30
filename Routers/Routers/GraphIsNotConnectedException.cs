// <copyright file="GraphIsNotConnectedException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Graph is not connected.
/// </summary>
public class GraphIsNotConnectedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GraphIsNotConnectedException"/> class.
    /// </summary>
    /// <param name="message">message to return.</param>
    public GraphIsNotConnectedException(string message)
    : base(message)
    {
    }
}