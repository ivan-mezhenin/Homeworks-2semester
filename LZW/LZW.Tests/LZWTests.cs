using System.Text;
using LZW;

namespace LZW.Tests;

public class Tests
{
    [Test]
    public void LZWEncode_Encode_NormalArrayOfBytes()
    {
        var testData = new byte[256];
        var expectedResult = new int[256];
        for (var i = 0; i < 256; ++i)
        {
            testData[i] = ((byte)i);
            expectedResult[i] = i;
        }

        int[] codes = LZW.LZWEncode.Encode(testData);

        Assert.That(codes, Is.EqualTo(expectedResult));
    }

    [Test]
    public void LZWEncode_Encode_ArrayOfRepeatingBytes()
    {
        byte[] testData = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbb");
        int[] expectedResult = { 97, 256, 257, 258, 259, 260, 260, 98, 263, 264, 265, 264 };

        int[] codes = LZW.LZWEncode.Encode(testData);

        Assert.That(codes, Is.EqualTo(expectedResult));
    }

    [Test]
    public void LZWEncode_Encode_()
    {
        int[] sequence = { 97, 98 };
        byte[] expected = { 48, 152, 128 };

        Assert.That(LZW.LZWEncode.Encode(sequence), Is.EqualTo(expected));
    }

    [Test]
    public void LZW_DataAfterCompressAndDecompress_ShouldEqual()   
    {
        byte[] testData = Encoding.ASCII.GetBytes("fsjgnfisgns ihnxwueihx8behremx0rgmwgwzemg");

        int[] codes = LZW.LZWEncode.Encode(testData);
        byte[] compressedData = LZW.LZWEncode.TransformIntArrayToByteSequence(codes);

        int[] codesAfterCompress = LZW.LZWDecode.TransformByteSequenceToIntArray(compressedData);
        byte[] decompressData = LZW.LZWDecode.Decode(codesAfterCompress);

        Assert.That(testData, Is.EqualTo(decompressData));
    }

    [Test]
    public void LZWEncode_TransformIntArrayToByteSequence_ArrayOfBytes()
    {
        int[] testData = [54252, 101513, 11515, 24353, 32251, 1214, 1513, 13419];
        byte[] expectedResult = [236, 167, 3, 137, 153, 6, 251, 89, 161, 190, 1, 251, 251, 1, 190, 9, 233, 11, 235, 104];

        byte[] transformedData = LZW.LZWEncode.TransformIntArrayToByteSequence(testData);

        Assert.That(transformedData, Is.EqualTo(expectedResult));
    }

    [Test]
    public void LZWDecode_TransformByteSequenceToIntArray_IntArray()
    {
        byte[] testData = [236, 167, 3, 137, 153, 6, 251, 89, 161, 190, 1, 251, 251, 1, 190, 9, 233, 11, 235, 104];
        int[] expectedResult = [54252, 101513, 11515, 24353, 32251, 1214, 1513, 13419];
        

        int[] transformedData = LZW.LZWDecode.TransformByteSequenceToIntArray(testData);

        Assert.That(transformedData, Is.EqualTo(expectedResult));
    }
}


