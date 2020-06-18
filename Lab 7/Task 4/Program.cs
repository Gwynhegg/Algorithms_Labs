using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://www.ega-math.narod.ru/Quant/Tickets.htm#A2
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();

            int num_of_numbers, number_system;
            string[] input;

            while (!input_stream.EndOfStream)
            {
                input = input_stream.ReadLine().Split(' ');
                num_of_numbers = Int32.Parse(input[0]); number_system = Int32.Parse(input[1]);
                stopWatch.Restart();
                output_stream.WriteLine(findLucky(num_of_numbers, number_system));
                output_stream.WriteLine(stopWatch.Elapsed);
            }

            input_stream.Close();
            output_stream.Close();
        }

        static BigInteger findLucky(int N, int K)
        {
            int divided_N = N / 2;
            int dimension = (K - 1) * divided_N;
            List<BigInteger> cache = new List<BigInteger>();
            BigInteger temp_sum=0;
            BigInteger[,] table = new BigInteger[dimension+divided_N, divided_N];
            for (int i = 0; i < dimension; i++) if (i < K) table[i, 0] = 1; else table[i, 0] = 0;
            for (int i = 1; i < divided_N; i++)
            {
                cache.Clear();
                temp_sum = 0;
                for (int j = 0; j <= (i+1)*(K-1); j++)
                {
                    cache.Add(table[j, i - 1]);
                    temp_sum += table[j, i - 1];
                    if (cache.Count>K)
                    {
                        temp_sum -= cache[0];
                        cache.RemoveAt(0);
                    }
                    table[j, i] = temp_sum;                   
                }
            }

            BigInteger answer = 0;
            for (int i = 0; i < dimension+divided_N; i++)
            {
                answer += table[i, divided_N - 1] * table[i, divided_N - 1];
            }
            return answer;
        }
    }
}
