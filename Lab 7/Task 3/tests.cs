using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class tests
    {
        StreamWriter data_stream;
        Random rnd;
        public tests()
        {
            data_stream = new StreamWriter("input.txt");
            rnd = new Random();
            createChecked();
            createMedium();
            createHard();
            data_stream.Close();
        }

        private void createChecked()
        {
            data_stream.WriteLine("ubrashvabracadabra");
            data_stream.WriteLine("calamburashabratha");
        }

        private void createHard()
        {
            string first = "", second = "";
            int first_length = rnd.Next(1000, 2000), second_length = rnd.Next(1000, 2000);
            for (int i = 0; i < first_length; i++) first += (char)rnd.Next(97, 122);
            for (int j = 0; j < second_length; j++) second += (char)rnd.Next(97, 122);
            data_stream.WriteLine(first);
            data_stream.WriteLine(second);
        }
        private void createMedium()
        {
            string first="", second="";
            int first_length = rnd.Next(100, 200), second_length = rnd.Next(100, 200);
            for (int i = 0; i < first_length; i++) first += (char)rnd.Next(97, 122);
            for (int j = 0; j < second_length; j++) second += (char)rnd.Next(97, 122);
            data_stream.WriteLine(first);
            data_stream.WriteLine(second);
        }
    }
}
