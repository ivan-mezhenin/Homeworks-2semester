// <copyright file="PriorityQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Test1;

/// <summary>
/// priority queue.
/// </summary>
public class PriorityQueue
{
    private Node? head;

    /// <summary>
    /// Gets a value indicating whether gets true if queue is empty.
    /// </summary>
    public bool Empty => this.head == null;

    /// <summary>
    /// to add element in queue.
    /// </summary>
    /// <param name="value">value to add.</param>
    /// <param name="priority">value's priority.</param>
    public void Enqueue(int value, int priority)
    {
        var newNode = new Node(value, priority);

        if (this.head == null || priority > this.head.Priority)
        {
            newNode.Next = this.head;
            this.head = newNode;
            return;
        }

        var currentNode = this.head;

        while (currentNode.Next != null && currentNode.Next.Priority >= priority)
        {
            currentNode = currentNode.Next;
        }

        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;
    }

    /// <summary>
    /// to get element with the biggest priority.
    /// </summary>
    /// <returns>element with biggest priority.</returns>
    public int Dequeue()
    {
        if (this.head == null)
        {
            throw new EmptyEnqueueException("Trying to dequeue an empty priority queue.");
        }

        var value = this.head.Value;
        this.head = this.head.Next;

        return value;
    }

    private class Node(int value, int priority)
    {
        public int Value { get; } = value;

        public int Priority { get; } = priority;

        public Node? Next { get; set; } = null;
    }
}