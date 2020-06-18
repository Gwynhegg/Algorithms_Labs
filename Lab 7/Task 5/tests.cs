using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
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
            createCheckedv2();
            createMedium();
            createHard();
            data_stream.Close();
        }

        private void createChecked()
        {
            data_stream.WriteLine("5 5");
            data_stream.WriteLine("1 0 7 -8 2");
            data_stream.WriteLine("2 7 -5 3 1");
            data_stream.WriteLine("6 -8 4 2 1");
            data_stream.WriteLine("-7 3 1 -2 1");
            data_stream.WriteLine("2 7 4 0 -50");

        }

        private void createCheckedv2()
        {
            data_stream.WriteLine("5 5");
            data_stream.WriteLine("10 -1 -1 7 -3");
            data_stream.WriteLine("-6 -6 5 7 -6");
            data_stream.WriteLine("8 -2 1 5 6");
            data_stream.WriteLine("-1 -2 -3 -8 1");
            data_stream.WriteLine("-9 -9 5 6 -1");
        }

        private void createMedium()
        {
            int N = rnd.Next(50, 100); int K = rnd.Next(50, 100);
            data_stream.WriteLine(N + " " + K);
            int[] temp = new int[K];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    temp[j] = rnd.Next(-1000, 1000);
                }
                data_stream.WriteLine(String.Join(" ", temp));
            }
        }

        private void createHard()
        {
            int N = rnd.Next(300, 500); int K = rnd.Next(300, 500);
            data_stream.WriteLine(N + " " + K);
            int[] temp = new int[K];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    temp[j] = rnd.Next(-1000, 1000);
                }
                data_stream.WriteLine(String.Join(" ", temp));
            }
        }
    }
}
