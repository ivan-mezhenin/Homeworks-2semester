// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using LZW;

Console.WriteLine("LZW. Write dotnet run -- FilePath -c/-u. -c - if you want to compress file, -u - to decompress");

if (string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]) || args.Length < 2)
{
    Console.WriteLine("Error when passing arguments");
    return;
}

switch (args[1])
{
    case "-c":
    {
        var compressionRatio = LZW.LZWEncode.Compress(args[0]);
        Console.WriteLine("Compression ratio: " + compressionRatio);
        break;
    }

    case "-u":
    {
        LZW.LZWDecode.Decompress(args[0]);
        break;
    }

    default:
    {
        Console.WriteLine("Incorrect symbol");
        break;
    }
}