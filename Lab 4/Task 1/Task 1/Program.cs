using System;
using System.Diagnostics;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            tests new_tests = new tests();
            Stopwatch stopWatch = new Stopwatch();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            int N, K;
            int[] length_array;
            while (!input_stream.EndOfStream)
            {
                string[] input = input_stream.ReadLine().Split(' ');
                N = Int32.Parse(input[0]);
                K = Int32.Parse(input[1]);
                length_array = new int[N];
                for (int i = 0; i < N; i++) length_array[i] = Int32.Parse(input_stream.ReadLine());
                stopWatch.Restart();
                Array.Sort(length_array);
                output_stream.WriteLine(BinarySearch(length_array, K));
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            input_stream.Close();
            output_stream.Close();
        }

        //метод нахождения максимального  элемента в массиве, который будет взят за верхнуюю границу поиска
        static int getMaximum(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++) if (array[i] > max) max = array[i];
            return max;
        }
        static int BinarySearch(int[] array, int K)
        {
            int left_border = 1, right_border = getMaximum(array), point, current_state = 0;
            int max_element = right_border;

            //С помощью бинарного поиска находим элемент, который при делении на куски длиной point дает ровно current_state кусков
            do
            {
                point = (left_border + right_border) / 2;
                current_state = SumOfDivided(array, point);
                if (current_state > K) left_border = point + 1;
                else if (current_state < K) right_border = point - 1;
            } while (current_state != K && left_border <= right_border);

            //Если мы обнаружили, что кусок необходимой нам длины находиться между двумя значениями,  то возвращаем минимальную длину
            //(так как при максимальном значении из двух нам не хватит количества поделенных кусков)
            if (left_border > right_border) return Math.Min(left_border, right_border);

            //Если мы обнаружили, что мы можем поделить кусок несколькими способами, но сохранив количество кусков, то возвращаем максимальный из них,
            //который будет равен ближайшему максимальному значению в исходном массиве
            if (point < max_element)
            {
                if (current_state == SumOfDivided(array, point + 1))
                {
                    for (int i = array.Length - 1; i > 1; i--) if (point < array[i] && point > array[i - 1]) return array[i];
                }
            }
            return point;
        }

        //Здесь мы находим сумму кусков, которые можно получить разделением каждого провода на длину denumerator
        static int SumOfDivided(int[] array, int denumerator)
        {
            int final_sum = 0;
            for (int i = 0; i < array.Length; i++) final_sum += array[i] / denumerator;
            return final_sum;
        }

    }
}
