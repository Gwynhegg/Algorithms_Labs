using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double starting_memory = (double)Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024;
            tests new_tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            double current_memory;
            string[] lines;
            List<Milestones> milestones = new List<Milestones>();
            Stopwatch stopWatch = new Stopwatch();
            int N;

            while (!input_stream.EndOfStream)
            {
                milestones.Clear();
                N = Int32.Parse(input_stream.ReadLine());
                lines = new string[N];
                for (int i = 0; i < N; i++) lines[i] = input_stream.ReadLine();

                stopWatch.Restart();
                Array.Sort(lines);

                milestones.Add(new Milestones(0, '-'));
                for (int i = 1; i < N; i++) if (lines[i - 1][0] != lines[i][0]) milestones.Add(new Milestones(i, lines[i - 1][0]));
                milestones.Add(new Milestones(N, lines[N - 1][0]));

                for (int i = 0; i < N; i++) findComponents(lines, i, lines[i], milestones, output_stream);
                output_stream.WriteLine("Estimated time: " + stopWatch.Elapsed);
                current_memory = (double)Process.GetCurrentProcess().WorkingSet64 / 1024/1024;
                output_stream.WriteLine("Estimated memory: " + (current_memory-starting_memory)+" МB");
            }

            input_stream.Close();
            output_stream.Close();
        }

        static void findComponents(string[] lines, int index, string temporal, List<Milestones> milestones,StreamWriter output)
        {
            int current_range_start, current_range_end,i=0;
            while (milestones[i].getLetter() != temporal[0]) i++;
            current_range_start = milestones[i - 1].getIndex();
            current_range_end = milestones[i].getIndex();
            for (int j = current_range_start; j < current_range_end; j++)
            {
                if (temporal.Length > lines[j].Length)
                {
                    if (temporal.Substring(0, lines[j].Length) == lines[j])
                    {
                        string answer = findSecondComponent(lines, temporal.Remove(0, lines[j].Length), milestones, temporal);
                        if (answer != "#") output.WriteLine(answer);
                    }
                }
            }
        }

        static string findSecondComponent(string[] lines, string temporal, List<Milestones> milestones, string answer)
        {
            int current_range_start, current_range_end,i=0;
            while (milestones[i].getLetter() != temporal[0])
            {
                i++;
                if (i == milestones.Count) break;
            }
            if (i < milestones.Count)
            {
                current_range_start = milestones[i - 1].getIndex();
                current_range_end = milestones[i].getIndex();
                for (int j = current_range_start; j < current_range_end; j++)
                {
                    if (temporal ==lines[j])
                    {
                        return answer;
                    }
                }
            }
            return "#";
        }
    }
}
