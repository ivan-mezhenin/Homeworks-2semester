namespace BWT;

/// <summary>
/// BWT realization.
/// </summary>
public static class BWt
{
    /// <summary>
    /// word transform.
    /// </summary>
    /// <param name="word">word, which will be transformed.</param>
    /// <returns>transformed word and position.</returns>
    public static (string TransformWord, int Position) Transform(string word)
    {
        var shifts = new string[word.Length];
        var currentString = word;

        for (var i = 0; i < word.Length; ++i)
        {
            word = word[1..] + word[0];
            shifts[i] = word;
        }

        Array.Sort(shifts);

        var transformWord = string.Join(string.Empty, shifts.Select(x => x[^1]));
        var position = Array.IndexOf(shifts, word) + 1;

        return (transformWord, position);
    }

    /// <summary>
    /// reverse word transform.
    /// </summary>
    /// <param name="word">transformed word.</param>
    /// <param name="position">original word index.</param>
    /// <returns>original word.</returns>
    public static string ReverseTransform(string word, int position)
    {
        var wordLength = word.Length;
        Dictionary<char, int> charsCounter = new();
        Dictionary<char, int> startPositions = new();
        var next = new int[wordLength];
        var summary = 0;

        position--;

        foreach (var symbol in word)
        {
            if (!charsCounter.TryGetValue(symbol, out int value))
            {
                value = 0;
                charsCounter.Add(symbol, value);
            }

            value++;
            charsCounter[symbol] = value;
        }

        var sortedChars = charsCounter.Keys.ToArray();
        Array.Sort(sortedChars);

        foreach (var symbol in sortedChars)
        {
            startPositions[symbol] = summary;
            summary += charsCounter[symbol];
        }

        for (var i = 0; i < wordLength; ++i)
        {
            var currentSymbol = word[i];
            next[startPositions[currentSymbol]] = i;
            startPositions[currentSymbol]++;
        }

        var originalWord = new char[wordLength];
        var current = position;
        for (var i = 0; i < wordLength; ++i)
        {
            originalWord[i] = word[next[current]];
            current = next[current];
        }

        return string.Join(string.Empty, originalWord);
    }
}