// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using SyntaxTree;

var parser = new Parser();
var expression = parser.Parse("(* (+ 1 1) 2)");

Console.WriteLine(expression.Evaluate());
Console.WriteLine(expression.Print());
