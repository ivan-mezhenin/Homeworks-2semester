// <copyright file="SkipList.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

namespace MySkipList;

using System.Collections;

/// <summary>
/// skip list.
/// </summary>
/// <typeparam name="T">type of list's elements.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private const int MaxLevel = 32;
    private readonly Random isLevelUp = new Random();
    private readonly SkipListElement nil = new(default, null, null);
    private SkipListElement head;
    private SkipListElement bottomHead;
    private int version;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    public SkipList()
    {
        this.bottomHead = new SkipListElement(default, this.nil, this.nil);
        var current = this.bottomHead;

        for (var i = 0; i < MaxLevel; i++)
        {
            current = new SkipListElement(default, this.nil, current);
        }

        this.head = current;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    /// <param name="collection">collection to initialization.</param>
    public SkipList(IEnumerable<T> collection)
    : this()
    {
        foreach (var item in collection)
        {
            this.Add(item);
        }
    }

    /// <inheritdoc/>
    public int Count { get; private set; }

    /// <inheritdoc/>
    public bool IsReadOnly => false;

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

            for (var i = 0; i < index; ++i)
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

    /// <inheritdoc/>
    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var newLevel = this.GetRandomLevel();
        var current = this.head;
        var updates = new SkipListElement[newLevel];

        for (var i = 0; i <= MaxLevel - newLevel; i++)
        {
            current = current.Down ?? current;
        }

        for (var i = newLevel - 1; i >= 0; --i)
        {
            while (current != null && current.Next != null && current.Next != this.nil && current.Next.Value != null &&
                   current.Next.Value.CompareTo(item) < 0)
            {
                current = current.Next;
            }

            updates[i] = current ?? throw new InvalidOperationException("Attempt to add a null value to the list.");
            current = current.Down;
        }

        SkipListElement? lowerNode = null;

        for (var i = 0; i < newLevel; ++i)
        {
            var newNode = new SkipListElement(item, updates[i].Next, lowerNode);
            updates[i].Next = newNode;
            lowerNode = newNode;
        }

        ++this.Count;
        ++this.version;
    }

    /// <inheritdoc/>
    public void Clear()
    {
        this.bottomHead = new SkipListElement(default, this.nil, this.nil);
        var current = this.bottomHead;

        for (var i = 1; i < MaxLevel; i++)
        {
            current = new SkipListElement(default, this.nil, current);
        }

        this.head = current;
        this.Count = 0;
        ++this.version;
    }

    /// <inheritdoc/>
    public bool Contains(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var current = this.head;

        while (current != null)
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

            current = current.Down;
        }

        return false;
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (arrayIndex < 0 || arrayIndex >= array.Length || arrayIndex + this.Count > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        var current = this.bottomHead.Next;

        while (current != this.nil)
        {
            if (current == null || current.Value == null)
            {
                throw new ArgumentException("Element is empty.");
            }

            array[arrayIndex] = current.Value;

            ++arrayIndex;
            current = current.Next;
        }
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

        while (current != null)
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

            current = current.Down;
        }

        if (isRemoved)
        {
            --this.Count;
            ++this.version;
        }

        return isRemoved;
    }

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
            this.Remove(this[index]);
        }

    /// <summary>
    /// to get random level.
    /// </summary>
    /// <returns>level.</returns>
    private int GetRandomLevel()
    {
        var level = 1;

        while (this.isLevelUp.NextDouble() < 0.65 && level < MaxLevel)
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
}