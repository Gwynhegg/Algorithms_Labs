using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class task2
    {
        static void Main(string[] args)
        {
            //Необходим файл input.txt в директории exe-файла программы
            StreamReader file_stream = new StreamReader("input.txt");
            string[] input = file_stream.ReadLine().Split(' ');
            int n1 = Int32.Parse(input[0]), n2 = Int32.Parse(input[1]);
            //Формирование двух отдельных наборов данных
            int[] first_set = new int[n1];
            int[] second_set = new int[n2];
            for (int i = 0; i < n1; i++)
            {
                first_set[i] = Int32.Parse(file_stream.ReadLine());
            }
            for (int i = 0; i < n2; i++)
            {
                second_set[i] = Int32.Parse(file_stream.ReadLine());
            }
            file_stream.Close();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            StreamWriter output_stream = new StreamWriter("output.txt");

            output_stream.WriteLine(Comparison(first_set, second_set));
            stopWatch.Stop();
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();


        }

        //Алгоритм, подсчитывающий количество общих элементов
        static int Comparison(int[] a, int[] b)
        {
            int num_of_equal = 0;
            int j=0;
            bool flag;
            //Итератор "прыгает" п элементам первого массива и сравнивает с элементами второго. Так как данные упорядочены ->
            for (int i = 0; i < a.Length; i++)
            {
                flag = true;
                while (j < b.Length && flag)
                {
            // так как данные упорядоченны, нахождение элемента, больше элемента первого массива говорит о том, что дальше искать нечего, и происходит
            // выход из цикла
                        if (b[j] > a[i]) flag = false;
            //Если же они равны, то мы добавляем единицу к счетчику совпадений и сдвигаем начало поиска на номер найденного элемента +1, потому что
            // элементы упорядоченны, и можно избежать повторного прохождения циклом начала второго массива
                    if (a[i] == b[j])
                    {
                       // Проверка на правильность получившегося множества
                       // Console.Write(a[i] + " ");
                        num_of_equal++;
                        flag = false;
                        j++;
                    }
            //Если элемент не найден, то продолжаем двигаться вперед, пока не найдем необходимый элемент или не достигнем конца массива
                    else if (a[i] > b[j]) j++;
                }
            }
            return num_of_equal;
        }
    }
}
