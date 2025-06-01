// <copyright file="MyList.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

namespace TestProject;

/// <summary>
/// class list.
/// </summary>
public class MyList
{
    /// <summary>
    /// add new element.
    /// </summary>
    /// <param name="element">element to add.</param>
    public void Add(int element)
    {
        Console.WriteLine("Adding element {0}", element);
    }
}