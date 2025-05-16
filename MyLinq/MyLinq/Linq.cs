// <copyright file="Linq.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics;

namespace MyLinq;

/// <summary>
/// .
/// </summary>
public class Linq
{
    /// <summary>
    /// Generates an infinite sequence of prime numbers.
    /// </summary>
    /// <returns>sequence.</returns>
    public static IEnumerable<int> GetPrimes()
    {
        var number = 2;

        while (true)
        {
            if (IsPrime(number))
            {
                yield return number;
            }

            ++number;
        }
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (var i = 2; i * i <= number; ++i)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}