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

    /// <summary>
    /// returns a list of elements that, when inserted into the function, return true.
    /// </summary>
    /// <param name="data">list.</param>
    /// <param name="function">function to apply.</param>
    /// <returns>filter list.</returns>
    public static List<int> Filter(List<int> data, Func<int, bool> function)
    {
        var result = new List<int>();

        foreach (var element in data)
        {
            if (function(element))
            {
                result.Add(element);
            }
        }

        return result;
    }

    /// <summary>
    /// to evaluate the value after going through the entire list.
    /// </summary>
    /// <param name="data">list.</param>
    /// <param name="startValue">start value.</param>
    /// <param name="function">function to apply.</param>
    /// <returns>result value.</returns>
    public static int Fold(List<int> data, int startValue, Func<int, int, int> function)
    {
        var result = startValue;

        foreach (var item in data)
        {
            result = function(result, item);
        }

        return result;
    }
}