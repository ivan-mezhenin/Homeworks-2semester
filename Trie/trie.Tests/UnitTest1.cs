using Trie;

public class BorTests
{
    [Test]
    public void BorAddNewWordsShouldReturnTrue()
    {
        var bor = new Bor();

        List<string> words = ["ivan", "iv", "i"];

        foreach (var word in words)
        {
            Assert.That(bor.Add(word), Is.True);
        }
    }

    [Test]
    public void BorAddAlreadyAddedWordShouldReturnFalse()
    {
        var bor = new Bor();

        string word = "Matmeh";

        bor.Add(word);

        Assert.That(bor.Add(word), Is.False);
    }

    [Test]
    public void BorAddWordAfterDeletingShouldReturnTrue()
    {
        var bor = new Bor();

        string word = "test";

        bor.Add(word);

        bor.Remove(word);

        Assert.That(bor.Add(word), Is.True);
    }

    [Test]
    public void BorSizeAfterAddingWords()
    {
        var bor = new Bor();

        List<string> words = ["word", "test", "ivan", "word2"];

        foreach (var word in words) {
            bor.Add(word);
        }

        Assert.That(bor.Size, Is.EqualTo(words.Count));
    }

    [Test]
    public void BorSizeAfterDeleting()
    {
        var bor = new Bor();

        List<string> words = ["word", "test", "ivan", "word2"];

        foreach (var word in words) {
            bor.Add(word);
        }

        bor.Remove(words[0]);
        bor.Remove(words[1]);

        int expextedResult = words.Count - 2;

        Assert.That(bor.Size, Is.EqualTo(expextedResult));
    }

    [Test]
    public void BorSizeOfEmptyBor()
    {
        var bor = new Bor();

        int expextedResult = 0;

        Assert.That(bor.Size, Is.EqualTo(expextedResult));
    }

    [Test]
    public void BorContainsWordAfterAddingShouldReturnTrue()
    {
        var bor = new Bor();

        string word = "computer";

        bor.Add(word);

        Assert.That(bor.Contains(word), Is.True);
    }

    [Test]
    public void BorContainsWordWhichNotAddedShouldReturnFalse()
    {
        var bor = new Bor();

        string word = "test";

        Assert.That(bor.Contains(word), Is.False);
    }

    [Test]
    public void BorContainsWordAfterDeletingShouldReturnFalse()
    {
        var bor = new Bor();

        string word = "english";

        bor.Add(word);

        bor.Remove(word);

        Assert.That(bor.Contains(word), Is.False);
    }

    [Test]
    public void BorRemoveWordAfterAdding()
    {
        var bor = new Bor();

        string word = "vscode";

        bor.Add(word);

        bor.Remove(word);

        Assert.That(bor.Contains(word), Is.False);
    }

    [Test]
    public void BorRemoveWordWhichWasNotAddedShouldReturnFalse()
    {
        var bor = new Bor();

        string word = "fsharp";

        Assert.That(bor.Remove(word), Is.False);
    }

}