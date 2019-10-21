using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphPanel graph = new GraphPanel();
            tests new_test = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
                    graph.Activate();
                    graph.Show();
                    graph.createGraph();
            int N = Int32.Parse(input_stream.ReadLine());
            int[,] dots = new int[N, 2];
            for (int i = 0; i < N; i++)
            {
                string[] input = input_stream.ReadLine().Split(' ');
                dots[i, 0] = Int32.Parse(input[0]);
                dots[i, 1] = Int32.Parse(input[1]);
                graph.putDot(dots[i, 0], dots[i, 1]);
            }
            input_stream.Close();
            stopWatch.Start();
            //Сортируем точки по оси X в порядке возрастания
            QuickSort(dots, 0, N - 1, 0);
            int index_max = 0, index_min = 0, curr_max = dots[0, 1], curr_min = dots[0, 1], index = 1 ;
            //Опредеяем стартовые точки для начала обрисовки границ. Это максимальный и минимальный элемент по Y с самым меньшим X
            while (index < N && dots[index, 0] == dots[index - 1,0])
            {
                if (dots[index, 1] < curr_min)
                {
                    curr_min = dots[index, 1];
                    index_min = index;
                }
                if (dots[index, 1] > curr_max)
                {
                    curr_max = dots[index, 1];
                    index_max = index;
                }
                index++;
            }
            output_stream.WriteLine(Math.Round(UpperBorder(dots,N,graph,index_max) + LowerBorder(dots,N,graph, index_min)+VerticalLine(dots[index_max,0],curr_max,curr_min,graph),2));
            stopWatch.Stop();
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();
            Console.ReadKey();
        }

        //Здесь мы прочерчиваем первую вертикальную линию (если есть) и возвращаем ее длину
        static int VerticalLine(int x, int y1, int y2, GraphPanel graph)
        {
            graph.putLine(x,y1,x,y2);
            return Math.Abs(y2 - y1);
        }

        //Рисуем верхную границу, продвигаясь в точку, угол которой является наибольшим (с помощью Atan2)
        static double UpperBorder(int[,] dots,int N, GraphPanel graph, int start_index)
        {
            int max_X = dots[start_index, 0], max_Y = dots[start_index, 1], num_of_last = 0;
            int starting_X = dots[start_index, 0], starting_Y = dots[start_index, 1];
            double max_angle = 0, final_distance = 0;
            while (num_of_last + 1 < N)
            {
                max_angle = Tangle(starting_X, starting_Y, dots[num_of_last + 1, 0], dots[num_of_last + 1, 1]);
                for (int i = num_of_last + 1; i < N; i++)
                {
                    double radians = Tangle(starting_X, starting_Y, dots[i, 0], dots[i, 1]);
                    if (radians >= max_angle)
                    {
                        max_angle = radians;
                        max_X = dots[i, 0]; max_Y = dots[i, 1];
                        num_of_last = i;
                    }
                }
                final_distance += DistanceTo(starting_X, starting_Y, max_X, max_Y);
                graph.putLine(starting_X, starting_Y, max_X, max_Y);
                starting_X = max_X; starting_Y = max_Y;
                Console.WriteLine("Выбрана точка: " + starting_X + " " + starting_Y);
            }
            return final_distance;
        }

        //РИсуем нижнюю границу, отправляясь в точку, угол которой является наименьшим(с помощью Atan2)
        static double LowerBorder(int[,] dots, int N, GraphPanel graph, int start_index)
        {
            int min_X = dots[start_index, 0], min_Y = dots[start_index, 1], num_of_last=0;
            int starting_X = dots[start_index, 0], starting_Y = dots[start_index, 1];
            double min_angle = 0, final_distance = 0; ;
            while (num_of_last + 1 < N)
            {
                min_angle = Tangle(starting_X, starting_Y, dots[num_of_last + 1, 0], dots[num_of_last + 1, 1]);
                for (int i = num_of_last + 1; i < N; i++)
                {
                    double radians = Tangle(starting_X, starting_Y, dots[i, 0], dots[i, 1]);
                    if (radians <= min_angle)
                    {
                        min_angle = radians;
                        min_X = dots[i, 0]; min_Y = dots[i, 1];
                        num_of_last = i;
                    }
                }
                final_distance += DistanceTo(starting_X, starting_Y, min_X, min_Y);
                graph.putLine(starting_X, starting_Y, min_X, min_Y);
                starting_X = min_X; starting_Y = min_Y;
                Console.WriteLine("Выбрана точка: " + starting_X + " " + starting_Y);
            }
            return final_distance;
        }

        static int Partition(int[,] array, int start, int end, int sorting_element)
        {
            int temp, temp2;
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (array[i, sorting_element] < array[end, sorting_element])
                {
                    temp = array[marker, sorting_element];
                    array[marker,0] = array[i, sorting_element];
                    array[i, sorting_element] = temp;
                    temp2 = array[marker, 1];
                    array[marker, 1] = array[i, 1];
                    array[i, 1] = temp2;
                    marker += 1;
                }
            }
            temp = array[marker, sorting_element];
            array[marker, sorting_element] = array[end, sorting_element];
            array[end, sorting_element] = temp;
            temp2 = array[marker, 1];
            array[marker, 1] = array[end, 1];
            array[end, 1] = temp2;
            return marker;
        }

        static void QuickSort(int[,] array, int start, int end, int sorting_element)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end, sorting_element);
            QuickSort(array, start, pivot - 1, sorting_element);
            QuickSort(array, pivot + 1, end, sorting_element);
        }

        //Здесь мы возвращаем угол
        static double Tangle(int x1, int y1, int x2, int y2)
        {

                return Math.Atan2(y2-y1, x2-x1);


        }

        //Здесь мы находим расстояние между точками
        static double DistanceTo(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
