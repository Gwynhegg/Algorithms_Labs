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
        Random rnd;
        StreamWriter data_stream;

        public tests()
        {
            data_stream = new StreamWriter("input.txt");
            rnd = new Random();
            createCheckedv1();
            createCheckedv2();
            createMedium();
            data_stream.Close();
        }

        private void createMedium()
        {
            int N=rnd.Next(500,1000), M = rnd.Next(100,200),K=rnd.Next(500,1000);
            data_stream.WriteLine(N + " " + M + " " + K);
            string[] records = new string[N];
            string[] temp=new string[M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++) temp[j] = rnd.Next(10000).ToString();
                records[i] = String.Join(" ",temp);
                data_stream.WriteLine(String.Join(" ", temp));
            }
            for (int i = 0; i < K; i++)
            {
                if (rnd.Next(10) == 1) data_stream.WriteLine(String.Join(" ", records[rnd.Next(N)])); else
                {
                    for (int j = 0; j < M; j++) temp[j] = rnd.Next(10000).ToString();
                    data_stream.WriteLine(String.Join(" ", temp));
                }
            }
        }
        private void createCheckedv1()
        {
            data_stream.WriteLine("10 3 5");
            data_stream.WriteLine("6 5 1");
            data_stream.WriteLine("7 9 3");
            data_stream.WriteLine("2 3 2");
            data_stream.WriteLine("7 2 9");
            data_stream.WriteLine("9 6 2");
            data_stream.WriteLine("6 6 6");
            data_stream.WriteLine("9 4 1");
            data_stream.WriteLine("8 4 4");
            data_stream.WriteLine("8 3 2");
            data_stream.WriteLine("1 2 6");
            data_stream.WriteLine("9 7 2");
            data_stream.WriteLine("1 6 5");
            data_stream.WriteLine("3 7 7");
            data_stream.WriteLine("4 4 6");
            data_stream.WriteLine("3 9 7");
        }

        private void createCheckedv2()
        {
            data_stream.WriteLine("10 7 5");
            data_stream.WriteLine("8 4 0 3 6 9 2");
            data_stream.WriteLine("3 5 0 4 3 1 1");
            data_stream.WriteLine("7 1 0 3 1 2 4");
            data_stream.WriteLine("7 1 5 1 5 5 1");
            data_stream.WriteLine("3 4 0 0 3 4 0");
            data_stream.WriteLine("3 3 3 6 3 9 3");
            data_stream.WriteLine("3 4 1 3 1 8 1");
            data_stream.WriteLine("1 1 6 8 6 8 2");
            data_stream.WriteLine("5 6 8 1 3 9 3");
            data_stream.WriteLine("7 5 7 1 4 0 3");
            data_stream.WriteLine("1 1 3 3 8 4 1");
            data_stream.WriteLine("2 1 1 6 6 8 8");
            data_stream.WriteLine("1 1 5 7 5 1 5");
            data_stream.WriteLine("3 4 1 3 1 1 8");
            data_stream.WriteLine("0 0 1 2 8 2 6");

        }
    }
}
