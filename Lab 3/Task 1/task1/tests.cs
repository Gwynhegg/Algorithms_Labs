using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class tests
    {
        private StreamWriter test_files;
        private Random rnd;
       public tests()
        {
            test_files = new StreamWriter("input.txt");
            rnd = new Random();
            CreateMinimalRange();
            CreateMinimals();
            CreateMinimalsAndPos();
            CreatePositives();
            CreateEqual();
            for (int i = 5; i < 8; i++)
            {
                CreateEasyTests(i);
            }
            for (int i = 1; i < 3;i++)
            {
                CreateRandom(i);
            }

            CreateMaximum();
            test_files.Close();
        }

        private void CreateEqual()
        {
            int N = rnd.Next(5, 10);
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(N + " ");
            test_files.WriteLine();
        }
        private void CreatePositives()
        {
            int N = rnd.Next(5, 10);
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(rnd.Next(1, 50) + " ");
            test_files.WriteLine();
        }
        private void CreateMinimalsAndPos()
        {
            int N = rnd.Next(5, 10);
            test_files.WriteLine(N);
            for (int i = 0; i < N - 1; i++) test_files.Write(rnd.Next(-50, -1) + " ");
            test_files.Write(rnd.Next(1, 10));
            test_files.WriteLine();
        }
        private void CreateMinimals()
        {
            int N = rnd.Next(5, 10);
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(rnd.Next(-50, -1) + " ");
            test_files.WriteLine();
        }
        private void CreateEasyTests(int modify)
        {
            int N = rnd.Next(modify,modify+5);
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(rnd.Next(-modify * 5, modify * 5) + " ");
            test_files.WriteLine();
        }
        private void CreateRandom(int modify)
        {
            int N = rnd.Next(modify*10, modify*20);
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(rnd.Next(-1000000, 1000000) + " ");
            test_files.WriteLine();
        }

        private void CreateMinimalRange()
        {
            int N = 3;
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(rnd.Next(-1000000, 1000000) + " ");
            test_files.WriteLine();
        }

        private void CreateMaximum()
        {
            int N = 1000000;
            test_files.WriteLine(N);
            for (int i = 0; i < N; i++) test_files.Write(rnd.Next(-1000000, 1000000) + " ");
            test_files.WriteLine();
        }
    }
}
