// <copyright file="SkipListTest.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

namespace MySkipList.Tests;

/// <summary>
/// tests for skip list.
/// </summary>
public class SkipListTest
{
    /// <summary>
    /// test correct initialization skip list with elements.
    /// </summary>
    [Test]
    public void SList_Initialization_WithElements()
    {
        var testedList = new SkipList<char>(['a', 'b', 'c']);
        char[] expected = ['a', 'b', 'c'];

        Assert.That((char[])[testedList[0], testedList[1], testedList[2]], Is.EqualTo(expected));
    }

    /// <summary>
    /// test correct adding new elements in skip list.
    /// </summary>
    [Test]
    public void SList_Add_NewElements()
    {
        var testedList = new SkipList<int>();
        int[] expected = [1, 2, 3];

        testedList.Add(1);
        testedList.Add(2);
        testedList.Add(3);

        Assert.That((int[])[testedList[0], testedList[1], testedList[2]], Is.EqualTo(expected));
    }

    /// <summary>
    /// test correct adding one thousand elements.
    /// </summary>
    [Test]
    public void SList_Add_OneThousandElements()
    {
        var testedList = new SkipList<int>();

        for (var i = 1; i <= 1000; ++i)
        {
            testedList.Add(i);
        }

        Assert.That(testedList.Contains(500), Is.True);
    }

    /// <summary>
    /// adding null item should throw argument null exception.
    /// </summary>
    [Test]
    public void SList_Add_NullItem_ShouldThrowArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new SkipList<string>().Add(null!));

    /// <summary>
    /// test Count after adding new elements in list.
    /// </summary>
    [Test]
    public void SList_Count_CorrectAmountAfterAddingNewElements()
    {
        var testedList = new SkipList<string>();
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
        var testedList = new SkipList<char>((char[])['a', 'b', 'c']);
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
        var testedList = new SkipList<int>((int[])[1, 2, 3, 4]);
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
        var testedList = new SkipList<int>([1, 2, 3]);
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
        var list = new SkipList<string>(["a", "b", "c"]);

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

    /// <summary>
    /// list contains item.
    /// </summary>
    [Test]
    public void SList_Contains_ShouldReturnTrue()
    {
        var testedList = new SkipList<int> { 1 };

        Assert.That(testedList.Contains(1), Is.True);
    }

    /// <summary>
    /// test for correct copy.
    /// </summary>
    [Test]
    public void SList_CopyTo_ValidParameters_CopiesElementsCorrectly()
    {
        var list = new SkipList<int>([1, 2, 3]);
        var array = new int[3];

        list.CopyTo(array, 0);

        Assert.That(array, Is.EqualTo((int[])[1, 2, 3]));
    }

    /// <summary>
    /// test coping in list with smaller size throws exception.
    /// </summary>
    [Test]
    public void SList_CopyTo_InsufficientSpace_ThrowsArgumentOutOfRangeException()
    {
        var list = new SkipList<int>([1, 2, 3]);
        var smallArray = new int[2];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(smallArray, 0));
    }

    /// <summary>
    /// test correct remove element.
    /// </summary>
    [Test]
    public void SList_Remove_ExistingItem_ReturnsTrueAndRemovesItem()
    {
        var testedList = new SkipList<string>(["apple", "banana"]);

        var result = testedList.Remove("apple");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(testedList.Contains("apple"), Is.False);
            Assert.That(testedList.Count, Is.EqualTo(1));
        });
    }

    /// <summary>
    /// test for correct removing non-existing item.
    /// </summary>
    [Test]
    public void SList_Remove_NonExistingItem_ReturnsFalse()
    {
        var list = new SkipList<int>([1, 2, 3]);
        var result = list.Remove(4);
        const int expected = 3;

        Assert.That(result, Is.False);
        Assert.That(list.Count, Is.EqualTo(expected));
    }

    /// <summary>
    /// test for correct index of existing item.
    /// </summary>
    [Test]
    public void SList_IndexOf_ExistingItem_ReturnsCorrectIndex()
    {
        var testedList = new SkipList<string>(["apple", "banana", "chocolate"]);
        var result = testedList.IndexOf("chocolate");
        const int expected = 2;

        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// test for correct index of non-existing item.
    /// </summary>
    [Test]
    public void SList_IndexOf_NonExistingItem_ReturnsCorrectIndex()
    {
        var testedList = new SkipList<string>(["apple", "banana", "chocolate"]);
        var result = testedList.IndexOf("ivan");
        const int expected = -1;

        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// test calling method Insert throws NotSupportedException.
    /// </summary>
    [Test]
    public void SList_Insert_ThrowsNotSupportedException()
        => Assert.Throws<NotSupportedException>(() => new SkipList<int>().Insert(0, 1));
}