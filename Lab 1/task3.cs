using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class task3
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            //Требуется файл input.txt в директории exe-файла программы
            StreamReader file_stream = new StreamReader("input.txt");
            string[] input = file_stream.ReadLine().Split(' ');
            int N = Int32.Parse(input[0]), M = Int32.Parse(input[1]), MOD = Int32.Parse(input[2]);
            int[] koef_array = new int[N + 1];
            int[] args_array = new int[M];

            //Поскольку нас интересуют лишь последние цифры, полученные в результате операции MOD, можем применить ее с самого начала вычислений 
            // к каждому члену полинома для избежания манипуляций с большими числами
            for (int i = 0; i < N + 1; i++)
            {
                koef_array[i] = Int32.Parse(file_stream.ReadLine()) % MOD;
            }
            for (int i = 0; i < M; i++)
            {
                args_array[i] = Int32.Parse(file_stream.ReadLine()) % MOD;
            }
            file_stream.Close();
            int answer;
            int[] arguments;

            StreamWriter output_stream = new StreamWriter("output.txt");
            for (int i = 0; i < M; i++)
            {
                answer = 0;
                arguments = ModPow(args_array[i], N, MOD);
                for (int j = 0; j < N; j++)
                {
                    answer += koef_array[j] * arguments[j] % MOD;
                }
                answer += koef_array.Last();
                answer %= MOD;
                output_stream.WriteLine(answer);
            }
            stopWatch.Stop();
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();
        }

        //Так как для решения задачи необходимы все степени числа до N включительно, записываем их в отдельный массив
        static int[] ModPow(int arg, int step, int MOD)
        {
            int[] args = new int[step];
            int pow_arg = arg;
            for (int j = 1; j <= step; j++)
            {
                args[step - j] = pow_arg;
                pow_arg = pow_arg * arg % MOD;
            }

            return args;
        }
    }
}
