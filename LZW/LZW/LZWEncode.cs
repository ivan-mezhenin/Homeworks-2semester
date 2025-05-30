// <copyright file="LZWEncode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

/// <summary>
/// to encode file.
/// </summary>
public class LZWEncode
{
    /// <summary>
    /// to compress file.
    /// </summary>
    /// <param name="filePath">file to compress.</param>
    /// <returns>compression ratio.</returns>
    public static float Compress(string filePath)
    {
        var data = File.ReadAllBytes(filePath);
        var fileLength = data.Length;

        var codes = Encode(data);

        var compressedData = TransformIntArrayToByteSequence(codes);
        var compressedFileLength = compressedData.Length;

        var compressedFilePath = filePath + ".zipped";
        File.WriteAllBytes(compressedFilePath, compressedData);

        return (float)fileLength / compressedFileLength;
    }

    /// <summary>
    /// to encode file.
    /// </summary>
    /// <param name="data">file to encode.</param>
    /// <returns>int array of codes.</returns>
    public static int[] Encode(byte[] data)
    {
        var trie = Trie.Initialization();
        var counter = trie.Size;

        List<byte> currentByteSequence = [data[0]];
        List<int> encodedString = [];

        for (var i = 1; i < data.Length; ++i)
        {
            var nextByte = data[i];
            List<byte> combined = [.. currentByteSequence, nextByte];

            if (trie.Contains(combined) != -1)
            {
                currentByteSequence = combined;
            }
            else
            {
                encodedString.Add(trie.Contains(currentByteSequence));

                trie.Add(combined, counter);
                ++counter;

                currentByteSequence = [nextByte];
            }
        }

        encodedString.Add(trie.Contains(currentByteSequence));

        return encodedString.ToArray();
    }

    /// <summary>
    /// transform int array to byte array.
    /// </summary>
    /// <param name="encodedString">string to transform.</param>
    /// <returns>byte array.</returns>
    public static byte[] TransformIntArrayToByteSequence(int[] encodedString)
    {
        List<byte> result = [];

        foreach (var symbol in encodedString)
        {
            long value = symbol;
            while (value != 0)
            {
                var byteValue = (byte)(value & 127);
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