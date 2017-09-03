using System.Linq;

namespace MergeSort
{
    public class MyMergeSort
    {
        private readonly int[] _array;

        public int[] GetResult
        {
            get { return (int[])_array.Clone(); }
        }

        public MyMergeSort(int[] array)
        {
            _array = array;
        }

        public void Sort()
        {
            MergeSort(_array, 0, _array.Length - 1);
        }

        public void Sort2()
        {
            MergeSort2(_array, 0, _array.Length - 1);
        }

        private void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            var middleIndex = (leftIndex + rightIndex) / 2;
            if (middleIndex != leftIndex || leftIndex != rightIndex)
            {
                MergeSort(array, leftIndex, middleIndex);
                MergeSort(array, middleIndex + 1, rightIndex);
            }
            merge(array, leftIndex, rightIndex);
        }

        private void MergeSort2(int[] array, int leftIndex, int rightIndex)
        {
            var middleIndex = (leftIndex + rightIndex) / 2;
            if (middleIndex != leftIndex || leftIndex != rightIndex)
            {
                MergeSort2(array, leftIndex, middleIndex);
                MergeSort2(array, middleIndex + 1, rightIndex);
            }
            merge2(array, leftIndex, middleIndex, rightIndex);
        }

        private void merge(int[] array, int leftIndex, int rightIndex)
        {
            var sortedArray = new int[rightIndex - leftIndex + 1];
            var sortedIndex = 0;
            for (var i = leftIndex; i <= rightIndex; i++)
            {
                sortedArray[sortedIndex++] = array[i];
            }
            sortedArray = sortedArray.OrderBy(value => value).ToArray();
            sortedIndex = 0;
            for (var i = leftIndex; i <= rightIndex; i++)
            {
                array[i] = sortedArray[sortedIndex++];
            }
        }

        private void merge2(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            var leftArray = new int[middleIndex - leftIndex + 1];
            var rightArray = new int[rightIndex - (middleIndex + 1) + 1];

            var leftArrayIndex = 0;
            for (var index = leftIndex; index <= middleIndex; index++)
            {
                leftArray[leftArrayIndex++] = array[index];
            }

            var rightArrayIndex = 0;
            for (var index = middleIndex + 1; index <= rightIndex; index++)
            {
                rightArray[rightArrayIndex++] = array[index];
            }

            leftArrayIndex = rightArrayIndex = 0;
            var sortIndex = leftIndex;
            if (leftArray.Length > 0 && rightArray.Length > 0)
            {
                while (true)
                {
                    if (leftArray[leftArrayIndex] <= rightArray[rightArrayIndex])
                    {
                        array[sortIndex++] = leftArray[leftArrayIndex++];
                        if (leftArrayIndex >= leftArray.Length)
                        {
                            break;
                        }
                    }
                    else
                    {
                        array[sortIndex++] = rightArray[rightArrayIndex++];
                        if (rightArrayIndex >= rightArray.Length)
                        {
                            break;
                        }
                    }
                }
            }

            if (leftArrayIndex < leftArray.Length)
            {
                array[sortIndex++] = leftArray[leftArrayIndex++];
            }
            if (rightArrayIndex < rightArray.Length)
            {
                array[sortIndex++] = rightArray[rightArrayIndex++];
            }
        }
    }
}
