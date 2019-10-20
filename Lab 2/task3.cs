using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task3
{
    class task3
    {
        static void Main(string[] args)
        {
            StreamReader input_stream = new StreamReader("input.txt");
            Stopwatch stopWatch = new Stopwatch();

            string[] input1 = input_stream.ReadLine().Split(' ');
            int dot_step = Int32.Parse(input1[0]), num_of_dots = Int32.Parse(input1[1]);
            string[] input2 = input_stream.ReadLine().Split(' ');
            input_stream.Close();

            int[] dots = new int[input2.Length];
            for (int i = 0; i < input2.Length; i++)
            {
                dots[i] = Int32.Parse(input2[i]);
            }

            stopWatch.Start();
            //Упорядочим массив по неубыванию, чтобы сымитировать числовую прямую
            Sort(dots);

            //И, если можно сделать шаг, то всегда лучше его сделать, чем не сделать
            //Нет уверенности, что условие задачи подразумевает именно это, поскольку оно допускает некоторую двойственность в интерпретации.
            //В данном решении будем считать, что точка поле перемещения сливается с стоящей на том же месте точкой и может продолжить движение в составе новой точки.
            /* for (int i = 0; i < dots.Length - 1; i++)
             {
                 if (dots[i] + dot_step >= dots[i + 1]) num_of_dots--;
             }
             */
            stopWatch.Stop();
            StreamWriter output_stream = new StreamWriter("output.txt");
            output_stream.WriteLine(newVersion(dots, dot_step));
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();
        }


        //Реализация шейкерной сортировки
        static void Sort(int[] input)
        {
            int begin = 0, end = input.Length - 1;
            while (begin < end)
            {
                for (int i = begin; i < end; i++)
                {
                    if (input[i] > input[i + 1]) Swap(input, i, i + 1);
                }
                end--;
                for (int j = end; j > begin; j--)
                {
                    if (input[j] <input[j - 1]) Swap(input, j, j - 1);
                }
                begin++;
            }
        }

        //Обмен двух значений массива
        static void Swap(int[] input, int index1, int index2)
        {
            int temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }

        //Новая версия решения задачи, когда было понято то, что условие задачи было принято неправильно
        //Алгоритм заключается в следующем: делаем максимальный шаг от крайней справа точки и притягиваем те, до которых можно дотянуться, в эту точку. Далее делаем еще один шаг
        //влево и повторяем алгоритм, пока точки не закончаться
        static int newVersion(int[] input, int step)
        {
            int current_dot,num_of_dots=0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] != 0)
                {
                    current_dot = input[i] - step;
                    num_of_dots++;
                    Console.WriteLine(current_dot);
                    int j = i;
                    while (j>=0 && input[j] + step >= current_dot)
                    {
                        if (input[j] - step <= current_dot || input[j] + step >= current_dot) input[j] = 0;
                        j--;
                    }
                }
            }
            return num_of_dots;
        }
    }
}
