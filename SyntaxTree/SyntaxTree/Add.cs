// <copyright file="Add.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// add operation.
/// </summary>
public class Add : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Add"/> class.
    /// </summary>
    /// <param name="left">left child.</param>
    /// <param name="right">right child.</param>
    public Add(Node left, Node right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    protected override char OperationSymbol => '+';

    /// <summary>
    /// to evaluate expression.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public override int Evaluate()
        => this.left.Evaluate() + this.right.Evaluate();
}