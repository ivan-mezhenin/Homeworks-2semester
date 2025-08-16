// <copyright file="ParserTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SyntaxTree.Tests;

using SyntaxTree;

/// <summary>
/// test for parser.
/// </summary>
public class ParserTest
{
    /// <summary>
    /// test for parsing expression.
    /// </summary>
    [Test]
    public void Parser_Parse_ParseExpression()
    {
        var parser = new Parser();
        var parsedExpression = parser.Parse("(* (+ 1 2) 4)");

        Assert.That(parsedExpression.Print(), Is.EqualTo("(* (+ 1 2) 4)"));
    }

    /// <summary>
    /// test expression with operation before parenthesis throw format exception.
    /// </summary>
    [Test]
    public void Parser_ParseExpressionWithOperationBeforeParenthesis_ShouldThrowFormatException()
    {
        var parser = new Parser();
        Assert.Throws<FormatException>(() => parser.Parse("*( (+ 1 2) 4)"));
    }

    /// <summary>
    /// test expression with missing parenthesis should throw format exception.
    /// </summary>
    [Test]
    public void Parser_ParseExpressionWithMissingParenthesis_ShouldThrowFormatException()
    {
        var parser = new Parser();
        Assert.Throws<FormatException>(() => parser.Parse("(* (+ 1 2 4)"));
    }

    /// <summary>
    /// test expression with incorrect symbol should throw format exception.
    /// </summary>
    [Test]
    public void Parser_ParseExpressionWithIncorrectSymbol_ShouldThrowFormatException()
    {
        var parser = new Parser();
        Assert.Throws<FormatException>(() => parser.Parse("(* (! 1 2 4)"));
    }

    /// <summary>
    /// test parse empty expression.
    /// </summary>
    [Test]
    public void Parser_ParseEmptyExpression_ShouldThrowEmptyExpressionException()
    {
        var parser = new Parser();
        Assert.Throws<EmptyExpressionException>(() => parser.Parse(string.Empty));
    }

    /// <summary>
    /// test parse from non-existent file should throw exception.
    /// </summary>
    [Test]
    public void Parser_ParseFromFile_ParseNonExistentFile_ShouldThrowFileNotFoundException()
    {
        var parser = new Parser();
        Assert.Throws<FileNotFoundException>(() => parser.ParseFromFile("NonExistentFile.txt"));
    }

    /// <summary>
    /// test parse empty file should throw exception.
    /// </summary>
    [Test]
    public void Parser_ParseFromFile_ParseEmptyFile_ShouldThrowEmptyExpressionException()
    {
        var parser = new Parser();
        var filePath = Path.Combine(AppContext.BaseDirectory, "TestFiles", "EmptyFile.txt");
        Assert.Throws<EmptyExpressionException>(() => parser.ParseFromFile(filePath));
    }

    /// <summary>
    /// parse expression from file.
    /// </summary>
    [Test]
    public void Parser_ParseFromFile_Expression()
    {
        var parser = new Parser();
        var filePath = Path.Combine(AppContext.BaseDirectory, "TestFiles", "ParseExpressionFromFile.txt");
        const string expectedExpression = "(+ (* 4 5) 2)";

        Assert.That(parser.ParseFromFile(filePath).Print(), Is.EqualTo(expectedExpression));
    }
}