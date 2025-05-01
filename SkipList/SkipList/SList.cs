// <copyright file="SList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList;

using System.Collections;

/// <summary>
/// skip list.
/// </summary>
/// <typeparam name="T">type of list's elements.</typeparam>
public class SList<T> : IList<T>
    where T : IComparable<T>
{
    private const int MaxLevel = 32;
    private readonly Random isLevelUp = new Random();
    private readonly SkipListElement nil = new(default, null, null);
    private SkipListElement head;
    private SkipListElement bottomHead;
    private int version;

    /// <summary>
    /// Initializes a new instance of the <see cref="SList{T}"/> class.
    /// </summary>
    public SList()
    {
        this.bottomHead = new SkipListElement(default, this.nil, this.nil);
        var current = this.bottomHead;

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

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        var current = this.bottomHead.Next;
        var initialVersion = this.version;

        while (current != this.nil && current != null)
        {
            if (initialVersion != this.version)
            {
                throw new InvalidOperationException("Collection was modified.");
            }

            if (current.Value == null)
            {
                throw new NullReferenceException("Null element's value.");
            }

            yield return current.Value;
            current = current.Next;
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// to add item in list.
    /// </summary>
    /// <param name="item">item to add.</param>
    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var newLevel = this.GetRandomLevel();
        var current = this.head;
        SkipListElement? downNode = null;

        for (var i = newLevel - 1; i >= 0; --i)
        {
            while (current.Next != null && current.Next != this.nil &&
                   current.Next.Value != null &&
                   current.Next.Value.CompareTo(item) < 0)
            {
                current = current.Next;
            }

            var newNode = new SkipListElement(item, current.Next, i == 0 ? this.nil : downNode);
            current.Next = newNode;
            downNode = newNode;

            current = current.Down ?? current;
        }

        ++this.Count;
        ++this.version;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool Contains(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var current = this.head;

        for (var i = MaxLevel - 1; i >= 0; --i)
        {
            while (current.Next != null && current.Next != this.nil &&
                   current.Next.Value != null &&
                   current.Next.Value.CompareTo(item) < 0)
            {
                current = current.Next;
            }

            if (current.Next != null && current.Next.Value != null &&
                current.Next.Value.CompareTo(item) == 0)
            {
                return true;
            }

            current = current.Down ?? current;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (!this.Contains(item))
        {
            return false;
        }

        var current = this.head;
        var isRemoved = false;

        for (var i = MaxLevel - 1; i >= 0; --i)
        {
            while (current.Next != null
                   && current.Next != this.nil
                   && current.Next.Value != null
                   && current.Next.Value.CompareTo(item) < 0)
            {
                current = current.Next;
            }

            if (current.Next != this.nil &&
                current.Next != null &&
                current.Next.Value != null &&
                current.Next.Value.CompareTo(item) == 0)
            {
                current.Next = current.Next.Next;
                isRemoved = true;
            }

            current = current.Down ?? current;
        }

        if (isRemoved)
        {
            --this.Count;
            ++this.version;
        }

        return isRemoved;
    }

    public int Count { get; private set; }

    public bool IsReadOnly { get; }

    /// <inheritdoc/>
    public int IndexOf(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var index = 0;
        var current = this.bottomHead.Next;

        while (current != null && current != this.nil)
        {
            if (current.Value == null)
            {
                throw new InvalidOperationException("List contains null values");
            }

            var comparison = current.Value.CompareTo(item);
            if (comparison == 0)
            {
                return index;
            }

            if (comparison > 0)
            {
                break;
            }

            current = current.Next;
            ++index;
        }

        return -1;
    }

    /// <inheritdoc/>
    public void Insert(int index, T item)
        => throw new NotSupportedException("Insert by index is not supported in skip list.");

    /// <inheritdoc/>
    public void RemoveAt(int index)
        {
            var value = this[index];
            if (value == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            this.Remove(value);
        }

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var current = this.bottomHead.Next ?? throw new EmptySkipListException("Attempt to take an item from empty list");

            for (var i = 0; i <= index; ++i)
            {
                current = current.Next ?? throw new InvalidOperationException("Index is out of range.");
            }

            if (current.Value == null)
            {
                throw new InvalidOperationException("SkipList contains null value at specified index");
            }

            return current.Value;
        }

        set => throw new NotImplementedException();
    }

    private class SkipListElement(T? value, SkipListElement? next, SkipListElement? down)
    {
        public T? Value { get; set; } = value;

        public SkipListElement? Next { get; set; } = next;

        public SkipListElement? Down { get; set; } = down;
    }
}