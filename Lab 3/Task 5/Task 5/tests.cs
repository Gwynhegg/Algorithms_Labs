using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_5
{
    class tests
    {
        StreamWriter input;
        StreamWriter data;
        public tests(){
            input = new StreamWriter("input.txt");
            data = new StreamWriter("temp.txt");
            Random rnd = new Random();
            int number_of_strings = 20;
            string test_data;
            for (int i = 0; i < number_of_strings; i++)
            {
                test_data = "";
                int string_length = rnd.Next(1, 50);
                for (int j = 0; j < string_length; j++)
                {
                    test_data += (char)rnd.Next(97, 122);
                }
                input.WriteLine(test_data);
                data.WriteLine(test_data);
            }
            input.Close();
            data.Close();
    } 
    }
}