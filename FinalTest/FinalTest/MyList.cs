// <copyright file="MyList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest;

using System.Collections;

/// <summary>
/// generic list.
/// </summary>
/// <typeparam name="T">type of list's element.</typeparam>
public class MyList<T> : IEnumerable<T>
{
    private ListElement? head;
    private ListElement? tail;
    private int version;

    /// <summary>
    /// Gets amount of list's elements.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// to add new element in list.
    /// </summary>
    /// <param name="element">element to add.</param>
    public void Add(T element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        var newListElement = new ListElement(element);

        if (this.head == null)
        {
            this.head = newListElement;
        }
        else
        {
            this.tail!.Next = newListElement;
        }

        this.tail = newListElement;
        ++this.Count;
        ++this.version;
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        var currentElement = this.head;
        var initialVersion = this.version;

        if (initialVersion != this.version)
        {
            throw new InvalidOperationException("Collection was modified.");
        }

        while (currentElement != null)
        {
            if (initialVersion != this.version)
            {
                throw new InvalidOperationException("Collection was modified.");
            }

            if (currentElement.Value == null)
            {
                throw new NullReferenceException("Null element's value.");
            }

            yield return currentElement.Value;
            currentElement = currentElement.Next;
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class ListElement(T value)
    {
        public T Value { get; } = value;

        public ListElement? Next { get; set; }
    }
}