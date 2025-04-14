// <copyright file="Multiplication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// multiplication operation.
/// </summary>
public class Multiplication : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Multiplication"/> class.
    /// </summary>
    /// <param name="left">left child.</param>
    /// <param name="right">right child.</param>
    public Multiplication(Node left, Node right)
    : base(left, right)
    {
    }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    protected override char OperationSymbol => '*';

    /// <summary>
    /// to evaluate expression.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public override int Evaluate()
    => this.left.Evaluate() * this.right.Evaluate();
}