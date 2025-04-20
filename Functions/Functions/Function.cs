// <copyright file="Function.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Functions;

/// <summary>
/// functions Map, Filter, Fold.
/// </summary>
public static class Function
{
    /// <summary>
    /// to apply function to each element of list.
    /// </summary>
    /// <param name="data">list.</param>
    /// <param name="function">function to apply.</param>
    /// <returns>list with applied function.</returns>
    public static List<int> Map(List<int> data, Func<int, int> function)
    {
        List<int> result = [];
        foreach (var item in data)
        {
            result.Add(function(item));
        }

        return result;
    }
}