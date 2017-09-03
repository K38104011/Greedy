using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace BinarySearch
{
    public class BinarySearch
    {
        private readonly IList<int> _list;

        public BinarySearch(IList<int> list)
        {
            _list = list;
        }

        public int Search(int value)
        {
            var foundedIndex = Search(value, 0, _list.Count - 1);
            return foundedIndex;
        }

        private int Search(int searchValue, int leftIndex, int rightIndex)
        {
            var middleIndex = (leftIndex + rightIndex) / 2;
            if (_list[middleIndex] == searchValue)
            {
                return middleIndex;
            }
            if (_list[middleIndex] > searchValue)
            {
                return Search(searchValue, leftIndex, middleIndex);
            }
            if (_list[middleIndex] < searchValue)
            {
                return Search(searchValue, middleIndex + 1, rightIndex);
            }
            return -1;
        }

    }
}
