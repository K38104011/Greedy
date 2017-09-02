using System;
using System.Linq;

namespace HuffmanCoding2
{
    public class Node
    {
        public int Key { get; }
        public object Data { get; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int key, object data)
        {
            Key = key;
            Data = data;
        }

        public override string ToString()
        {
            return Key + ":" + Data;
        }
    }

    public class MyQueue
    {
        private int _front;
        private int _rear;
        private int _size;
        private readonly int _buffer;
        private object[] _data;

        public MyQueue(int buffer)
        {
            _size = 0;
            _front = -1;
            _rear = -1;
            _data = new object[buffer];
            _buffer = buffer;
        }

        public void Enqueue(object o)
        {
            _size++;
            _front = 0;
            if (_rear + 1 > _buffer - 1)
            {
                throw new OverflowException("My queue is full");
            }
            _data[++_rear] = o;
        }

        public object Front()
        {
            object o = null;
            if (_front > -1)
            {
                o = _data[_front];
            }
            return o;
        }

        public object Rear()
        {
            object o = null;
            if (_rear > -1)
            {
                o = _data[_rear];
            }
            return o;
        }

        public object Dequeue()
        {
            object o = null;
            if (_data.Length > 0)
            {
                o = _data[_front];
                object[] temp = new object[_buffer];
                Array.Copy(_data, 1, temp, 0, _data.Length - 1);
                _data = temp;
                _rear--;
                _size--;
            }
            return o;
        }

        public int Size()
        {
            return _size;
        }

        public void Traverse()
        {
            Traverse(_data);
        }

        private void Traverse(object[] data)
        {
            string s = string.Join(", ", data.Take(_size));
            Console.WriteLine(s);
        }
    }
}
