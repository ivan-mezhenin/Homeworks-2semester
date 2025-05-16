// <copyright file="LinqTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq.Test;

using MyLinq;

/// <summary>
/// test for linq.
/// </summary>
public class LinqTests
{
    /// <summary>
    /// test method GetPrimes by taking first 5 numbers.
    /// </summary>
    [Test]
    public void Linq_GetPrimes_FirstFiveNumbers()
    {
        Assert.That(Linq.GetPrimes().Take(5), Is.EquivalentTo((int[])[2, 3, 5, 7, 11]));
    }

    /// <summary>
    /// test method Take by taking first 4 elements of char array.
    /// </summary>
    [Test]
    public void Linq_Take_FirstFourElements()
    {
        Assert.That(((char[])['a', 'b', 'c', 'd', 'e', 'f']).Take(4), Is.EquivalentTo((char[])['a', 'b', 'c', 'd']));
    }
}