using System;
using System.Linq;

namespace Program
{
    abstract class Program
    {
        static double CalculateProductivity(string[] jobs)
        {
            int[] intervals = new int[jobs.Length - 1];
            int[] durations  = new int[jobs.Length];
            
            durations [0] = Convert.ToInt32(jobs[0].Split('/')[0]) + Convert.ToInt32(jobs[0].Split('/')[1]);

            for (int i = 1; i < jobs.Length; i++)
            {
                string[] parts = jobs[i].Split('/');
                int currentJobEnds = Convert.ToInt32(parts[0]) + Convert.ToInt32(parts[1]);
                
                durations [i] = currentJobEnds;
            }

            Array.Sort(durations);

            for (int i = 0; i < durations .Length - 1; i++)
            {
                intervals[i] = Math.Abs(durations [i] - durations [i + 1]);
            }

            double intervalAverage = intervals.Average();

            return 1 / intervalAverage;
        }

        static void Main()
        {
            string[] jobs = { "0/15", "8/10", "16/7", "21/10", "24/6", "30/4" };
            Console.WriteLine(CalculateProductivity(jobs));
        }
    }
}
