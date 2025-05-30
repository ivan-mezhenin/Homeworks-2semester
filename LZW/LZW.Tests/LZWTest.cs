// <copyright file="LZWTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW.Tests;

using System.Text;
using LZW;

/// <summary>
/// test for LZW.
/// </summary>
public class LZWTest
{
    /// <summary>
    /// test for correct encoding array of bytes.
    /// </summary>
    [Test]
    public void LZWEncode_Encode_NormalArrayOfBytes()
    {
        var testData = new byte[256];
        var expectedResult = new int[256];
        for (var i = 0; i < 256; ++i)
        {
            testData[i] = (byte)i;
            expectedResult[i] = i;
        }

        var codes = LZW.LZWEncode.Encode(testData);

        Assert.That(codes, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test for correct encoding array of repeating bytes.
    /// </summary>
    [Test]
    public void LZWEncode_Encode_ArrayOfRepeatingBytes()
    {
        var testData = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbb");
        int[] expectedResult = [97, 256, 257, 258, 259, 260, 260, 98, 263, 264, 265, 264];
        var codes = LZW.LZWEncode.Encode(testData);

        Assert.That(codes, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test that data equal after compress and decompress.
    /// </summary>
    [Test]
    public void LZW_DataAfterCompressAndDecompress_ShouldEqual()
    {
        var testData = Encoding.ASCII.GetBytes("fsjgnfisgns ihnxwueihx8behremx0rgmwgwzemg");

        var codes = LZW.LZWEncode.Encode(testData);
        var compressedData = LZW.LZWEncode.TransformIntArrayToByteSequence(codes);

        var codesAfterCompress = LZW.LZWDecode.TransformByteSequenceToIntArray(compressedData);
        var decompressData = LZW.LZWDecode.Decode(codesAfterCompress);

        Assert.That(testData, Is.EqualTo(decompressData));
    }

    /// <summary>
    /// test for correct transform int array to byte sequence.
    /// </summary>
    [Test]
    public void LZWEncode_TransformIntArrayToByteSequence_ArrayOfBytes()
    {
        int[] testData = [54252, 101513, 11515, 24353, 32251, 1214, 1513, 13419];
        byte[] expectedResult = [236, 167, 3, 137, 153, 6, 251, 89, 161, 190, 1, 251, 251, 1, 190, 9, 233, 11, 235, 104];

        var transformedData = LZW.LZWEncode.TransformIntArrayToByteSequence(testData);

        Assert.That(transformedData, Is.EqualTo(expectedResult));
    }

    /// <summary>
    /// test for correct byte sequence to int array.
    /// </summary>
    [Test]
    public void LZWDecode_TransformByteSequenceToIntArray_IntArray()
    {
        byte[] testData = [236, 167, 3, 137, 153, 6, 251, 89, 161, 190, 1, 251, 251, 1, 190, 9, 233, 11, 235, 104];
        int[] expectedResult = [54252, 101513, 11515, 24353, 32251, 1214, 1513, 13419];

        var transformedData = LZW.LZWDecode.TransformByteSequenceToIntArray(testData);

        Assert.That(transformedData, Is.EqualTo(expectedResult));
    }
}