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
        StreamWriter data;
        Random rnd;

        public tests()
        {
            data = new StreamWriter("input.txt");
            rnd = new Random();

            createChecked();
            createEasy();
            createMedium();
            createHard();
            data.Close();
        }

        private void createChecked()
        {
            data.WriteLine(3 + " " + 4);
            data.WriteLine(9 + " " + 7 + " " + 1 + " " + 8);
            data.WriteLine(5 + " " + 7 + " " + 6 + " " + 3);
            data.WriteLine(5 + " " + 9 + " " + 8 + " " + 6);
        }

        private void createEasy()
        {
            int N = rnd.Next(2, 10);
            int M = rnd.Next(1, 100);
            int[] data_set = new int[M];
            int temp;
            data.WriteLine(N + " " + M);
            for (int i = 0; i < N; i++)
            {
                int j = 0;
                while (j < M)
                {
                    temp = rnd.Next(-2 * M, 2*M);
                    if (!data_set.Contains(temp))
                    {
                        data_set[j] = temp;
                        data.Write(temp + " ");
                        j++;
                    }
                }
                data.WriteLine();
            }
        }

        private void createMedium()
        {
            int N = rnd.Next(2, 100);
            int M = rnd.Next(500, 1000);
            int[] data_set = new int[M];
            int temp;
            data.WriteLine(N + " " + M);
            for (int i = 0; i < N; i++)
            {
                int j = 0;
                while (j < M)
                {
                    temp = rnd.Next(-2 * M, 2 * M);
                    if (!data_set.Contains(temp))
                    {
                        data_set[j] = temp;
                        data.Write(temp + " ");
                        j++;
                    }
                }
                data.WriteLine();
            }
        }

        private void createHard()
        {
            int N = 1000;
            int M = 1000;
            int[] data_set = new int[M];
            int temp;
            data.WriteLine(N + " " + M);
            for (int i = 0; i < N; i++)
            {
                int j = 0;
                while (j < M)
                {
                    temp = rnd.Next(-2*M, 2*M);
                    if (!data_set.Contains(temp))
                    {
                        data_set[j] = temp;
                        data.Write(temp + " ");
                        j++;
                    }
                }
                data.WriteLine();
            }
        }

    }
}
