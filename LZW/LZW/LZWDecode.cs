namespace LZW;

/// <summary>
/// to decode file.
/// </summary>
public class LZWDecode
{
    /// <summary>
    /// to decompress file.
    /// </summary>
    /// <param name="filePath">file to decompress.</param>
    public static void Decompress(string filePath)
    {
        byte[] data = File.ReadAllBytes(filePath);
        int[] codes = TransformByteSequenceToIntArray(data);
        byte[] decompressedData = Decode(codes);

        string decompressedFilePath = filePath[..^7];
        File.WriteAllBytes(decompressedFilePath, decompressedData);
    }

    /// <summary>
    /// to decode data.
    /// </summary>
    /// <param name="encodedData">data to encode.</param>
    /// <returns>sourseByteSequence.</returns>
    public static byte[] Decode(int[] encodedData)
    {
        Dictionary<int, List<byte>> codes = new();
        List<byte> output = new();
        int counter = 256;

        for (int i = 0; i < 256; i++)
        {
            codes[i] = [(byte)i];
        }

        int prevCode = encodedData[0];
        output.AddRange(codes[prevCode]);

        for (int i = 1; i < encodedData.Length; i++)
        {
            int currentCode = encodedData[i];
            List<byte> currentSequence = new();

            if (currentCode == counter)
            {
                currentSequence = [.. codes[prevCode], codes[prevCode][0]];
            }
            else if (codes.TryGetValue(currentCode, out List<byte>? value))
            {
                currentSequence = [.. value];
            }

            output.AddRange(currentSequence);

            List<byte> newEntry = [.. codes[prevCode], currentSequence[0]];
            codes[counter] = newEntry;

            counter++;
            prevCode = currentCode;
        }

        return output.ToArray();
    }

    /// <summary>
    /// to transform byte sequence to array of codes.
    /// </summary>
    /// <param name="byteSequence">byte sequence to transform.</param>
    /// <returns>int array of codes.</returns>
    public static int[] TransformByteSequenceToIntArray(byte[] byteSequence)
    {
        List<int> result = new();
        int number = 0;
        int shift = 0;

        foreach (var symbol in byteSequence)
        {
            number |= (symbol & 127) << shift;

            if ((symbol & 128) == 0)
            {
                result.Add(number);
                number = 0;
                shift = 0;
            }
            else
            {
                shift += 7;
            }
        }

        return result.ToArray();
    }
}