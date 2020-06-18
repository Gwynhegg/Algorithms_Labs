using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        private static int best_length = int.MaxValue;
        private static string best_route;
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            int[,] cities;
            string[] input;
            int num_of_cities, length_of_journey;
            while (!input_stream.EndOfStream)
            {
                input = input_stream.ReadLine().Split(' ');
                num_of_cities = Int32.Parse(input[0]);
                length_of_journey = Int32.Parse(input[1]);
                cities = new int[num_of_cities, length_of_journey];
                for (int i=0;i<num_of_cities;i++)
                {
                    input = input_stream.ReadLine().Split(' ');
                    for (int j = 0; j < length_of_journey; j++) cities[i, j] = Int32.Parse(input[j]);
                }
                stopWatch.Restart();
                dinamicSolution(cities, output_stream);
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            input_stream.Close();
            output_stream.Close();
        }

        static void dinamicSolution(int[,] cities, StreamWriter output_stream)
        {
            //Для того, чтобы решить данную задачу оптимально, используем следующую функцию
            //arr[i,N-1],arr[i,N],arr[i,N+1] = arr[i-1,N]. На пересечении данных формул, поскольку каждый путь пересекается еще минимум с 2-мя другими, выбирается минимальный из возможных
            //Таким образом, например, arr[i,N] = min(arr[i-1,N],arr[i-1,N-1],arr[i-1,N+1]. 
            //То есть на каждом шаге мы рассматриваем 3 предыдущих значения и выбираем минимальный из них
            //Построим матрицу обратного заполнения
            int[,] solution_matrix = new int[cities.GetLength(0), cities.GetLength(1)];
            List<int> cache = new List<int>();
            for (int i = 0; i < solution_matrix.GetLength(0); i++) solution_matrix[i, 0] = cities[i, 0];
            for (int current_step = 1; current_step < solution_matrix.GetLength(1); current_step++)
            {
                cache.Clear();
                cache.Add(solution_matrix[0,current_step-1]);
                for (int j=0;j< solution_matrix.GetLength(0); j++)
                {
                    if (j + 1 < solution_matrix.GetLength(0)) cache.Add(solution_matrix[j + 1, current_step - 1]); else cache.RemoveAt(0);
                    if (cache.Count > 3) cache.RemoveAt(0);
                    solution_matrix[j, current_step] = cache.Min()+cities[j,current_step];
                }
            }

            //Вывод данных
            //for (int i = 0; i < solution_matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < solution_matrix.GetLength(1); j++) Console.Write(solution_matrix[i, j] + " ");
            //    Console.WriteLine();
            //}

            //Таким образом, ответом к задаче будет первое минимальное значение среди значений последнего столбца.
            //Необходимо восстановить решение
            int min = int.MaxValue, index_of_min = 0;
            for (int i=0;i<solution_matrix.GetLength(0);i++) if (solution_matrix[i,solution_matrix.GetLength(1)-1]<min)
                {
                    min = solution_matrix[i, solution_matrix.GetLength(1) - 1]; index_of_min = i;
                }
            output_stream.WriteLine(min);
            output_stream.WriteLine(restoreRoute(solution_matrix, index_of_min));
        }

        static string restoreRoute(int[,] solution_matrix, int starting_index)
        {
            int diap_start, diap_end, temp_min, temp_index;
            string solution_chain = (starting_index + 1).ToString();
            for (int j = solution_matrix.GetLength(1)-2; j >= 0; j--)
            {
                if (starting_index - 1 >= 0) diap_start = starting_index - 1; else diap_start = starting_index;
                if (starting_index + 1 < solution_matrix.GetLength(0)) diap_end = starting_index + 1; else diap_end = starting_index;
                temp_min = solution_matrix[diap_start,j]; temp_index = diap_start;
                for (int k = diap_start; k <= diap_end; k++) if (solution_matrix[k, j] < temp_min)
                    {
                        temp_min = solution_matrix[k, j]; temp_index = k;
                    }
                starting_index = temp_index;
                solution_chain = (starting_index + 1) + " " + solution_chain;
            }
            return solution_chain;
        }
        static void buildRoute(int[,] cities, string route, int current_step, int current_city, int weight)
        {
            if (current_step == 0)
            {
                for (int i = 0; i < cities.GetLength(0); i++)
                {
                    if (i > 0) buildRoute(cities, route + (i + 1) + " ", current_step + 1, i - 1, weight + cities[i, 0]);
                    if (i < cities.GetLength(0)-1) buildRoute(cities, route + (i + 1) + " ", current_step + 1, i + 1, weight + cities[i, 0]);
                    buildRoute(cities, route + (i + 1) + " ", current_step + 1, i, weight + cities[i, 0]);
                }
            }
            else if (current_step == cities.GetLength(1)) findBest(route, weight);
            else
            {
                if (current_city > 0) buildRoute(cities, route + (current_city + 1) + " ", current_step + 1, current_city - 1, weight + cities[current_city, current_step]);
                if (current_city < cities.GetLength(0)-1) buildRoute(cities, route + (current_city + 1) + " ", current_step + 1, current_city + 1, weight + cities[current_city, current_step]);
                buildRoute(cities, route + (current_city + 1) + " ", current_step + 1, current_city, weight + cities[current_city, current_step]);
            }
        }

        static void findBest(string route, int weight)
        {
            //Console.WriteLine(route);
            //Console.WriteLine(weight);
            //Console.WriteLine(new String('-', 50));
            if (weight<best_length)
            {
                best_length = weight;
                best_route = route;
            }
        }
    }
}
