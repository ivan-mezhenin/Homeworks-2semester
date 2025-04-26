// <copyright file="EmptySkipListException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

/// <summary>
/// empty skip list exception.
/// </summary>
public class EmptySkipListException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmptySkipListException"/> class.
    /// </summary>
    /// <param name="message">message to return.</param>
    public EmptySkipListException(string message)
    : base(message)
    {
    }
}