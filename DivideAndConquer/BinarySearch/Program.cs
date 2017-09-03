using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var bs = new BinarySearch(new[] {2, 5, 8, 12, 16, 23, 38, 56, 72, 91});
            Console.WriteLine(bs.Search(23));
            Console.ReadKey();
        }


    }
}
