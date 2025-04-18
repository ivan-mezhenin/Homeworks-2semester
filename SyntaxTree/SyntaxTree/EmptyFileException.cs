// <copyright file="EmptyFileException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// empty file exception.
/// </summary>
public class EmptyFileException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmptyFileException"/> class.
    /// </summary>
    /// <param name="message">message to return.</param>
    public EmptyFileException(string message)
        : base(message)
    {
    }
}