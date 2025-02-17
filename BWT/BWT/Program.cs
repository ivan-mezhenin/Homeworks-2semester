class BWT
{
    static (string transformString, int position) Transform (string word)
    {
        string[] shifts = new string[word.Length];
        var currentString = word;

        for (var i = 0; i < word.Length; ++i)
        {
            word = word.Substring(1) + word[0];
            shifts[i] = word;
        }

        Array.Sort(shifts);

        var transformString = String.Join("", shifts.Select(x => x.Last()));
        var position = Array.IndexOf(shifts, word);

        return (transformString, position);

    }

    static void Main(string[] args)
    {
        var answer = BWT.Transform("ABACABA");
        Console.WriteLine($"{answer.transformString} : {answer.position.ToString()}");
    }
    
}