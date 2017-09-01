using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitySelection
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivitySelection asl = new ActivitySelection(new []{ 1, 3, 0, 5, 8, 5 }, new []{ 2, 4, 6, 7, 9, 9 });
            asl.Compute();
            asl.Compute2();
            ActivitySelection asl2 = new ActivitySelection(new []{ 10, 12, 20 }, new []{ 20, 25, 30 });
            asl2.Compute();
            asl2.Compute();
            Console.ReadKey();
        }

        class ActivitySelection
        {
            private readonly int[] _start;
            private readonly int[] _finish;

            public ActivitySelection(int[] start, int[] finish)
            {
                _start = start;
                _finish = finish;
            }

            public void Compute()
            {
                var sorted = _finish.Select((value, index) => new
                    {
                        Start = _start[index],
                        Finish = value,
                        Index = index
                    })
                    .OrderBy(item => item.Finish)
                    .ToList();
                var previous = sorted.First().Index;
                Console.Write(previous);

                for (var i = 1; i < sorted.Count; i++)
                {
                    if (sorted[i].Start >= sorted[previous].Finish)
                    {
                        Console.Write(i);
                        previous = i;
                    }
                }
                Console.WriteLine();
            }

            public void Compute2()
            {
                var previous = 0;
                Console.Write(previous);
                for (var i = 1; i < _finish.Length; i++)
                {
                    if (_start[i] >= _finish[previous])
                    {
                        Console.Write(i);
                        previous = i;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
