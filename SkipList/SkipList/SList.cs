// <copyright file="SList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

using System.Collections;

/// <summary>
/// skip list.
/// </summary>
public class SList<T> : IList<T>
{
    private const int MaxLevel = 32;
    private readonly SkipListElement nil = new(default, null, null);
    private SkipListElement head;
    private int version;

    private Random isLevelUp = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="SList{T}"/> class.
    /// </summary>
    public SList()
    {
        var bottomHead = new SkipListElement(default, this.nil, this.nil);
        var current = bottomHead;

        for (var i = 1; i < MaxLevel; i++)
        {
            current = new SkipListElement(default, this.nil, current);
        }

        this.head = current;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SList{T}"/> class.
    /// </summary>
    /// <param name="collection">collection to initialization.</param>
    public SList(IEnumerable<T> collection)
    : this()
    {
        foreach (var item in collection)
        {
            this.Add(item);
        }
    }

    /// <summary>
    /// to get random level.
    /// </summary>
    /// <returns>level.</returns>
    private int GetRandomLevel()
    {
        var level = 1;

        while (this.isLevelUp.NextDouble() < 0.5 && level < MaxLevel)
        {
            ++level;
        }

        return level;
    }

    private class SkipListElement(T? value, SkipListElement? next, SkipListElement? down)
    {
        public T? Value { get; set; } = value;

        public SkipListElement? Next { get; set; } = next;

        public SkipListElement? Down { get; set; } = down;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}