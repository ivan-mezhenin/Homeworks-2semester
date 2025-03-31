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
    /// gets the adjacency list.
    /// </summary>
    public Dictionary<int, List<(int Neighbour, int Throughput)>> Edges { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/> class.
    /// </summary>
    public Graph()
    {
        this.Edges = new Dictionary<int, List<(int, int)>>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/> class.
    /// </summary>
    /// <param name="filePath">file to read data to graph.</param>
    public Graph(string filePath)
        : this()
    {
        this.ReadDataFromFile(filePath);
    }

    /// <summary>
    /// to add edge.
    /// </summary>
    /// <param name="from">vertex.</param>
    /// <param name="to">neighbour vertex.</param>
    /// <param name="throughput">throughput capacity between vertexes.</param>
    public void Add(int from, int to, int throughput)
    {
        if (this.Edges.TryGetValue(from, out var edges))
        {
            edges.Add((to, throughput));
            return;
        }

        this.Edges.Add(from, [(to, throughput)]);
    }

    /// <summary>
    /// to read graph from file.
    /// </summary>
    /// <param name="filePath">file to read.</param>
    private void ReadDataFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found", filePath);
        }

        using var reader = new StreamReader(filePath);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null)
            {
                continue;
            }

            var parts = line.Split(':', 2);
            if (parts.Length != 2)
            {
                throw new FormatException($"Invalid format. Expected (vertex): list of neighbour vertex numbers");
            }

            if (!int.TryParse(parts[0].Trim(), out var fromVertex))
            {
                throw new FormatException("Invalid vertex number format");
            }

            var edges = parts[1].Trim().Split(',');

            foreach (var edge in edges)
            {
                var trimmedEdge = edge.Trim();
                if (string.IsNullOrEmpty(trimmedEdge))
                {
                    continue;
                }

                var edgeParts = trimmedEdge.Split(' ');
                edgeParts[1] = edgeParts[1].Trim('(', ')');

                if (edgeParts.Length != 2 ||
                    !int.TryParse(edgeParts[0], out var toVertex) ||
                    !int.TryParse(edgeParts[1], out var throughput))
                {
                    throw new FormatException($"Invalid edge format: '{trimmedEdge}'");
                }

                this.Add(fromVertex, toVertex, throughput);
                this.Add(toVertex, fromVertex, throughput);
            }
        }
    }
}