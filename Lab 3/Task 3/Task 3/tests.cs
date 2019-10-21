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
        StreamWriter tests_file;
        Random rnd;

        public tests()
        {
            tests_file = new StreamWriter("input.txt");
            rnd = new Random();
            createTest();
            tests_file.Close();
        }

       private void createTest()
        {
            int N =rnd.Next(1, 100);
            tests_file.WriteLine(N);
            for (int i = 0; i < N; i++)
            {
                tests_file.WriteLine(rnd.Next(1, 50) + " " + rnd.Next(1, 20));
            }
        }
    }
}
