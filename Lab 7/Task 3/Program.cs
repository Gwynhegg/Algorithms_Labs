using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            string first, second;
            while (!input_stream.EndOfStream)
            {
                first = input_stream.ReadLine();
                second = input_stream.ReadLine();
                stopWatch.Restart();
                output_stream.WriteLine(findMaxSubstring(first, second));
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            output_stream.Close();
            input_stream.Close();
        }

        static string findMaxSubstring(string first, string second)
        {
            int max = int.MinValue, index_i = 0, index_j = 0;
            int[,] conversions = new int[first.Length+1, second.Length+1];
            for (int i = 1; i < first.Length; i++)
            {
                for (int j = 1; j < second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1]) conversions[i, j] = conversions[i - 1, j - 1] + 1;
                    if (conversions[i, j] > max)
                    {
                        max = conversions[i, j]; index_i = i; index_j = j;
                    }
                }
            }

            //После заполнения матрицы пересечений, необходимо восстановить решение. Для этого нужно найти максимальный элемент в матрице
            string answer = "";
            while (conversions[index_i, index_j] > 0)
            {
                answer = first[index_i - 1] + answer;
                index_i--; index_j--;
            }
            return answer;
        }
    }
}
