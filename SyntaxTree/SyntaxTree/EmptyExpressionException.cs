// <copyright file="EmptyExpressionException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// empty file exception.
/// </summary>
public class EmptyExpressionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmptyExpressionException"/> class.
    /// </summary>
    /// <param name="message">message to return.</param>
    public EmptyExpressionException(string message)
        : base(message)
    {
    }
}