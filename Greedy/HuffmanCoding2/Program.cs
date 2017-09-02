using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding2
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanCoding2 hc = new HuffmanCoding2(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, new[] { 5, 9, 12, 13, 16, 45 });
            hc.Compress();
            var result = hc.GetCodes();
            foreach (var r in result)
            {
                Console.WriteLine(r.Key + ":" + r.Value);
            }
            Console.ReadKey();
        }

        class HuffmanCoding2
        {
            private readonly char[] _characters;
            private readonly int[] _frequencies;
            private readonly MyQueue _queue1;
            private readonly MyQueue _queue2;
            private readonly Node[] _sorted;
            private Node _root;
            private readonly Dictionary<char, string> _result;

            public HuffmanCoding2(char[] characters, int[] frequencies)
            {
                _characters = characters;
                _frequencies = frequencies;
                _queue1 = new MyQueue(_characters.Length);
                _queue2 = new MyQueue(_characters.Length);
                _sorted = new Node[_characters.Length];
                _result = new Dictionary<char, string>();
                for (var i = 0; i < _characters.Length; i++)
                {
                    _sorted[i] = new Node(_frequencies[i], _characters[i]);
                }
                _sorted = _sorted.OrderBy(node => node.Key).ToArray();
            }

            public void Compress()
            {
                BuildHuffmanTree();;
            }

            private void BuildHuffmanTree()
            {
                for (var i = 0; i < _sorted.Length; i++)
                {
                    var node = new Node(_frequencies[i], _characters[i]);
                    _queue1.Enqueue(node);
                }
                while (_queue1.Size() != 0)
                {
                    var min1 = GetMin();
                    var min2 = GetMin();
                    var node = new Node(min1.Key + min2.Key, null)
                    {
                        LeftChild = min1,
                        RightChild = min2
                    };
                    _queue2.Enqueue(node);
                }
                _root = (Node) _queue2.Dequeue();
            }

            private Node GetMin()
            {
                if (_queue2.Size() == 0)
                {
                    return (Node)_queue1.Dequeue();
                }
                if (_queue1.Size() == 0)
                {
                    return (Node) _queue2.Dequeue();
                }
                var minQ1 = (Node) _queue1.Rear();
                var minQ2 = (Node) _queue2.Rear();
                var min = new[] { minQ1, minQ2 }.OrderBy(node => node.Key).First();
                return min.Key == minQ1.Key && min.Data == minQ1.Data ? (Node) _queue1.Dequeue() : (Node) _queue2.Dequeue();
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
        }
    }
}
