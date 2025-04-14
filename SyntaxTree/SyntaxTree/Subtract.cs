// <copyright file="Subtract.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// subtract operation.
/// </summary>
public class Subtract : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Subtract"/> class.
    /// </summary>
    /// <param name="left">left child.</param>
    /// <param name="right">right child.</param>
    public Subtract(Node left, Node right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    protected override char OperationSymbol => '-';

    /// <summary>
    /// to evaluate expression.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public override int Evaluate()
        => this.left.Evaluate() - this.right.Evaluate();
}