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
}