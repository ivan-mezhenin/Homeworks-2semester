// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Routers;

var graph = new Graph("/home/ivan/Homeworks-2semester/Routers/Routers/TestData/test.txt");

Console.WriteLine($"{graph.AreAllVerticesRechable()}");