// <copyright file="FunctionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Functions.Tests;

using Functions;

/// <summary>
/// test for function.
/// </summary>
public class FunctionTest
{
    /// <summary>
    /// test Map with function which double each element.
    /// </summary>
    [Test]
    public void Function_Map_IntList_FunctionWhichDoubleEachElement()
    {
        var data = new List<int> { 1, 2, 3, 4 };
        var expectedResult = new List<int> { 2, 4, 6, 8 };

        Assert.That(Function.Map(data, x => x * 2), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test Map with function which change each element by one
    /// </summary>
    [Test]
    public void Function_Map_IntList_FunctionWhichChangeEachElementByOne()
    {
        var data = new List<int> { 9, 1, 12, 129 };
        var expectedResult = Enumerable.Repeat(1, 4).ToList();

        Assert.That(Function.Map(data, x => 1), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test filter with function which check is number odd.
    /// </summary>
    [Test]
    public void Function_Filter_IntList_ShouldReturnListWithOddElements()
    {
        var data = new List<int> { 1, 3, 5, 2, 20, 13, 100 };
        var expectedResult = new List<int> { 1, 3, 5, 13 };

        Assert.That(Function.Filter(data, x => x % 2 == 1), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test filter with function which check is number equal 3.
    /// </summary>
    [Test]
    public void Function_Filter_IntList_ShouldReturnEmptyList()
    {
        var data = Enumerable.Repeat(10, 99).ToList();
        var expectedResult = new List<int>();

        Assert.That(Function.Filter(data, x => x == 3), Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test fold with function which multiply value by each element of list.
    /// </summary>
    [Test]
    public void Function_Fold_IntList_FunctionWhichMultiplyValueByEachElement()
    {
        var data = new List<int> { 1, 2, 3 };
        const int startValue = 1;
        const int expectedResult = 6;

        Assert.That(Function.Fold(data, startValue, (acc, elem) => acc * elem), Is.EqualTo(expectedResult));
    }
}