// <copyright file="EmptyEnqueueException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Test1;

/// <summary>
/// empty enqueue.
/// </summary>
public class EmptyEnqueueException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmptyEnqueueException"/> class.
    /// </summary>
    /// <param name="message">message to print.</param>
    public EmptyEnqueueException(string message)
        : base(message)
    {
    }
}