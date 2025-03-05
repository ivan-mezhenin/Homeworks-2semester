namespace Trie;

using System.ComponentModel;
using System.Linq.Expressions;

/// <summary>
/// realization of Bor.
/// </summary>
public class Bor
{
    private readonly TrieNode root = new ();

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
            if (!currentNode.Children.TryGetValue(symbol, out TrieNode? value))
            {
                value = new TrieNode();
                currentNode.Children[symbol] = value;
            }

            currentNode = value;
        }

        if (currentNode.IsTerminal)
        {
            return true;
        }

        currentNode.IsTerminal = true;
        this.Size++;

        return false;
    }

    public bool Contains(string element)
    {
        if (string.IsNullOrEmpty(element))
        {
            return false;
        }

        var currentNode = this.root;

        foreach (char symbol in element)
        {
            if (!currentNode.Children.TryGetValue(symbol, out TrieNode? value))
            {
                return false;
            }

            currentNode = value;
        }

        return currentNode.IsTerminal;
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new ();

        public bool IsTerminal { get; set; }
    }
}