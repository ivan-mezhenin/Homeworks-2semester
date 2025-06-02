// <copyright file="Divide.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// multiplication operation.
/// </summary>
public class Divide : Operation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Divide"/> class.
    /// </summary>
    /// <param name="left">left child.</param>
    /// <param name="right">right child.</param>
    public Divide(Node left, Node right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    protected override char OperationSymbol => '/';

    /// <summary>
    /// to evaluate expression.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public override int Evaluate()
    {
        var leftResult = this.Left.Evaluate();
        var rightResult = this.Right.Evaluate();

        if (leftResult == 0)
        {
            throw new DivideByZeroException("Division by zero");
        }

        return leftResult / rightResult;
    }
}