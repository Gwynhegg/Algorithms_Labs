using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int first_flask = 20;
            int second_flask = 10;
            int third_flask = 5;
            int proportion = 15;
            findSolution(first_flask, second_flask, third_flask, proportion);
            Console.ReadKey();
        }

        static void findSolution(int first_flask, int second_flask, int third_flask, int proportion)
        {
            int[,] solution_matrix = new int[second_flask+1, third_flask+1];
            int rest = first_flask - proportion;
            for (int i = 0; i < first_flask; i++)
            {

                    if (i<second_flask+1 && rest-i<third_flask+1) solution_matrix[i, rest - i] = -1;
            }
            for (int i = 0; i < second_flask+1; i++)
            {
                for (int j = 0; j < third_flask+1; j++)
                {
                    Console.Write(solution_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
