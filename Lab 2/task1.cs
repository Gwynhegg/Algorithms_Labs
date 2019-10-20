using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1
{
    class task1
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            stopWatch.Start();
            output_stream.WriteLine(NewVersion(input_stream));
            stopWatch.Stop();
            output_stream.WriteLine(stopWatch.Elapsed);
            input_stream.Close();
            output_stream.Close();
        }


        //Более продуманная версия программы со сложностью O(n). При линейном проходе через все элементы мы записываем сумму.
        //Максимальной будет являться сумма неотрицательных элементов при условии, что на каждом шаге сумма не уходит ниже нуля. Иначе обнуляем сумму и 
        //начинаем поиск заново.
        static int NewVersion(StreamReader input)
        {
            int N = Int32.Parse(input.ReadLine());
            int answer=0,sum=0,current_int;
            for (int i = 0; i < N; i++)
            {
                current_int = Int32.Parse(input.ReadLine());
                if (i == 0) answer = current_int;
                sum += current_int;
                if (answer < sum)  answer = sum;
                if (sum < 0) sum= 0;
            }
            return answer;
        }
    }
}
