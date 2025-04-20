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

        Assert.That(Function.Map(data, x => 2), Is.EqualTo(expectedResult));
    }
}