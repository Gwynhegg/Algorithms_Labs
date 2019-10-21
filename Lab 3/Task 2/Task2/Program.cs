using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");

            Stopwatch stopWatch = new Stopwatch();

            int N, K, num_of_test=0;
            string[] input, names;
            byte[] priority;
            byte[,] fields;
            while (input_stream.EndOfStream == false)
            {
                output_stream.WriteLine("Test №" + (++num_of_test));
                 N = Int32.Parse(input_stream.ReadLine());
                 K = Int32.Parse(input_stream.ReadLine());
                 input = input_stream.ReadLine().Split(' ');
                 priority = new byte[K];
                //Считывание данных в двумерный массив
                for (int i = 0; i < K; i++)
                {
                    priority[i] = Byte.Parse(input[i]);
                }
                 fields = new byte[N, K + 1];
                 names = new string[N];
                for (int i = 0; i < N; i++)
                {
                    input = input_stream.ReadLine().Split(' ');
                    names[i] = input[0];
                    for (int j = 0; j < K; j++)
                    {
                        fields[i, j] = Byte.Parse(input[j + 1]);
                    }
                }
                stopWatch.Restart();
                StartSort(names, fields, priority, 0, 0, N, K);

                for (int i = 0; i < N; i++)
                {
                    output_stream.Write(names[i] + " ");
                    for (int j = 0; j < K; j++)
                    {
                        output_stream.Write(fields[i, j] + " ");
                    }
                    output_stream.WriteLine();
                }
                output_stream.WriteLine("Ответ:");
                for (int i = 0; i < N; i++)
                {
                    output_stream.WriteLine(names[i]);
                }
                stopWatch.Stop();
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            input_stream.Close();
            output_stream.Close();
        }

        static void StartSort(string[] names, byte[,] fields,byte[] priority, int start_priority,int starting_point, int array_count, int cols_count)
        {
            int distance = (array_count - starting_point) / 2;
            bool averson_condition = false;
            while (!averson_condition)
            {
                if (distance < 1) distance = 1;
                if (distance == 1) averson_condition = true;
                for (int i = starting_point; i+distance < array_count; i++)
                {
                    if (fields[i, priority[start_priority]-1] < fields[i + distance, priority[start_priority]-1]) {
                        SwapRows(fields, names, i, i + distance, cols_count);
                        averson_condition = false;
                    }
                }
                distance = distance /2;
            }
            //После сортировки по определенному столбцу разбиваем массив на подгруппы. Группа образовывается из элементов с равными значениями по приоритетному столбцу
            DivideArray(starting_point, array_count, priority, start_priority, fields, names, cols_count);
        }

        static void DivideArray(int starting_point, int array_count, byte[] priority, int start_priority, byte[,] fields, string[] names, int cols_count)
        {
            int new_start = starting_point, new_final = starting_point;
            for (int i = starting_point + 1; i < array_count; i++)
            {
                if (fields[i, priority[start_priority] - 1] == fields[i - 1, priority[start_priority] - 1]) new_final = i;
                else
                {
                    if (new_final - new_start >= 1) {
                        StartSort(names, fields, priority, start_priority + 1, new_start, new_final + 1, cols_count);
                    }
                    new_start = i;
                }
            }
            if (new_final - new_start >= 1) { StartSort(names, fields, priority, start_priority + 1, new_start, new_final + 1, cols_count);
            }
        }

        static void SwapRows(byte[,] fields_array, string[] names_array, int number_of_first, int number_of_second, int cols_count)
        {
            byte temp;
            string temp_string = names_array[number_of_first];
            names_array[number_of_first] = names_array[number_of_second];
            names_array[number_of_second] = temp_string;
            for (int i = 0; i < cols_count; i++)
            {
                temp = fields_array[number_of_first, i];
                fields_array[number_of_first, i] = fields_array[number_of_second, i];
                fields_array[number_of_second, i] = temp;
            }
        }
    }
}
