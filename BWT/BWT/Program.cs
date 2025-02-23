using BWT;

var (word, position) = WordTransform.Transform("иван");
Console.WriteLine($"{word}, {position}");
Console.WriteLine($"{WordTransform.ReverseTransform(word, position)}");