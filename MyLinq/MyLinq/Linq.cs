// <copyright file="Linq.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// methods for IEnumerable collections.
/// </summary>
public static class Linq
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

    /// <summary>
    /// return sequence of first n elements.
    /// </summary>
    /// <param name="seq">sequence to return first n elements.</param>
    /// <param name="n">length of sequence.</param>
    /// <typeparam name="T">type of sequence's element.</typeparam>
    /// <returns>sequence.</returns>
    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        if (n <= 0)
        {
            yield break;
        }

        var count = 0;

        foreach (var item in seq)
        {
            yield return item;

            ++count;

            if (count >= n)
            {
                yield break;
            }
        }
    }

    /// <summary>
    /// return sequence with skipped first n elements.
    /// </summary>
    /// <param name="seq">sequence to skipped elements.</param>
    /// <param name="n">amount of elements to skip.</param>
    /// <typeparam name="T">type of sequence's element.</typeparam>
    /// <returns>sequence.</returns>
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        var count = 0;

        foreach (var item in seq)
        {
            ++count;

            if (count > n)
            {
                yield return item;
            }
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