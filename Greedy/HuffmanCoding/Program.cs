using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanCoding hc = new HuffmanCoding(new []{'a', 'b', 'c', 'd', 'e', 'f'}, new []{5, 9, 12, 13, 16, 45});
            hc.Compress();
            var result = hc.GetCodes();
            foreach (var r in result)
            {
                Console.WriteLine(r.Key + ":" + r.Value);
            }
            Console.ReadKey();
        }
    }

    class HuffmanCoding
    {
        private readonly char[] _characters;
        private readonly int[] _frequencies;
        private readonly Dictionary<char, string> _result;
        private Node _root;

        public HuffmanCoding(char[] characters, int[] frequencies)
        {
            _characters = characters;
            _frequencies = frequencies;
            _result = new Dictionary<char, string>();
        }

        public void Compress()
        {
            _root = BuildHuffmanTree().GetRoot();
        }

        public Dictionary<char, string> GetCodes()
        {
            var code = string.Empty;
            BuildCodes(_root, code);
            return _result;
        }

        private void BuildCodes(Node node, string code)
        {
            if (node.LeftChild != null)
            {
                code += "0";
                if (node.LeftChild.Data != null)
                {
                    _result.Add((char)node.LeftChild.Data, code);
                }
                BuildCodes(node.LeftChild, code);
            }
            code = code.Substring(0, code.Length - 1);
            if (node.RightChild != null)
            {
                code += "1";
                if (node.RightChild.Data != null)
                {
                    _result.Add((char)node.RightChild.Data, code);
                }
                BuildCodes(node.RightChild, code);
            }

        }

        private MyHeapBinaryTree BuildHuffmanTree()
        {
            var tree = BuildHeapTree();
            if (tree.GetSize() <= 1)
            {
                return tree;
            }
            do
            {
                var min1 = tree.ExtractMin();
                var min2 = tree.ExtractMin();
                var node = new Node(min1.Key + min2.Key, null)
                {
                    LeftChild = min1,
                    RightChild = min2
                };
                tree.Insert(node);
            } while (tree.GetSize() > 1);
            return tree;
        }

        private MyHeapBinaryTree BuildHeapTree()
        {
            var tree = new MyHeapBinaryTree();
            for (var i = 0; i < _characters.Length; i++)
            {
                tree.Insert(_frequencies[i], _characters[i]);
            }
            return tree;
        }
    }
}
