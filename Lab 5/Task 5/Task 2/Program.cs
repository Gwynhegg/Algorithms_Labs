using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();

            int[] cache;
            int cache_size, num_of_requests;
            List<int> requests;
            string[] input;
            while (!input_stream.EndOfStream)
            {
                input = input_stream.ReadLine().Split(' ');
                cache_size = Int32.Parse(input[0]);
                num_of_requests = Int32.Parse(input[1]);
                cache = new int[cache_size];
                requests = new List<int>();
                for (int i = 0; i < num_of_requests; i++) requests.Add(Int32.Parse(input_stream.ReadLine()));
                stopWatch.Restart();
                output_stream.WriteLine(countOfRequests(cache, requests));
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            output_stream.Close();
            input_stream.Close();
        }

        static private int countOfRequests(int[] cache, List<int> requests)
        {
            int num_of_empty = 0, num_of_requests = 0, current_item;
            while (requests.Count != 0)
            {
                current_item = requests[0];
                if (num_of_empty < cache.Length)
                {
                    if (!cache.Contains(current_item))
                    {
                        cache[num_of_empty++] = current_item;
                        num_of_requests++;
                    } 
                } else
                {
                    if (!cache.Contains(current_item)){
                        cache[findNonWorthy(cache, requests)] = current_item;
                        num_of_requests++;
                    }
                }
                requests.RemoveAt(0);
            }

            return num_of_requests;
        }

        private static int findNonWorthy(int[] cache, List<int> requests)
        {
            for (int i = 0; i < cache.Length; i++)
            {
                if (!requests.Contains(cache[i])) return i;
            }
            return 0;
        }
    }
}
