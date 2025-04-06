// <copyright file="GraphTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers.Tests;

using Routers;

/// <summary>
/// Tests for Graph.
/// </summary>
public class GraphTests
{
    /// <summary>
    /// test method Add by adding new edge.
    /// </summary>
    [Test]
    public void Graph_Add_NewEdge_ShouldReturnTrue()
    {
        var graph = new Graph();
        const int expectedNeighbour = 2;
        const int expectedThroughput = 10;

        graph.Add(1, 2, 10);

        Assert.That(graph.Edges[1][0].Neighbour, Is.EqualTo(expectedNeighbour));
        Assert.That(graph.Edges[1][0].Throughput, Is.EqualTo(expectedThroughput));
    }

    /// <summary>
    /// test catch exception add already existing edge.
    /// </summary>
    [Test]
    public void Graph_Add_AlreadyExistingEdge_ShouldCatchException()
    {
        var graph = new Graph();

        graph.Add(1, 2, 10);

        Assert.Throws<EdgeAlreadyExistException>(() => graph.Add(1, 2, 15));
    }

    /// <summary>
    /// test read graph from file.
    /// </summary>
    [Test]
    public void Graph_ReadGraphFromFile()
    {
        var graph = new Graph(GetTestFilePath("TestReadGraphFromFile.txt"));

        Assert.That(graph.Edges[1][0].Neighbour, Is.EqualTo(2));
    }

    private static string GetTestFilePath(string fileName)
    {
        var projectDirectory = Directory.GetCurrentDirectory();
        var directory = new DirectoryInfo(projectDirectory);

        while (directory != null && !directory.GetFiles("*.csproj").Any())
        {
            directory = directory.Parent;
        }

        var fullPath = Path.Combine(directory!.FullName, "TestFiles", fileName);

        return fullPath;
    }
}