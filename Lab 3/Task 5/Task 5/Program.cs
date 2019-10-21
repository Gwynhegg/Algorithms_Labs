using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task_5
{
    class Program
    {
        static bool global_flag=true;
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            tests new_tests = new tests();
            StreamWriter output_stream;
            stopWatch.Start();
            StreamReader input_stream;
            List<string> buffer = new List<string>();
            while (global_flag)
            {
                global_flag = false;
                buffer.Clear();
                output_stream = new StreamWriter("output.txt");
                input_stream = new StreamReader("input.txt");
                while (!input_stream.EndOfStream)
                {
                    string temp = input_stream.ReadLine();
                    if (buffer.Count == 0) buffer.Add(temp);
                    else if (buffer.Count == 1)
                    {
                        buffer.Add(temp);
                        FindMax(buffer);
                    }
                    else
                    {
                        Operate(output_stream, buffer, temp);
                    }
                }                
                output_stream.WriteLine(buffer[1]);
                output_stream.WriteLine(buffer[0]);

                if (global_flag)
                {
                    output_stream.Close();
                    input_stream.Close();
                    output_stream = new StreamWriter("input.txt");
                    input_stream = new StreamReader("output.txt");
                    output_stream.WriteAsync(input_stream.ReadToEnd());
                    output_stream.Close();
                    input_stream.Close();
                } else
                {
                    input_stream.Close();
                    stopWatch.Stop();
                    output_stream.WriteLine(stopWatch.Elapsed);
                    output_stream.Close();
                }

                Console.WriteLine("Waiting");
            }
            Console.WriteLine("THATSALL");
            Console.ReadKey();
            }

        static void FindMax(List<string> buffer)
        {
            int n = Math.Min(buffer[0].Length, buffer[1].Length);
            bool flag = true;
            int i = 0;
            while (i<n && flag)
            {
                if (buffer[0][i] < buffer[1][i])
                {
                    string temp = buffer[0];
                    buffer[0] = buffer[1];
                    buffer[1] = temp;
                    flag = false;
                }
                else if (buffer[0][i] > buffer[1][i])
                {
                    global_flag = true;
                    flag = false;
                }
                i++;
            }
        }
        static void Operate(StreamWriter fstream, List<string> buffer, string temp)
        {
            int n = Math.Min(buffer[0].Length, temp.Length);
            bool bigger_than_first = true;
            for (int i = 0; i < n; i++)
            {
                if (buffer[0][i] > temp[i])
                {
                    bigger_than_first = false;
                    break;
                }
                else if(buffer[0][i] < temp[i]) break;
            }
            bool bigger_than_second = true;
            n = Math.Min(buffer[1].Length, temp.Length);
            for (int i = 0; i < n; i++)
            {
                if (buffer[1][i] > temp[i])
                {
                    bigger_than_second = false;
                    break;
                }
                else if (buffer[1][i] < temp[i]) break;
            }
            if (!bigger_than_first && bigger_than_second)
            {
                fstream.WriteAsync(buffer[1]+ "\n");
                buffer[1] = temp;
                global_flag = true;
            }
            else if (!bigger_than_first && !bigger_than_second)
            {
                fstream.WriteAsync(temp + "\n");
                global_flag = true;
            }
            else
            {
                fstream.WriteAsync(buffer[1] + "\n");
                buffer[1] = buffer[0];
                buffer[0] = temp;
            }
        }
        }
    }
