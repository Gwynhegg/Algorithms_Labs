using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            int num_of_stones;
            while (!input_stream.EndOfStream)
            {
                num_of_stones = Int32.Parse(input_stream.ReadLine());
                stopWatch.Restart();
                if (findSolution(num_of_stones)) output_stream.WriteLine("FIRST"); else output_stream.WriteLine("SECOND");
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            input_stream.Close();
            output_stream.Close();
        }

        private static bool findSolution(int num)
        {
            bool[,] turns = new bool[num+1, 2];
            //Пусть значение true означает, что выиграл первый игрок, false - второй игрок.
            //Каждый ход делим на 2 случая - когда он принадлежит первому игроку, и когда второму
            //В значении [i,0] - ход принадлежит первому игроку, значение [i,1] - второму
            //Ячейки [0,...] оставим неизмененными, чтобы не нарушать логику
            turns[1, 0] = true; turns[1, 1] = false;
            for (int i = 2; i < num + 1; i++)
            {
                turns[i, 1] = true;
                for (int j = 1; j <= (int)Math.Sqrt(i); j++)
                {
                    if (turns[i - j, 1] == true) turns[i, 0] = true;
                    if (turns[i - j, 0] == false) turns[i, 1] = false;
                }

            }
            //for (int i = 1; i < num+1; i++)
            //{

            //    Console.WriteLine(turns[i, 0] + "   " + turns[i, 1]);
            //}
            return turns[num,0];
        }
    }
}
