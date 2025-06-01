// <copyright file="EmptySkipListException.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
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