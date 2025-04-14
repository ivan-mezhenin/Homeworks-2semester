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
    /// left child of operator.
    /// </summary>
    protected Node left;

    /// <summary>
    /// right child of operator.
    /// </summary>
    protected Node right;

    /// <summary>
    /// Initializes a new instance of the <see cref="Operation"/> class.
    /// </summary>
    /// <param name="left">left number.</param>
    /// <param name="right">right number.</param>
    protected Operation(Node left, Node right)
    {
        this.left = left;
        this.right = right;
    }

    /// <summary>
    /// Gets symbol of operation.
    /// </summary>
    protected abstract char OperationSymbol { get; }

    /// <summary>
    /// to print expression.
    /// </summary>
    /// <returns>string expression.</returns>
    public override string Print()
        => $"({this.OperationSymbol} {this.left.Print()}, {this.right.Print()})";

    /// <summary>
    /// to calculate expression.
    /// </summary>
    /// <returns>result of evaluate.</returns>
    public abstract override int Evaluate();
}