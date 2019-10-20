using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class task1
    {
        static void Main(string[] args)
        {
            Stopwatch stop_watch = new Stopwatch();
            //Необходим файл input.txt в директории exe-файла программы
            StreamReader file_stream = new StreamReader("input.txt");
            string[] input_data = file_stream.ReadLine().Split();
            file_stream.Close();
            stop_watch.Start();

            //Вызов ключевого метода производится здесь. Будет проведен анализ двух алгоритмов и будет избран наиболее оптимальный

            //Вызов старой версии метода решения данной задачи
            //OldVersion(input_data);

            //Сортировка и актуальная версия решения задачи
            Sort(input_data);
            NewestVersion(input_data);
            bool flag = false;
            //Вывод результатов работы программы не включен во время работы алгоритма
            stop_watch.Stop();
            StreamWriter output_stream = new StreamWriter("output.txt");
            for (int k = 0; k < input_data.Length; k++)
            {
                if (input_data[k]!="0")
                {
                    output_stream.Write(input_data[k] + " ");
                    flag = true;
                }
            }
            if (!flag) output_stream.Write(0);
            output_stream.WriteLine();
            output_stream.WriteLine(stop_watch.Elapsed);
            output_stream.Close();
                    }

        //Актуальное решение задачи. Код во много раз проще и понятнее. Использование динамических списков сократило бы время "пробега" всего массива,
        // но условия задачи не предполагают его использование.

        static void NewestVersion(string[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i]==input[i-1])
                {
                    input[i] = "0";
                    input[i - 1] = "0";
                }
            }
        }
        //Несовершенная версия решения данной задачи
        static void OldVersion(string[] input)
        {
            int zero_position, i = 0;
            while (input[i] != "0") i++;
            zero_position = i;
            i = 0;
            int j = zero_position + 1;
            bool flag = true;
            while (i < zero_position)
            {
                flag = true;
                j = zero_position + 1;
                while (j < input.Length && flag)
                {
                    if (input[i] == input[j])
                    {
                        input[j] = "0";
                        input[i] = "0";
                        flag = false;
                    }
                    j++;
                }
                i++;
            }
            
        }

        //Реализация шейкерной сортировки
        static void Sort(string[] input)
        {
            int begin = 0, end = input.Length - 1;
            while (begin < end)
            {
                for (int i = begin; i < end; i++)
                {
                    if (Int32.Parse(input[i]) > Int32.Parse(input[i + 1])) Swap(input, i, i + 1);
                }
                end--;
                for (int j = end; j > begin; j--)
                {
                    if (Int32.Parse(input[j]) < Int32.Parse(input[j - 1])) Swap(input, j, j - 1);
                }
                begin++;
            }
        }

        //Обмен двух значений массива
        static void Swap(string[] input, int index1, int index2)
        {
            string temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }

    }
}
