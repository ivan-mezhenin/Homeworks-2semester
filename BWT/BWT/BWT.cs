namespace BWT;

/// <summary>
/// main class.
/// </summary>
public static class WordTransform
{
    /// <summary>
    /// dfdf.
    /// </summary>
    /// <param name="word">fdfdf.</param>
    /// <returns>fdffd.</returns>
    public static (string transformString, int position) Transform(string word)
    {
        string[] shifts = new string[word.Length];
        var currentString = word;

        for (var i = 0; i < word.Length; ++i)
        {
            word = word[1..] + word[0];
            shifts[i] = word;
        }

        Array.Sort(shifts);

        var transformString = string.Join(string.Empty, shifts.Select(x => x[^1]));
        var position = Array.IndexOf(shifts, word) + 1;

        return (transformString, position);
    }

    /// <summary>
    /// fdfdf.
    /// </summary>
    /// <param name="word">dfdffd.</param>
    /// <param name="position">dfdfdf.</param>
    /// <returns>dfdfddf.</returns>
    public static string ReverseTransform(string word, int position)
    {
        int[] count = new int[25600];

        for (var i = 0; i < 25600; ++i)
        {
            count[i] = 0;
        }

        for (var i = 0; i < word.Length; ++i)
        {
            ++count[word[i]];
        }

        int sum = 0;

        for (var i = 0; i < 25600; ++i)
        {
            sum += count[i];
            count[i] = sum - count[i];
        }

        int[] t = new int[word.Length];

        for (var i = 0; i < word.Length; ++i)
        {
            t[count[word[i]]] = i;
            count[word[i]]++;
        }

        int j = t[position - 1];

        char[] answer = new char[word.Length];

        for (var i = 0; i < word.Length; ++i)
        {
            answer[i] = word[j];
            j = t[j];
        }

        return string.Join(string.Empty, answer);
    }
}