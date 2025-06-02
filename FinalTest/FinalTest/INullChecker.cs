// <copyright file="INullChecker.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest;

/// <summary>
/// element's checker.
/// </summary>
/// <typeparam name="T">type of element.</typeparam>
public interface INullChecker<in T>
{
    /// <summary>
    /// check is item null.
    /// </summary>
    /// <param name="item">item to check.</param>
    /// <returns>true if item is true.</returns>
    bool IsNull(T item);
}