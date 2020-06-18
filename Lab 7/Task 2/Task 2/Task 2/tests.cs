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
            createCheckedv2();
            createMedium();
            createHard();
            data_stream.Close();
        }

        private void createChecked()
        {
            data_stream.WriteLine("5 4");
            data_stream.WriteLine("1 7 4 3");
            data_stream.WriteLine("5 1 6 7");
            data_stream.WriteLine("4 1 9 2");
            data_stream.WriteLine("7 3 7 5");
            data_stream.WriteLine("8 2 4 1");
        }

        private void createCheckedv2()
        {
            data_stream.WriteLine("5 6");
            data_stream.WriteLine("3 4 6 2 8 6");
            data_stream.WriteLine("6 1 8 2 7 4");
            data_stream.WriteLine("5 9 3 9 9 5");
            data_stream.WriteLine("8 4 1 3 9 6");
            data_stream.WriteLine("3 7 2 8 6 4");
        }

        private void createHard()
        {
            int N = rnd.Next(100, 150); int K = rnd.Next(500, 1000);
            data_stream.WriteLine(N + " " + K);
            int[][] data = new int[N][];
            for (int i = 0; i < N; i++)
            {
                data[i] = new int[K];
                for (int j = 0; j < K; j++)
                {
                    data[i][j] = rnd.Next(-1000, 1000);
                }
                data_stream.WriteLine(String.Join(" ", data[i]));
            }

        }
        private void createMedium()
        {
            int N = rnd.Next(30, 50); int K = rnd.Next(100, 200);
            data_stream.WriteLine(N + " " + K);
            int[][] data = new int[N][];
            for (int i=0;i<N;i++)
            {
                data[i] = new int[K];
                for (int j = 0; j < K; j++)
                {
                    data[i][j] = rnd.Next(-500, 500);
                }
                data_stream.WriteLine(String.Join(" ", data[i]));
            }

        }
    }
}
