using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new MyMergeSort(new []{38, 27, 43, 3, 9, 82, 10});
            ms.Sort();
            Console.WriteLine(string.Join(", ", ms.GetResult));
            var ms2 = new MyMergeSort(new[] {38, 27, 43, 3, 9, 82, 10});
            ms2.Sort2();
            Console.WriteLine(string.Join(", ", ms2.GetResult));
            Console.ReadKey();
        }
    }
}
