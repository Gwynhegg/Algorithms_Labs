using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
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

        private void createChecked()
        {
            data_stream.WriteLine(8);
            data_stream.WriteLine("BCB");
            data_stream.WriteLine("ABA");
            data_stream.WriteLine("BCB");
            data_stream.WriteLine("BAA");
            data_stream.WriteLine("BBC");
            data_stream.WriteLine("BCB");
            data_stream.WriteLine("CBC");
            data_stream.WriteLine("CBC");


        }
        private void createHard()
        {
            string temp;
            int N = 10000;
            data_stream.WriteLine(N);
            string[] records = new string[N];
            for (int i = 0; i < N; i++)
            {
                temp = "";
                if (rnd.Next(10) == 1 && i != 0) temp = records[rnd.Next(i)]; else
                {
                    for (int j = 0; j < 1000; j++) temp += (char)rnd.Next(65, 91);
                }

                records[i] = temp;
                data_stream.WriteLine(temp);
            }
        }
        private void createMedium()
        {
            string temp;
            int N = rnd.Next(1000,2000);
            data_stream.WriteLine(N);
            string[] records = new string[N];
            for (int i = 0; i < N; i++)
            {
                temp = "";
                if (rnd.Next(10) == 1 && i != 0) temp = records[rnd.Next(i)];
                else
                {
                    for (int j = 0; j < 500; j++) temp += (char)rnd.Next(65, 91);
                }

                records[i] = temp;
                data_stream.WriteLine(temp);
            }
        }
        private void createEasy()
        {
            string temp;
            int N = 20;
            data_stream.WriteLine(N);
            string[] records = new string[N];
            for (int i = 0; i < N; i++)
            {
                temp = "";
                if (rnd.Next(10) == 1 && i != 0) temp = records[rnd.Next(i)];
                else
                {
                    for (int j = 0; j < 10; j++) temp += (char)rnd.Next(65, 91);
                }

                records[i] = temp;
                data_stream.WriteLine(temp);
            }
        }
    }
}
