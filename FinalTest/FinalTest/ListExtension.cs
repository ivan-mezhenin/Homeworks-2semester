// <copyright file="ListExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest;

/// <summary>
/// extension for MyList.
/// </summary>
public static class ListExtension
{
    /// <summary>
    /// count null elements in list.
    /// </summary>
    /// <param name="list">list to count.</param>
    /// <param name="checker">null checker.</param>
    /// <typeparam name="T">type of list's element.</typeparam>
    /// <returns>amount of null elements.</returns>
    public static int CountNullElements<T>(this MyList<T> list, INullChecker<T> checker)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(checker);

        return list.Count(checker.IsNull);
    }
}