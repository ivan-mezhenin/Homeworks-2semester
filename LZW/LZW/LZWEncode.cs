namespace LZW;

/// <summary>
/// encode file.
/// </summary>
public class LZWEncode
{
    public static void Encode(string file)
    {
        Trie trie = Trie.Initialization();
        byte[] fileContent = File.ReadAllBytes(file);
        int len1 = fileContent.Length;
        int len2;
        int counter = trie.Size;

        List<byte> currentString = [fileContent[0]];
        List<int> encodedString = [];

        for (var i = 1; i < fileContent.Length; ++i)
        {
            byte nextByte = fileContent[i];
            List<byte> combined = [.. currentString, nextByte];

            if (trie.Contains(combined) != -1)
            {
                currentString = combined;
            }
            else
            {
                encodedString.Add(trie.Contains(currentString));

                trie.Add(combined, counter);
                ++counter;

                currentString = new List<byte> { nextByte };
            }
        }

        encodedString.Add(trie.Contains(currentString));

        len2 = encodedString.Count;
        Console.WriteLine($"{len1} {len2} {(float)len1 / len2}");

    }
}
