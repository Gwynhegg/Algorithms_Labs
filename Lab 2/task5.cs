using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task5
{
    class task5
    {
        static void Main(string[] args)
        {
            StreamReader input_stream = new StreamReader("input.txt");
            string[] input = input_stream.ReadLine().Split(' ');
            int numerator = Int32.Parse(input[0]), denumerator = Int32.Parse(input[1]);
            input_stream.Close();

            int NOD = Euclid(numerator, denumerator);

            if (NOD>1)
            {
                numerator /= NOD;
                denumerator /= NOD;
            }
            numerator = numerator % denumerator * 10;

            StreamWriter output_stream = new StreamWriter("output.txt");
            output_stream.Write("0.");
            List<int> rest = new List<int>();
            string answer = "";
            bool flag = true;
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();


            //Нахождение остатка от деления как учили в школе. Умножаем остаток на 10
            //и делим на делитель. Записываем полученное число в ответ и повторяем,
            //пока не поделим нацело или не найдем период
            while (numerator!=0 && flag)
            {
                if (!rest.Contains(numerator))
                {
                    rest.Add(numerator);
                    answer += numerator / denumerator;
                    numerator = numerator % denumerator * 10;
                }
                else {
                    answer = answer.Insert(rest.IndexOf(numerator), "(");
                    answer += ")"; 
                    flag = false;
                     }
            }
            stopWatch.Stop();
            output_stream.WriteLine(answer);
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();
        }

        static int Euclid(int a, int b)
        {
            while (a!=0 && b != 0)
            {
                if (a > b) a %= b; else b %= a;
            }
            return (a + b);
        }
    }
}
