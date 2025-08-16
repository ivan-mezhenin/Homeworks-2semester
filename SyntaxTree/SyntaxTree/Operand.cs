// <copyright file="Operand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// operand of syntax tree.
/// </summary>
public class Operand : Node
{
    private int value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Operand"/> class.
    /// </summary>
    /// <param name="value">value of node.</param>
    public Operand(int value)
    {
        this.value = value;
    }

    /// <summary>
    /// to evaluate expression.
    /// </summary>
    /// <returns>expression result.</returns>
    public override int Evaluate()
        => this.value;

    /// <summary>
    /// to print expression.
    /// </summary>
    /// <returns>expression.</returns>
    public override string Print()
    => this.value.ToString();
}