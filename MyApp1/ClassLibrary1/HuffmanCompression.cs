using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class HuffmanCompression
{
    public static void CompressTextFile(string filePath, string compressedFilePath)
    {
        try
        {
            string text = File.ReadAllText(filePath);
            Dictionary<char, int> frequencies = CalculateFrequencies(text);
            HuffmanTree huffmanTree = new HuffmanTree(frequencies);
            Dictionary<char, string> huffmanCodes = huffmanTree.BuildHuffmanCodes();
            string compressedText = EncodeTextWithHuffman(text, huffmanCodes);
            WriteCompressedTextToFile(compressedFilePath, compressedText);

            Console.WriteLine("Text has been compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during text compression: " + ex.Message);
        }
    }

    public static void DecompressTextFile(string compressedFilePath, string decompressedFilePath)
    {
        try
        {
            string compressedText = File.ReadAllText(compressedFilePath);
            // You should have the reverse HuffmanCodes here
            // Dictionary<string, char> reverseHuffmanCodes = ...
            string decompressedText = DecodeTextWithHuffman(compressedText, reverseHuffmanCodes);
            WriteDecompressedTextToFile(decompressedFilePath, decompressedText);

            Console.WriteLine("Text has been decompressed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during text decompression: " + ex.Message);
        }
    }

    public static Dictionary<char, int> CalculateFrequencies(string text)
    {
        Dictionary<char, int> frequencies = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (frequencies.ContainsKey(c))
            {
                frequencies[c]++;
            }
            else
            {
                frequencies[c] = 1;
            }
        }
        return frequencies;
    }

    public static string EncodeTextWithHuffman(string text, Dictionary<char, string> huffmanCodes)
    {
        StringBuilder encodedText = new StringBuilder();
        foreach (char c in text)
        {
            if (huffmanCodes.ContainsKey(c))
            {
                encodedText.Append(huffmanCodes[c]);
            }
        }
        return encodedText.ToString();
    }

    public static string DecodeTextWithHuffman(string encodedText, Dictionary<string, char> reverseHuffmanCodes)
    {
        StringBuilder decodedText = new StringBuilder();
        string currentCode = "";
        foreach (char bit in encodedText)
        {
            currentCode += bit;
            if (reverseHuffmanCodes.ContainsKey(currentCode))
            {
                decodedText.Append(reverseHuffmanCodes[currentCode]);
                currentCode = "";
            }
        }

        return decodedText.ToString();
    }

    public static void WriteCompressedTextToFile(string filePath, string compressedText)
    {
        File.WriteAllText(filePath, compressedText);
    }

    public static void WriteDecompressedTextToFile(string filePath, string decompressedText)
    {
        File.WriteAllText(filePath, decompressedText);
    }
}

