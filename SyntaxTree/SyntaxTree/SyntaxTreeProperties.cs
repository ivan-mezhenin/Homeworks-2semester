// <copyright file="SyntaxTreeProperties.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// to calculate syntax tree.
/// </summary>
public class SyntaxTreeProperties
{
    /// <summary>
    /// to calculate syntax tree.
    /// </summary>
    /// <param name="syntaxTreeRoot">root of tree.</param>
    /// <returns>result of calculate.</returns>
    public static int Calculate(Node syntaxTreeRoot)
        => syntaxTreeRoot.Evaluate();

    /// <summary>
    /// tp print syntax tree.
    /// </summary>
    /// <param name="syntaxTreeRoot">root of tree.</param>
    /// <returns>expression.</returns>
    public static string Print(Node syntaxTreeRoot)
    => syntaxTreeRoot.Print();
}