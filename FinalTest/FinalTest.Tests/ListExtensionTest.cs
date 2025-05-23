// <copyright file="ListExtensionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalTest.Tests;

/// <summary>
/// test for countNullElements.
/// </summary>
public class ListExtensionTest
{
    /// <summary>
    /// test count null elements in list of zeroes.
    /// </summary>
    [Test]
    public void CountNullElements_IntListWithZeros_ReturnsCorrectCount()
    {
        // Arrange
        var list = new MyList<int> { 1, 0, 2, 0, 3 };
        var checker = new IntNullChecker();
        const int expected = 2;

        // Act
        var result = list.CountNullElements(checker);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// test empty list contains zero null elements.
    /// </summary>
    [Test]
    public void CountNullElements_EmptyList_ReturnsZero()
    {
        var list = new MyList<int>();
        var checker = new IntNullChecker();
        const int expected = 0;

        // Act
        var result = list.CountNullElements(checker);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// test count null elements in string list.
    /// </summary>
    [Test]
    public void CountNullElements_StringList()
    {
        var list = new MyList<string> { "ivan", string.Empty, "ivan" };
        var checker = new StringNullChecker();
        const int expectedResult = 1;

        var result = list.CountNullElements(checker);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// null list should throw exception.
    /// </summary>
    [Test]
    public void CountNullElements_NullList_ThrowsArgumentNullException()
    {
        // Arrange
        MyList<int>? nullList = null;
        var checker = new IntNullChecker();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => nullList!.CountNullElements(checker));
    }

    /// <summary>
    /// null checker throws exception.
    /// </summary>
    [Test]
    public void CountNullElements_NullChecker_ThrowsArgumentNullException()
    {
        // Arrange
        var list = new MyList<int> { 1, 2, 3 };
        INullChecker<int>? nullChecker = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => list.CountNullElements(nullChecker!));
    }

    private class IntNullChecker : INullChecker<int>
    {
        public bool IsNull(int item) => item == 0;
    }

    private class StringNullChecker : INullChecker<string>
    {
        public bool IsNull(string item) => string.IsNullOrEmpty(item);
    }
    }
