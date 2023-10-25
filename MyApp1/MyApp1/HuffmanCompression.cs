using System.Collections.Generic;
using System.IO;
using System.Linq;

public class HuffmanCompression
{
    public class HuffmanNode
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public HuffmanNode(char character, int frequency)
        {
            Character = character;
            Frequency = frequency;
        }

        public HuffmanNode(HuffmanNode left, HuffmanNode right)
        {
            Left = left;
            Right = right;
            Frequency = left.Frequency + right.Frequency;
        }

        public bool IsLeaf => Left == null && Right == null;
    }

    public class HuffmanTree
    {
        public HuffmanNode Root { get; set; }

        public HuffmanTree(HuffmanNode root)
        {
            Root = root;
        }

        public Dictionary<char, string> BuildEncodingTable()
        {
            Dictionary<char, string> encodingTable = new Dictionary<char, string>();
            TraverseTreeForEncoding(Root, "", encodingTable);
            return encodingTable;
        }

        private void TraverseTreeForEncoding(HuffmanNode node, string currentCode, Dictionary<char, string> encodingTable)
        {
            if (node.IsLeaf)
            {
                encodingTable[node.Character] = currentCode;
            }
            else
            {
                if (node.Left != null)
                {
                    TraverseTreeForEncoding(node.Left, currentCode + "0", encodingTable);
                }
                if (node.Right != null)
                {
                    TraverseTreeForEncoding(node.Right, currentCode + "1", encodingTable);
                }
            }
        }

        public byte[] ToBinary()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                WriteTreeToStream(Root, writer);
                long currentPosition = stream.Position;
                writer.Write(0);
                stream.Seek(0, SeekOrigin.End);
                int actualSize = (int)(stream.Length - currentPosition);
                stream.Seek(currentPosition - 4, SeekOrigin.Begin);
                writer.Write(actualSize);
                stream.Seek(0, SeekOrigin.End);
                return stream.ToArray();
            }
        }

        public static HuffmanTree FromBinary(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                int temporarySize = reader.ReadInt32();
                byte[] actualData = reader.ReadBytes(temporarySize);

                using (MemoryStream dataStream = new MemoryStream(actualData))
                using (BinaryReader dataReader = new BinaryReader(dataStream))
                {
                    HuffmanNode root = ReadTreeFromStream(dataReader);
                    return new HuffmanTree(root);
                }
            }
        }

        private void WriteTreeToStream(HuffmanNode node, BinaryWriter writer)
        {
            if (node.IsLeaf)
            {
                writer.Write(true);
                writer.Write(node.Character);
            }
            else
            {
                writer.Write(false);
                WriteTreeToStream(node.Left, writer);
                WriteTreeToStream(node.Right, writer);
            }
        }

        private static HuffmanNode ReadTreeFromStream(BinaryReader reader)
        {
            if (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                bool isLeaf = reader.ReadBoolean();
                if (isLeaf)
                {
                    char character = reader.ReadChar();
                    return new HuffmanNode(character, 0);
                }
                else
                {
                    HuffmanNode left = ReadTreeFromStream(reader);
                    HuffmanNode right = ReadTreeFromStream(reader);
                    return new HuffmanNode(left, right);
                }
            }
            return null;
        }

        public const int BinarySize = 4;
    }

    public static void Compress(string inputFilePath, string outputFilePath)
    {
        string inputText = File.ReadAllText(inputFilePath);
        HuffmanTree tree = BuildHuffmanTree(inputText);
        Dictionary<char, string> encodingTable = tree.BuildEncodingTable();

        using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            byte[] binaryTree = tree.ToBinary();

            writer.Write(binaryTree);
        }
    }

    private static HuffmanTree BuildHuffmanTree(string text)
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

        List<HuffmanNode> nodes = frequencies.Select(kv => new HuffmanNode(kv.Key, kv.Value)).ToList();
        while (nodes.Count > 1)
        {
            nodes = nodes.OrderBy(node => node.Frequency).ToList();
            HuffmanNode parent = new HuffmanNode(nodes[0], nodes[1]);
            nodes.RemoveAt(0);
            nodes.RemoveAt(0);
            nodes.Add(parent);
        }

        return new HuffmanTree(nodes[0]);
    }
}
