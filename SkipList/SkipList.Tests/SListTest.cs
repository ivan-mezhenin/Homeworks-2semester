// <copyright file="SListTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipList.Tests;

/// <summary>
/// tests for skip list.
/// </summary>
public class SListTest
{
    /// <summary>
    /// test correct initialization skip list with elements.
    /// </summary>
    [Test]
    public void SList_Initialization_WithElements()
    {
        var testedList = new SList<char>(['a', 'b', 'c']);
        char[] expected = ['a', 'b', 'c'];

        Assert.That((char[])[testedList[0], testedList[1], testedList[2]], Is.EqualTo(expected));
    }

    /// <summary>
    /// test correct adding new elements in skip list.
    /// </summary>
    [Test]
    public void SList_Add_NewElements()
    {
        var testedList = new SList<int>();
        int[] expected = [1, 2, 3];

        testedList.Add(1);
        testedList.Add(2);
        testedList.Add(3);

        Assert.That((int[])[testedList[0], testedList[1], testedList[2]], Is.EqualTo(expected));
    }

    /// <summary>
    /// adding null item should throw argument null exception.
    /// </summary>
    [Test]
    public void SList_Add_NullItem_ShouldThrowArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new SList<string>().Add(null!));

    /// <summary>
    /// test Count after adding new elements in list.
    /// </summary>
    [Test]
    public void SList_Count_CorrectAmountAfterAddingNewElements()
    {
        var testedList = new SList<string>();
        const int expected = 4;

        testedList.Add("aaada");
        testedList.Add("vsfef");
        testedList.Add("ivan");
        testedList.Add("navi");

        Assert.That(testedList.Count, Is.EqualTo(expected));
    }

    /// <summary>
    /// check enumerator returns all elements.
    /// </summary>
    [Test]
    public void List_GetEnumerator_ReturnsAllElements()
    {
        var testedList = new SList<char>((char[])['a', 'b', 'c']);
        var result = new List<int>();

        foreach (var item in testedList)
        {
            result.Add(item);
        }

        Assert.That(result, Is.EquivalentTo((int[])['a', 'b', 'c']));
    }

    /// <summary>
    /// check modification collection while iteration throws exception.
    /// </summary>
    [Test]
    public void SList_GetEnumerator_ModifiedCollection_ThrowsInvalidOperationException()
    {
        var testedList = new SList<int>((int[])[1, 2, 3, 4]);
        var enumerator = testedList.GetEnumerator();

        enumerator.MoveNext();
        testedList.Add(1);

        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());

        enumerator.Dispose();
    }

    /// <summary>
    /// test correct count after clearing list.
    /// </summary>
    [Test]
    public void SList_Clear_ShouldResetCountToZero()
    {
        var testedList = new SList<int>([1, 2, 3]);
        Assert.That(testedList.Count, Is.EqualTo(3));

        testedList.Clear();

        Assert.That(testedList.Count, Is.EqualTo(0));
    }

    /// <summary>
    /// test for inability to iterate after cleaning.
    /// </summary>
    [Test]
    public void SList_Clear_ShouldMakeCollectionEmpty()
    {
        var list = new SList<string>(["a", "b", "c"]);

        list.Clear();

        Assert.That(list, Is.Empty);
        Assert.That(
            () =>
        {
            using var enumerator = list.GetEnumerator();
            return enumerator.MoveNext();
        },
            Is.False);
    }
}