using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Task4
{
    class task4
    {
        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");

            string[] input = input_stream.ReadLine().Split(' ');
            int M = Int32.Parse(input[0]), N = Int32.Parse(input[1]);
            input_stream.Close();

            stopWatch.Start();
            int number_of_primes = 0;

            int limit = 20000000;
            bool[] is_prime = new bool[limit+1];
            int n;

            // Инициализация решета
            int sqr_lim = (int)Math.Sqrt(limit);
            for (int i = 0; i <= limit; i++) is_prime[i] = false;
            is_prime[2] = true;
            is_prime[3] = true;

            // Предположительно простые - это целые с нечетным числом
            // представлений в данных квадратных формах.
            // x2 и y2 - это квадраты i и j (оптимизация).
            int x2 = 0;
            for (int i = 1; i <= sqr_lim; i++)
            {
                x2 += 2 * i - 1;
                int y2 = 0;
                for (int j = 1; j <= sqr_lim; j++)
                {
                    y2 += 2 * j - 1;

                    n = 4 * x2 + y2;
                    if ((n <= limit) && (n % 12 == 1 || n % 12 == 5))
                        is_prime[n] = !is_prime[n];

                    // n = 3 * x2 + y2; 
                    n -= x2; // Оптимизация
                    if ((n <= limit) && (n % 12 == 7))
                        is_prime[n] = !is_prime[n];

                    // n = 3 * x2 - y2;
                    n -= 2 * y2; // Оптимизация
                    if ((i > j) && (n <= limit) && (n % 12 == 11))
                        is_prime[n] = !is_prime[n];
                }
            }

            // Отсеиваем квадраты простых чисел в интервале [5, sqrt(limit)].
            // (основной этап не может их отсеять)
            for (int i = 5; i <= sqr_lim; i++)
            {
                if (is_prime[i])
                {
                    n = i * i;
                    for (int j = n; j <= limit; j += n)
                    {
                        is_prime[j] = false;
                    }
                }
            }

            bool is_finished = false;
            int diap = 0;
            int a = 2, b = 20000000;
            for (int i = 2; i < is_prime.Length; i++)
            {
                if (diap != N)
                {
                    diap++;
                }
                else if (diap == N && number_of_primes != M)
                {
                    if (!is_prime[i] && is_prime[a])
                    {
                        number_of_primes--;
                    }
                    else if (is_prime[i] && !is_prime[a])
                    {
                        number_of_primes++;
                    }
                    a = a + 1;
                    continue;
                }
                else if (diap == N && number_of_primes == M)
                {
                    output_stream.WriteLine(a);
                    is_finished = true;
                    break;
                }
                if (is_prime[i])
                {
                    if (i >= 2)
                    {
                        number_of_primes++;
                    }
                }
            }
            if (!is_finished)
            {
               output_stream.WriteLine(-1);
            }
            stopWatch.Stop();
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();
        }
    }
}
