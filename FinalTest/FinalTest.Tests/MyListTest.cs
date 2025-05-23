// <copyright file="MyListTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest.Tests;

/// <summary>
/// test for list.
/// </summary>
public class MyListTest
{
    /// <summary>
    /// test for adding new element in list.
    /// </summary>
    [Test]
    public void List_Add_NewElement()
    {
        var list = new MyList<int>();

        list.Add(1);
        list.Add(2);

        Assert.That(list.Count, Is.EqualTo(2));
    }

    /// <summary>
    /// check throws exception while adding null element.
    /// </summary>
    [Test]
    public void List_Add_NullElement_ThrowsArgumentNullException()
    {
        var list = new MyList<string>();

        Assert.Throws<ArgumentNullException>(() => list.Add(null!));
    }

    /// <summary>
    /// check enumerator returns all elements.
    /// </summary>
    [Test]
    public void List_GetEnumerator_ReturnsAllElements()
    {
        var list = new MyList<int> { 1, 2, 3 };
        var result = new List<int>();

        foreach (var item in list)
        {
            result.Add(item);
        }

        Assert.That(result, Is.EquivalentTo((int[])[1, 2, 3]));
    }

    /// <summary>
    /// check modification collection while iteration throws exception.
    /// </summary>
    [Test]
    public void List_GetEnumerator_ModifiedCollection_ThrowsInvalidOperationException()
    {
        var list = new MyList<int> { 1, 2 };
        var enumerator = list.GetEnumerator();

        enumerator.MoveNext();
        list.Add(3);

        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        enumerator.Dispose();
    }
}