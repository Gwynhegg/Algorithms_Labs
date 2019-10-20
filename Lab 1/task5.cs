using System;
using System.Diagnostics;
using System.IO;

namespace Task5
{
    class task5
    {
        static int final_sum;
        static bool flag = false;
        static void Main(string[] args)
        {
            StreamReader file_stream = new StreamReader("input.txt");
            int N = Int32.Parse(file_stream.ReadLine());
            string[] input_data = file_stream.ReadLine().Split(' ');
            file_stream.Close();
            int[] heavy_rocks = new int[N];
            for (int i = 0; i < N; i++)
            {
                heavy_rocks[i] = Int32.Parse(input_data[i]);
            }
            Stopwatch stop_watch = new Stopwatch();
            stop_watch.Start();
            StreamWriter output_stream = new StreamWriter("output.txt");
            //Опытным путем было установленно, что после 1 + N-1 нулей все возможные комбинации и их суммы начинают повторяться, что
            //позволило уменьшить время работы алгоритма вдвое, но все еще недостаточно
            //Неоптимальный реккурентный перебор всех возможных вариантов с последующим нахождением минимальной суммы
            Recur("0",N,heavy_rocks, output_stream);
            output_stream.WriteLine(final_sum);
            stop_watch.Stop();
            output_stream.WriteLine(stop_watch.Elapsed);
            output_stream.Close();
        }

        //Генерируем все возможные комбинации, где 1 - камень в правой куче и 0 - в левой
        static void Recur(string variant, int N, int[] weights, StreamWriter os)
        {
            if (variant.Length == N)
            {
                //Проверка полученных комбинаций
                // Console.WriteLine(variant);
                //Передаем полученный набор в подсчет весов и сравнение их с минимальным
                MinSearch(variant, weights,os);
            } else
            {
                    for (int i = 0; i < 2; i++)
                    {
                        Recur(variant + i, N, weights, os);
                    }
            }
        
        }

        static void MinSearch(string input, int[] weights, StreamWriter os)
        {
            int sum_of_left = 0, sum_of_right = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '0') sum_of_left += weights[i]; else sum_of_right += weights[i];
            }
            //Проверка полученных весов
            //Console.WriteLine(sum_of_left + " - " + sum_of_right);
            if (!flag)
            {
                final_sum = Math.Abs(sum_of_right - sum_of_left);
                flag = true;
            } else
            {
                if (Math.Abs(sum_of_right - sum_of_left) < final_sum) {
                    final_sum = Math.Abs(sum_of_right - sum_of_left);
                 //   Console.WriteLine(input);
                 //   Console.WriteLine(sum_of_left + " " + sum_of_right);
                }

            }
        }
    }
}
