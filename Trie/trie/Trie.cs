namespace Trie;

using System.Linq.Expressions;

/// <summary>
/// realization of Bor.
/// </summary>
public class Bor
{
    private TrieNode root = new ();

    public int Size { get; private set; }

    public bool Add(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;

        foreach (char symbol in element)
        {
            if (!currentNode.Children.ContainsKey(symbol))
            {
                currentNode.Children[symbol] = new TrieNode();
            }

            currentNode = currentNode.Children[symbol];
        }

        if (currentNode.IsTerminal)
        {
            return true;
        }

        currentNode.IsTerminal = true;
        this.Size++;

        return false;
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new ();
        public bool IsTerminal;
    }
}