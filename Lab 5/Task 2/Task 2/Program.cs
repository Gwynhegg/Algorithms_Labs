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
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();

            HashSet<string> ideals;
            string[] input;
            while (!input_stream.EndOfStream)
            {
                input = input_stream.ReadLine().Split(' ');
                int num_of_ideals = Int32.Parse(input[0]), num_of_elements = Int32.Parse(input[1]), num_of_checks = Int32.Parse(input[2]);
                ideals = new HashSet<string>();
                for (int i = 0; i < num_of_ideals; i++)
                {
                    input = input_stream.ReadLine().Split(' ');
                    Array.Sort(input);
                    ideals.Add(String.Join(" ", input));
                }
                Console.WriteLine("Starting...");
                stopWatch.Restart();
                for (int i = 0; i < num_of_checks; i++)
                {
                    input = input_stream.ReadLine().Split(' ');
                    Array.Sort(input);
                    if (ideals.Contains(String.Join(" ",input))) output_stream.WriteLine(1);           
                    else output_stream.WriteLine(0);
                }
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            output_stream.Close();
            input_stream.Close();
        }
    }
}
