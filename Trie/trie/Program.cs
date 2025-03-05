using Trie;

Bor trie = new ();
Console.WriteLine($"4 {trie.Add("iv")}");
Console.WriteLine($"5 {trie.Add("ivan")}");
Console.WriteLine($"6 {trie.Add("iva")}");
Console.WriteLine($"7 {trie.Contains("i")}");
Console.WriteLine($"8 {trie.Contains("iva")}");
Console.WriteLine($"9 {trie.Contains("iv")}");

Console.WriteLine($"11 {trie.Remove("iv")}");

Console.WriteLine($"13 {trie.Contains("i")}");
Console.WriteLine($"14 {trie.Contains("ivan")}");
Console.WriteLine($"15 {trie.Contains("iv")}");
