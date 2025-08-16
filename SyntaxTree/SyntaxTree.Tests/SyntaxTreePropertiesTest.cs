// <copyright file="SyntaxTreePropertiesTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree.Tests;

using SyntaxTree;

/// <summary>
/// to test syntax tree.
/// </summary>
public class SyntaxTreePropertiesTest
{
    /// <summary>
    /// test evaluate expression.
    /// </summary>
    [Test]
    public void SyntaxTreeProperties_Evaluate_Expression()
    {
        var parser = new Parser();
        var expression = parser.Parse("(* (+ 2 4) (+ (* 2 3) (+ 4 5)))");
        const int expectedResult = 90;

        Assert.That(expression.Evaluate(), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test evaluate single number expression.
    /// </summary>
    [Test]
    public void SyntaxTreeProperties_Evaluate_SingleNumberExpression()
    {
        var parser = new Parser();
        var expression = parser.Parse("197");
        const int expectedResult = 197;
        Assert.That(expression.Evaluate(), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test print expression.
    /// </summary>
    [Test]
    public void SyntaxTreeProperties_Print_Expression()
    {
        var parser = new Parser();
        var expression = parser.Parse("(* (+ 2 4) (+ (* 2 3) (+ 4 5)))");
        const string expectedResult = "(* (+ 2 4) (+ (* 2 3) (+ 4 5)))";

        Assert.That(expression.Print(), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test print single number expression.
    /// </summary>
    [Test]
    public void SyntaxTreeProperties_Print_SingleNumberExpression()
    {
        var parser = new Parser();
        var expression = parser.Parse("197");
        const string expectedResult = "197";
        Assert.That(expression.Print(), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test evaluate expression should throw exception.
    /// </summary>
    [Test]
    public void SyntaxTreeProperties_Evaluate_ShouldThrowsDivideByZeroException()
    {
        var parser = new Parser();
        var expression = parser.Parse("(/ 10 0)");

        Assert.Throws<DivideByZeroException>(() => expression.Evaluate());
    }
}