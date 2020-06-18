using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            string command;
            string[] parsed_command;
            while (!input_stream.EndOfStream)
            {

                stopWatch.Restart();
                command = input_stream.ReadLine();
                Dictionary<string, string> phone_book = new Dictionary<string, string>();
                for (int i = 0; i <= Int32.Parse(command); i++)
                {
                    try
                    {
                        parsed_command = input_stream.ReadLine().Split(' ');
                        if (parsed_command[0] == "ADD") phone_book.Add(parsed_command[1], parsed_command[2]);
                        else if (parsed_command[0] == "PRINT") output_stream.WriteLine(parsed_command[1] + " " + phone_book[parsed_command[1]]);
                        else if (parsed_command[0] == "DELETE") phone_book.Remove(parsed_command[1]);
                        else if (parsed_command[0] == "EDITHPHONE") phone_book[parsed_command[1]] = parsed_command[2];
                        else output_stream.WriteLine("ERROR");
                    }
                    catch
                    {
                        output_stream.WriteLine("ERROR");
                    }
                }
                output_stream.WriteLine(stopWatch.Elapsed);        
            }
            input_stream.Close();
            output_stream.Close();
        }
    }
}
