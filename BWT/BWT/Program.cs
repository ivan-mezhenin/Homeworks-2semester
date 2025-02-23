using BWT;

var (word, position) = WordTransform.Transform("иван");
Console.WriteLine($"{word}, {position}");