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
            if (!currentNode.Children.TryGetValue(symbol, out var value))
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
            if (!currentNode.Children.TryGetValue(symbol, out var value))
            {
                return false;
            }

            currentNode = value;
        }

        return currentNode.IsTerminal;
    }

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

            if (!nodeToDelete.IsTerminal && nodeToDelete.Children.Count == 0)
            {
                currentParentNode.Children.Remove(currentSymbol);
            }
            else
            {
                break;
            }
        }

        return true;
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new ();

        public bool IsTerminal { get; set; }
    }
}