// <copyright file="LZWDecode.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

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
        var data = File.ReadAllBytes(filePath);
        var codes = TransformByteSequenceToIntArray(data);
        var decompressedData = Decode(codes);

        var decompressedFilePath = filePath[..^7];
        File.WriteAllBytes(decompressedFilePath, decompressedData);
    }

    /// <summary>
    /// to decode data.
    /// </summary>
    /// <param name="encodedData">data to encode.</param>
    /// <returns>source byte sequence.</returns>
    public static byte[] Decode(int[] encodedData)
    {
        Dictionary<int, List<byte>> codes = new();
        List<byte> output = [];
        var counter = 256;

        for (var i = 0; i < 256; i++)
        {
            codes[i] = [(byte)i];
        }

        var prevCode = encodedData[0];
        output.AddRange(codes[prevCode]);

        for (var i = 1; i < encodedData.Length; i++)
        {
            var currentCode = encodedData[i];
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
        List<int> result = [];
        var number = 0;
        var shift = 0;

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