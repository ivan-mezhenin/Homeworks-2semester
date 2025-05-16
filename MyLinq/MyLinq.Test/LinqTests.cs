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
        Assert.That(Linq.GetPrimes().Take(5).ToList(), Is.EquivalentTo((int[])[2, 3, 5, 7, 11]));
    }
}