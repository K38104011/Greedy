using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(new[] {'a', 'b', 'c', 'd'}, new[] {10, 1, 1, 1}, new[] {20, 10, 40, 30});
            Test(new[] {'a', 'b', 'c', 'd', 'e' }, new[] {2, 1, 2, 1, 3 }, new[] {100, 19,27, 25, 15});
            Test(new[] {'a', 'b', 'c', 'd' }, new[] {2, 4, 3, 1}, new[] {60, 100, 20, 20});
            Console.ReadKey();
        }

        private static void Test(char[] jobIds, int[] deadlines, int[] profits)
        {
            var jq = new JobSequence(jobIds, deadlines, profits);
            Console.WriteLine(string.Join(", ", jq.GetBestProfit()));
        }
    }

    class Job
    {
        public char JobId { get; set; }
        public int Deadline { get; set; }
        public int Profit { get; set; }
        public override string ToString()
        {
            return JobId.ToString();
        }
    }

    class JobSequence
    {
        

        private readonly Job[] _jobs;

        public JobSequence(char[] jobIds, int[] deadlines, int[] profits)
        {
            _jobs = new Job[jobIds.Length];
            for (var index = 0; index < jobIds.Length; index++)
            {
                _jobs[index] = new Job
                {
                    JobId = jobIds[index],
                    Deadline = deadlines[index],
                    Profit = profits[index]
                };
            }
        }

        public ICollection<Job> GetBestProfit()
        {
            var result = new Job[new [] {_jobs.Length, _jobs.Max(job => job.Deadline)}
                                        .Max(value => value)];
            var sorted = _jobs.OrderByDescending(item => item.Profit);
            foreach (var job in sorted)
            {
                while (job.Deadline - 1 >= 0)
                {
                    if (result[job.Deadline - 1] == null)
                    {
                        result[job.Deadline - 1] = job;
                        break;
                    }
                    job.Deadline -= 1;
                }
            }
            return result.Where(job => job != null).ToList();
        }
    }
}
