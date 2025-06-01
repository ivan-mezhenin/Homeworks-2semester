// <copyright file="GraphTests.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
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
    /// test catch exception file not found.
    /// </summary>
    [Test]
    public void Graph_ReadFormNonexistentFile_ShouldThrowException()
    {
        Assert.Throws<FileNotFoundException>(() =>
        {
            var graph = new Graph("NonexistentFile.txt");
        });
    }

    /// <summary>
    /// test read graph from file.
    /// </summary>
    [Test]
    public void Graph_ReadGraphFromFile()
    {
        var graph = new Graph(Path.Combine(AppContext.BaseDirectory, "TestFiles", "TestReadGraphFromFile.txt"));
        var expectedGraph = new Graph();

        expectedGraph.Add(1, 2, 5);
        expectedGraph.Add(2, 1, 5);
        expectedGraph.Add(1, 3, 15);
        expectedGraph.Add(3, 1, 15);
        expectedGraph.Add(2, 4, 17);
        expectedGraph.Add(4, 2, 17);

        Assert.That(CompareGraph(graph, expectedGraph), Is.True);
    }

    /// <summary>
    /// test throw format exception.
    /// </summary>
    [Test]
    public void Graph_ReadGraphFromFile_ShouldThrowFormatException()
    {
        Assert.Throws<FormatException>(() =>
        {
            var graph = new Graph(Path.Combine(AppContext.BaseDirectory, "TestFiles", "TestReadGraphFromFIleFormatException.txt"));
        });
    }

    /// <summary>
    /// test throw graph is not connected exception.
    /// </summary>
    [Test]
    public void Graph_SearchMaxSpanningTree_ShouldThrowGraphIsNotConnectedException()
    {
        var graph = new Graph(Path.Combine(AppContext.BaseDirectory, "TestFiles", "TestNotConnectedGraph.txt"));
        Assert.Throws<GraphIsNotConnectedException>(() => graph.SearchMaxSpanningTree());
    }

    /// <summary>
    /// test search max spanning tree.
    /// </summary>
    [Test]
    public void Graph_SearchMaxSpanningTree()
    {
        var graph = new Graph(Path.Combine(AppContext.BaseDirectory, "TestFiles", "TestSearchMaxSpanningTree.txt"));
        var tree = graph.SearchMaxSpanningTree();
        var expectedResult = new Graph();

        expectedResult.Add(1, 2, 10);
        expectedResult.Add(2, 4, 15);
        expectedResult.Add(3, 5, 5);
        expectedResult.Add(4, 3, 20);

        Assert.That(CompareGraph(expectedResult, tree), Is.True);
    }

    private static bool CompareGraph(Graph graph1, Graph graph2)
    {
        if (graph1.Edges.Count != graph2.Edges.Count)
        {
            return false;
        }

        foreach (var (vertex, edges1) in graph1.Edges)
        {
            if (!graph2.Edges.TryGetValue(vertex, out var edges2))
            {
                return false;
            }

            if (edges1.Count != edges2.Count)
            {
                return false;
            }

            for (var i = 0; i < edges1.Count; i++)
            {
                if (edges1[i] != edges2[i])
                {
                    return false;
                }
            }
        }

        return true;
    }
}