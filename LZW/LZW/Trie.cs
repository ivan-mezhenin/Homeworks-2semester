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
            currentNode.TerminalCounter++;
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

        return currentNode.Code;
    }

    /// <summary>
    /// remove element from trie.
    /// </summary>
    /// <param name="element">element to remove.</param>
    /// <returns>true if element was in trie.</returns>
    public bool Remove(List<byte> element)
    {
        if (element.Count == 0)
        {
            return false;
        }

        var currentNode = this.root;
        Stack<(TrieNode, byte)> wayToElement = new();

        foreach (var symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var value))
            {
                return false;
            }

            wayToElement.Push((currentNode, symbol));
            currentNode = value;
        }

        if (!currentNode.IsTerminal)
        {
            return false;
        }

        currentNode.IsTerminal = false;
        --this.Size;

        while (wayToElement.Count > 0)
        {
            var (currentParentNode, currentSymbol) = wayToElement.Pop();
            var nodeToDelete = currentParentNode.Children[currentSymbol];

            nodeToDelete.TerminalCounter--;

            if (!nodeToDelete.IsTerminal && nodeToDelete.Children.Count == 0)
            {
                currentParentNode.Children.Remove(currentSymbol);
            }
        }

        return true;
    }

    /// <summary>
    /// returns how many words in trie stars with prefix.
    /// </summary>
    /// <param name="prefix">prefix to check.</param>
    /// <returns>amount of words start with prefix.</returns>
    public int HowManyStartsWithPrefix(List<byte> prefix)
    {
        if (prefix.Count == 0)
        {
            return this.Size;
        }

        var currentNode = this.root;

        foreach (var symbol in prefix)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var value))
            {
                return 0;
            }

            currentNode = value;
        }

        return currentNode.TerminalCounter;
    }

    private class TrieNode
    {
        public Dictionary<byte, TrieNode> Children { get; set; } = new();

        public bool IsTerminal { get; set; }

        public int TerminalCounter { get; set; }

        public int Code { get; set; } = -1;
    }
}