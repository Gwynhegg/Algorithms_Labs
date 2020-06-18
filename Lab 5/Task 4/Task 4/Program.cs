using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            while (!input_stream.EndOfStream)
            {
                int num_of_lines = Int32.Parse(input_stream.ReadLine());
                List<int[]> records = new List<int[]>();
                int[] temp;
                stopWatch.Restart();
                for (int i = 0; i < num_of_lines; i++)
                {
                    temp = new int[26];
                    foreach (char e in input_stream.ReadLine()) temp[((int)e) - 65]++;
                    if (records.Find(item=>item.SequenceEqual(temp))==null) records.Add(temp);
                }
                output_stream.WriteLine(records.Count);
                output_stream.WriteLine(stopWatch.Elapsed);
               
            }
            input_stream.Close();
            output_stream.Close();
        }
    }
}
