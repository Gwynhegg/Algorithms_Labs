using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    class tests
    {

        Random rnd;
        StreamWriter test_file;
        public tests()
        {
            rnd = new Random();
            test_file = new StreamWriter("input.txt");
                CreateSimple();
                CreateEasy();
            for (int i = 0; i < 2; i++)
            {
                CreateHard(i);
            }
            test_file.Close();
        }

        private void CreateSimple()
        {
            test_file.WriteLine("5 7 13 100");
        }
        private void CreateMaximum()
        {
            test_file.Write("60000000 4294967295 4294967295 4294967295");
        }
        private void CreateEasy()
        {
            long N = rnd.Next(5, 10), K=rnd.Next(3,10),M=rnd.Next(5,20),L=rnd.Next(2,100);
            test_file.WriteLine(N + " " + K + " " + M + " " + L);
        }

        private void CreateHard(int modifier)
        {
            long N = rnd.Next(modifier * 100 + 1, 5000), K = rnd.Next(modifier * 100 + 1, 5000), M = rnd.Next(modifier * 100 + 1, 5000), L = rnd.Next(1,100);
            test_file.WriteLine(N + " " + K + " " + M + " " + L);
        }
    }
    }
