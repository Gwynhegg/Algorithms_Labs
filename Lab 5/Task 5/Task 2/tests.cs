using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
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
            createEasy();
            createMedium();
            createHard();
            data_stream.Close();
        }

        private void createHard()
        {
            int N = rnd.Next(5000, 10000);
            data_stream.WriteLine(rnd.Next(1000, 2000) + " " + N);
            for (int i = 0; i < N; i++) data_stream.WriteLine(rnd.Next(10000));
        }
        private void createMedium()
        {
            int N = rnd.Next(500, 1000);
            data_stream.WriteLine(rnd.Next(1000,2000) + " " + N);
            for (int i = 0; i < N; i++) data_stream.WriteLine(rnd.Next(10000));
        }
        private void createEasy()
        {
            data_stream.WriteLine(10 + " " + 30);
            for (int i = 0; i < 30; i++) data_stream.WriteLine(rnd.Next(1, 30));
        }

        private void createChecked()
        {
            data_stream.WriteLine("5 15");
            int[] output = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 7, 9, 3 };
            foreach (int e in output) data_stream.WriteLine(e);
        }
    }
}
