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
            tests new_tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();

            List<double> capitals=new List<double>();
            int number_of_firms;
            while (!input_stream.EndOfStream)
            {
                number_of_firms = Int32.Parse(input_stream.ReadLine());
                capitals.Clear();
                string[] input = input_stream.ReadLine().Split(' ');
                for (int i = 0; i < number_of_firms; i++) capitals.Add((double)Int32.Parse(input[i]) / 100);
                stopWatch.Restart();
                capitals.Sort();
                output_stream.WriteLine(Merge(capitals));
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            input_stream.Close();
            output_stream.Close();
        }

        static double Merge(List<double> array)
        {

            double minimal_cost = 0;
            for (int i = 0; i < array.Count - 1; i++)
            {
                array[i + 1] += array[i];
                minimal_cost += array[i + 1];
                startMovement(array, i + 1);
            }
            return minimal_cost;
        }

        static void startMovement(List<double> array, int index)
        {
            double temp = array[index];
            array.RemoveAt(index);
            for (int i = index; i < array.Count; i++)
            {
                if (temp < array[i])
                {
                    array.Insert(i, temp);
                    return;
                }
            }
            array.Add(temp);
        }


    }
}
