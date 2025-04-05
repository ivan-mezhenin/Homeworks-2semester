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
    /// Initializes a new instance of the <see cref="Graph"/> class.
    /// </summary>
    /// <param name="filePath">file to read data to graph.</param>
    public Graph(string filePath)
        : this()
    {
        this.ReadDataFromFile(filePath);
    }

    /// <summary>
    /// gets the adjacency list.
    /// </summary>
    public Dictionary<int, List<(int Neighbour, int Throughput)>> Edges { get; }

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
    /// to search max spanning tree.
    /// </summary>
    /// <returns>max spanning tree.</returns>
    public Graph SearchMaxSpanningTree()
    {
        if (this.Edges.Count == 0)
        {
            throw new PassingNullGraphException("Passing null graph");
        }

        if (!this.AreAllVerticesReachable())
        {
            throw new GraphIsNotConnectedException(
                "Passing not connected graph in function of searching max spanning tree");
        }

        var maxSpanningTree = new Graph();
        var queue = new PriorityQueue<(int From, int To, int Throughput), int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a)));
        var visited = new HashSet<int>();

        int startVertex = this.Edges.Keys.First();
        visited.Add(startVertex);

        foreach (var edge in this.Edges[startVertex])
        {
            queue.Enqueue((startVertex, edge.Neighbour, edge.Throughput), edge.Throughput);
        }

        while (queue.Count > 0 && visited.Count < this.Edges.Count)
        {
            var currentEdge = queue.Dequeue();
            var fromVertex = currentEdge.From;
            var toVertex = currentEdge.To;
            var throughput = currentEdge.Throughput;

            if (visited.Contains(toVertex))
            {
                continue;
            }

            maxSpanningTree.Add(fromVertex, toVertex, throughput);
            visited.Add(toVertex);

            foreach (var edge in this.Edges[toVertex])
            {
                if (!visited.Contains(edge.Neighbour))
                {
                    queue.Enqueue((toVertex, edge.Neighbour, edge.Throughput), edge.Throughput);
                }
            }
        }

        return maxSpanningTree;
    }

    /// <summary>
    /// to write graph to file.
    /// </summary>
    /// <param name="filePath">file for writing.</param>
    public void WriteGraphToFile(string filePath)
    {
        Directory.CreateDirectory("Output");
        filePath = Path.Combine("Output", filePath);

        using var writer = new StreamWriter(filePath);
        foreach (var (vertex, edges) in this.Edges)
        {
            var formattedEdges = edges.Select(e => $"{e.Neighbour} ({e.Throughput})");
            writer.WriteLine($"{vertex}: {string.Join(", ", formattedEdges)}");
        }
    }

    /// <summary>
    /// return true if all vertices are reachable.
    /// </summary>
    /// <returns>true or false.</returns>
    public bool AreAllVerticesReachable()
    {
        var startVertex = this.Edges.First().Key;

        var visited = new Dictionary<int, bool>();

        foreach (var vertex in this.Edges.Keys)
        {
            visited.Add(vertex, false);
        }

        this.DFS(startVertex, visited);

        return visited.All(kv => kv.Value);
    }

    /// <summary>
    /// depth first search.
    /// </summary>
    /// <param name="startVertex">vertex to start search.</param>
    /// <param name="visited">dictionary of visited vertices.</param>
    private void DFS(int startVertex, Dictionary<int, bool> visited)
    {
        visited[startVertex] = true;

        foreach (var edge in this.Edges[startVertex])
        {
            if (!visited[edge.Neighbour])
            {
                this.DFS(edge.Neighbour, visited);
            }
        }
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
            if (string.IsNullOrWhiteSpace(line))
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