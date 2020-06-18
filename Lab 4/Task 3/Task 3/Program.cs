using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            tests new_tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            string[] input;
            short N, M;
            HashSet<HashSet<int>> sets;
            while (!input_stream.EndOfStream)
            {


                double starting_memory = Process.GetCurrentProcess().WorkingSet64 / 1024;
                input = input_stream.ReadLine().Split(' ');
                N = Int16.Parse(input[0]);
                M = Int16.Parse(input[1]);
                sets = new HashSet<HashSet<int>>();
                for (int i = 0; i < N; i++)
                {
                    input = input_stream.ReadLine().Split(' ');
                    sets.Add(new HashSet<int>());
                    for (int j = 0; j < M; j++) sets.ElementAt(i).Add(Int32.Parse(input[j]));
                }
                Console.WriteLine("GOTOVA");
                stopWatch.Restart();
                output_stream.WriteLine(anotherIntersections(sets, N));
                output_stream.WriteLine("Estimated time: " + stopWatch.Elapsed);
                output_stream.WriteLine("Estimated memory: " + (Process.GetCurrentProcess().WorkingSet64 / 1024 - starting_memory) + " KB");
            }
            input_stream.Close();
            output_stream.Close();
        }

        static int anotherIntersections(HashSet<HashSet<int>> set, int N)
        {
            int max_intersection = 0;
            HashSet<int> temp;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    temp = set.ElementAt(i);
                    temp.IntersectWith(set.ElementAt(j));
                    if (temp.Count > max_intersection) max_intersection = temp.Count;
                }
            }
            return max_intersection;
        }
    }
}
