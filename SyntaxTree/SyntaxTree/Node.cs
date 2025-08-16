// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// abstract Node of tree.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// to evaluate node.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public abstract int Evaluate();

    /// <summary>
    /// to print node.
    /// </summary>
    /// <returns>node's value to print.</returns>
    public abstract string Print();
}