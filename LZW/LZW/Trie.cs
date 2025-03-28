namespace LZW;

/// <summary>
/// realization of Trie for LZW.
/// </summary>
public class Trie
{
    private readonly TrieNode root = new();

    /// <summary>
    /// Gets amount of added words in Trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// filling trie of bytes.
    /// </summary>
    /// <returns>trie.</returns>
    public static Trie Initialization()
    {
        Trie newTrie = new();

        for (var i = 0; i < 256; ++i)
        {
            newTrie.Add([(byte)i], i);
        }

        return newTrie;
    }

    /// <summary>
    /// add new element in trie.
    /// </summary>
    /// <param name="element">element to add.</param>
    /// <param name="code">code of element.</param>
    /// <returns>false if element already added.</returns>
    public bool Add(List<byte> element, int code)
    {
        if (element.Count == 0 || code < 0)
        {
            return false;
        }

        var currentNode = this.root;

        foreach (var symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var value))
            {
                value = new TrieNode();
                currentNode.Children[symbol] = value;
            }

            currentNode = value;
        }

        if (currentNode.IsTerminal)
        {
            return false;
        }

        currentNode.IsTerminal = true;
        currentNode.Code = code;
        this.Size++;

        return true;
    }

    /// <summary>
    /// check is trie contains element.
    /// </summary>
    /// <param name="element">element to check.</param>
    /// <returns>-1 if trie doesn't contains element, element's code if element in trie.</returns>
    public int Contains(List<byte> element)
    {
        int trieDoesNotContainsElement = -1;

        if (element.Count == 0)
        {
            return trieDoesNotContainsElement;
        }

        var currentNode = this.root;

        foreach (var symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var value))
            {
                return trieDoesNotContainsElement;
            }

            currentNode = value;
        }

        return currentNode.IsTerminal ? currentNode.Code : -1;
    }

    private class TrieNode
    {
        public Dictionary<byte, TrieNode> Children { get; set; } = new();

        public bool IsTerminal { get; set; }

        public int Code { get; set; } = -1;
    }
}