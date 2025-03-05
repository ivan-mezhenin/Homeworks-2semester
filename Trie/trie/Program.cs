using Trie;

Bor trie = new ();
Console.WriteLine($"4 {trie.Add("iv")}");
Console.WriteLine($"5 {trie.Add("ivan")}");
Console.WriteLine($"6 {trie.Add("iva")}");

Console.WriteLine($"8 {trie.HowManyStartsWithPrefix("i")}");
Console.WriteLine($"9 {trie.Remove("iva")}");
Console.WriteLine($"10 {trie.Contains("iva")}");
Console.WriteLine($"11 {trie.HowManyStartsWithPrefix("i")}");