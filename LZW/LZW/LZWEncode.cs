namespace LZW;

/// <summary>
/// to encode file.
/// </summary>
public class LZWEncode
{
    /// <summary>
    /// to compress file.
    /// </summary>
    /// <param name="file">file path.</param>
    /// <returns>int array of codes.</returns>
    public static int[] Compress(string file)
    {
        Trie trie = Trie.Initialization();
        byte[] fileContent = File.ReadAllBytes(file);
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

                currentString = [nextByte];
            }
        }

        encodedString.Add(trie.Contains(currentString));

        return encodedString.ToArray();
    }

    /// <summary>
    /// transform int array to byte array.
    /// </summary>
    /// <param name="encodedString">string to transform.</param>
    /// <returns>byte array.</returns>
    public static byte[] TransformIntArrayToByteArray(int[] encodedString)
    {
        List<byte> result = [];

        foreach (var symbol in encodedString)
        {
            int value = symbol;
            while (value != 0)
            {
                byte byteValue = (byte)(value & 127);
                value >>= 7;
                if (value != 0)
                {
                    byteValue |= 128;
                }

                result.Add(byteValue);
            }
        }

        return result.ToArray();
    }
}