using System;
using System.IO;
using System.Diagnostics;

namespace task1
{
    class task1
    {
        static void Main(string[] args)
        {
            tests new_tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
           
            string input="";
            string[] input_data;
            int[] numbers;
            int current_test = 0;
            int[] our_numbers = new int[5];
            while (input_stream.EndOfStream==false)
            {
                input = input_stream.ReadLine();
                int number_of_values = Int32.Parse(input);

                input_data = input_stream.ReadLine().Split(' ');
                numbers = new int[number_of_values];
                for (int i = 0; i < number_of_values; i++)
                {
                    numbers[i] = Int32.Parse(input_data[i]);
                }

                
                output_stream.WriteLine("Текущий тест: " + (++current_test));
                stopWatch.Restart();
                if (number_of_values < 3) output_stream.WriteLine("Среди малого количества элементов невозможно выбрать 3 для выполнения условия задачи");
                else if (number_of_values == 3) output_stream.WriteLine(numbers[0] * numbers[1] * numbers[2]);
                else if (number_of_values == 4)
                {
                    SortShaker(numbers);
                    long first_composition = (long)numbers[number_of_values - 1] * numbers[number_of_values - 2] * numbers[number_of_values - 3];
                    long second_composition = (long)numbers[0] * numbers[1] * numbers[number_of_values - 1];
                    if (first_composition > second_composition) output_stream.WriteLine(first_composition); else output_stream.WriteLine(second_composition);
                } else
                {
                    if (number_of_values >= 5) output_stream.WriteLine(MethodNumberTwo(numbers)+" ");
                    stopWatch.Stop();
                    output_stream.WriteLine("Затраченное время: " + stopWatch.Elapsed);
                }
            }            
            input_stream.Close();
            output_stream.Close();
        }
        //Метод, не требующий сортировки огромного массива, работающий со сложностью O(n). ИСпользуем массив с пятью элементами, в который кидаем на проверку каждый входящий
        //элемент. Переставляем все элементы относительно величины текущего. Проще говоря - "сортировка на ходу";
        static long MethodNumberTwo(int[] array)
        {
            int[] our_numbers = new int[5] {array[0],array[1],array[2],array[3],array[4]};
            SortShaker(our_numbers);
            for (int i = 5; i < array.Length; i++)
            {
                    if (array[i] < our_numbers[0])
                    {
                        our_numbers[1] = our_numbers[0];
                        our_numbers[0] = array[i];
                    }
                    else if (array[i] >= our_numbers[0] && array[i] < our_numbers[1]) our_numbers[1] = array[i];

                    if (array[i] > our_numbers[4])
                    {
                        our_numbers[2] = our_numbers[3];
                        our_numbers[3] = our_numbers[4];
                        our_numbers[4] = array[i];
                    }
                    else if (array[i] <= our_numbers[4] && array[i] > our_numbers[3])
                    {
                        our_numbers[2] = our_numbers[3];
                        our_numbers[3] = array[i];
                    }
                    else if (array[i] > our_numbers[2]) our_numbers[2] = array[i];
            }
            long first_composition = (long)our_numbers[4] * our_numbers[3] * our_numbers[2];
            long second_composition = (long)our_numbers[0] * our_numbers[1] * our_numbers[4];
            if (first_composition > second_composition) return (first_composition); else return (second_composition);
        }
        static void SortShaker(int[] A)
        {
            int left = 1, right = A.Length - 1, last = right;
            do
            {
                for (int j = right; j >= left; j--)
                    if (A[j - 1] > A[j])
                    {
                        int t = A[j - 1]; A[j - 1] = A[j]; A[j] = t;
                        last = j;
                    }
                left = last;
                for (int j = left; j <= right; j++)
                    if (A[j - 1] > A[j])
                    {
                        int t = A[j - 1]; A[j - 1] = A[j]; A[j] = t;
                        last = j;
                    }
                right = last - 1;
            }
            while (left < right);
        }


    }
}
