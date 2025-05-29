// <copyright file="Program.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

using LZW;

Console.WriteLine("LZW. Write FilePath -c/-u. -c - if you want to compress file, -u - to decompress");

switch (args[1])
{
    case "-c":
    {
        LZW.LZWEncode.Compress(args[0]);
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