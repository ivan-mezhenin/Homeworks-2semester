// <copyright file="Operation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree;

/// <summary>
/// operation of syntax tree.
/// </summary>
public abstract class Operation : Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Operation"/> class.
    /// </summary>
    /// <param name="left">left number.</param>
    /// <param name="right">right number.</param>
    protected Operation(Node left, Node right)
    {
        this.Left = left;
        this.Right = right;
    }

    /// <summary>
    /// Gets left child of operator.
    /// </summary>
    protected Node Left { get; }

    /// <summary>
    /// Gets right child of operator.
    /// </summary>
    protected Node Right { get; }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    protected abstract char OperationSymbol { get; }

    /// <summary>
    /// to print expression.
    /// </summary>
    /// <returns>string expression.</returns>
    public override string Print()
        => $"({this.OperationSymbol} {this.Left.Print()} {this.Right.Print()})";

    /// <summary>
    /// to calculate expression.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public abstract override int Evaluate();
}