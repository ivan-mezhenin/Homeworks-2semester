// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SyntaxTree;

using System.Text;

/// <summary>
/// syntax tree.
/// </summary>
public class Parser
{
    /// <summary>
    /// to build syntax tree from expression.
    /// </summary>
    /// <param name="expression">expression to build.</param>
    /// <returns>syntax tree's root.</returns>
    public Node Parse(string expression)
    {
        using var reader = new StringReader(expression);
        if (string.IsNullOrEmpty(expression))
        {
            throw new EmptyExpressionException("Empty expression");
        }

        return this.ParseNode(reader);
    }

    /// <summary>
    /// to build syntax tree from file.
    /// </summary>
    /// <param name="filePath">file to read.</param>
    /// <returns>syntax tree's root.</returns>
    public Node ParseFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        var expression = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(expression))
        {
            throw new EmptyExpressionException("Empty file");
        }

        return this.Parse(expression);
    }

    /// <summary>
    /// to skip whitespaces.
    /// </summary>
    /// <param name="reader">expression.</param>
    private static void SkipWhiteSpace(StringReader reader)
    {
        while (char.IsWhiteSpace((char)reader.Peek()))
        {
            reader.Read();
        }
    }

    /// <summary>
    /// to read operation.
    /// </summary>
    /// <param name="reader">expression to read.</param>
    /// <returns>operation.</returns>
    private static char ReadOperation(StringReader reader)
    {
        SkipWhiteSpace(reader);

        var operation = (char)reader.Read();

        return operation switch
        {
            '+' or '-' or '*' or '/' => operation,
            _ => throw new FormatException($"Unexpected operation {operation}"),
        };
    }

    /// <summary>
    /// to parse operand.
    /// </summary>
    /// <param name="reader">expression to parse.</param>
    /// <returns>parsed operand.</returns>
    private static Operand ParseOperand(StringReader reader)
    {
        SkipWhiteSpace(reader);
        var digits = new StringBuilder();

        while (char.IsDigit((char)reader.Peek()))
        {
            digits.Append((char)reader.Read());
        }

        if (digits.Length == 0)
        {
            throw new FormatException($"Expected digits");
        }

        return new Operand(int.Parse(digits.ToString()));
    }

    /// <summary>
    /// to parse node.
    /// </summary>
    /// <param name="reader">expression to parse.</param>
    /// <returns>parsed node.</returns>
    private Node ParseNode(StringReader reader)
    {
        SkipWhiteSpace(reader);

        var nextChar = reader.Peek();
        if (nextChar == -1)
        {
            throw new FormatException("Unexpected end of stream");
        }

        var currentChar = (char)nextChar;

        switch (currentChar)
        {
            case '(':
            {
                reader.Read();
                return this.ParseOperation(reader);
            }

            case var _ when char.IsDigit(currentChar):
            {
                return ParseOperand(reader);
            }

            case '+':
            case '-':
            case '*':
            case '/':
            {
                throw new FormatException($"Operator {currentChar} must be inside parentheses");
            }

            default:
            {
                throw new FormatException($"Unexpected character {currentChar}");
            }
    }
    }

    /// <summary>
    /// to parse operation.
    /// </summary>
    /// <param name="reader">expression to parse.</param>
    /// <returns>parsed node.</returns>
    private Node ParseOperation(StringReader reader)
        {
            var operation = ReadOperation(reader);
            var left = this.ParseNode(reader);
            var right = this.ParseNode(reader);

            SkipWhiteSpace(reader);
            if (reader.Read() != ')')
            {
                throw new FormatException("Missing closing parenthesis");
            }

            return operation switch
            {
                '+' => new Add(left, right),
                '-' => new Subtract(left, right),
                '*' => new Multiply(left, right),
                '/' => new Divide(left, right),
                _ => throw new FormatException($"Unknown operation {operation}"),
            };
        }
}
