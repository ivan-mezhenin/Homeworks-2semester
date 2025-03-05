using Trie;

Bor trie = new ();
Console.WriteLine($"{trie.Add("iv")}");
Console.WriteLine($"{trie.Add("ivan")}");
Console.WriteLine($"{trie.Add("iva")}");
Console.WriteLine($"{trie.Contains("i")}");
Console.WriteLine($"{trie.Contains("iva")}");
Console.WriteLine($"{trie.Contains("iv")}");