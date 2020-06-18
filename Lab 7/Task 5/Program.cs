using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            int[][] input_matrix;
            int N, K;
            while (!input_stream.EndOfStream)
            {
                string[] temp = input_stream.ReadLine().Split(' ');
                N = Int32.Parse(temp[0]); K = Int32.Parse(temp[1]);
                input_matrix = new int[N][];
                for (int i = 0; i < N; i++)
                {
                    input_matrix[i] = new int[K];
                    temp = input_stream.ReadLine().Split(' ');
                    for (int j = 0; j < K; j++) input_matrix[i][j] = Int32.Parse(temp[j]);
                }
                stopWatch.Restart();
                output_stream.WriteLine(maxSubMatrix(input_matrix));
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            output_stream.Close();
            input_stream.Close();
        }

        static void clearArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
        static int maxSubMatrix(int[][] matrix)
        {
            int row_count = matrix.Length;
            int col_count = matrix[0].Length;

            int[] partial_sum = new int[col_count];
            int max_sum = 0;

            for (int row_start = 0; row_start < row_count; row_start++)
            {
                clearArray(partial_sum);

                for (int row_end = row_start; row_end < row_count; row_end++)
                {
                    for (int i = 0; i < col_count; i++)
                    {
                        partial_sum[i] += matrix[row_end][i];
                    }

                    int temp_maxsum = maxSubArray(partial_sum, col_count);
                    max_sum = Math.Max(max_sum, temp_maxsum);
                }
            }
            return max_sum;
        }

        static int maxSubArray(int[] array, int N)
        {
            int max_sum = 0;
            int running_sum = 0;

            for (int i = 0; i < N; i++)
            {
                running_sum += array[i];
                max_sum = Math.Max(max_sum, running_sum);
                if (running_sum < 0)
                {
                    running_sum = 0;
                }
            }
            return max_sum;
        }
    }
}
