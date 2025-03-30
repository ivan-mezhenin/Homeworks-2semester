// <copyright file="Graph.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// to work with graph.
/// </summary>
public class Graph
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/> class.
    /// </summary>
    public Graph()
    {
        this.Edges = new Dictionary<int, List<(int, int)>>();
    }

    /// <summary>
    /// gets the adjacency list.
    /// </summary>
    public Dictionary<int, List<(int, int)>> Edges { get; }

    /// <summary>
    /// to add edge.
    /// </summary>
    /// <param name="number">vertex.</param>
    /// <param name="neighbour">neighbour vertex.</param>
    /// <param name="throughputСapacity">throughput capacity between vertexes.</param>
    public void Add(int number, int neighbour, int throughputСapacity)
    {
        if (this.Edges.TryGetValue(number, out var edges))
        {
            edges.Add((neighbour, throughputСapacity));
        }

        this.Edges.Add(number, [(neighbour, throughputСapacity)]);
    }
}