// <copyright file="PassingNullGraphException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// passing null graph exception.
/// </summary>
public class PassingNullGraphException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PassingNullGraphException"/> class.
    /// </summary>
    /// <param name="message">message to return.</param>
    public PassingNullGraphException(string message)
    : base(message)
    {
    }
}