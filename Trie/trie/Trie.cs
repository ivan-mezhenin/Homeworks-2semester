namespace Trie;

/// <summary>
/// realization of Bor.
/// </summary>
public class Bor
{
    private readonly TrieNode root = new ();

    /// <summary>
    /// Gets amount of added words in Trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// add new word in Trie.
    /// </summary>
    /// <param name="element">element to add.</param>
    /// <returns>false if word already added.</returns>
    public bool Add(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;

        foreach (char symbol in element)
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
        this.Size++;

        return true;
    }

    /// <summary>
    /// check is trie contains element.
    /// </summary>
    /// <param name="element">element to check.</param>
    /// <returns>true if trie contains element.</returns>
    public bool Contains(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;

        foreach (char symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var value))
            {
                return false;
            }

            currentNode = value;
        }

        return currentNode.IsTerminal;
    }

    /// <summary>
    /// remove element from trie.
    /// </summary>
    /// <param name="element">element to remove.</param>
    /// <returns>true if element was in trie.</returns>
    public bool Remove(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;
        Stack<(TrieNode, char)> wayToElement = new ();

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
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
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
        public Dictionary<char, TrieNode> Children { get; set; } = new ();

        public bool IsTerminal { get; set; }

        public int TerminalCounter { get; set; }
    }
}