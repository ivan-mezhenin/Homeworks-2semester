// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SyntaxTree;

Console.WriteLine("SyntaxTree. Write dotnet run -- filePath");

try
{
    var parser = new Parser();
    var expression = parser.ParseFromFile(args[0]);

    Console.WriteLine($"Expression: {expression.Print()}");
    Console.WriteLine($"Result: {expression.Evaluate()}");
}
catch (FormatException exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}
catch (EmptyExpressionException exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}
catch (FileNotFoundException exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}
catch (DivideByZeroException exception)
{
    Console.WriteLine(exception.Message);
    return 1;
}

return 0;