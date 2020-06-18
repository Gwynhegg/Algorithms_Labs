using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class tests
    {
        Random rnd;
        StreamWriter data_stream;

        public tests()
        {
            data_stream = new StreamWriter("input.txt");
            rnd = new Random();
            createChecked();
            createEasy();
            createMedium();
            createHard();
            createMax();
            data_stream.Close();
        }
        private void createMax()
        {
            int n1 = 500000, n2 = 500000;
            data_stream.WriteLine(n1 + " " + n2);
            for (int i = 0; i < n1; i++) data_stream.WriteLine(rnd.Next(10000));
            for (int i = 0; i < n2; i++)
            {
                int start = rnd.Next(n1);
                if (rnd.Next(1, 2) == 1) data_stream.WriteLine("1 " + start + " " + (start + rnd.Next(n1 - start)));
                else data_stream.WriteLine("2 " + start + " " + rnd.Next(10000));
            }
        }
        private void createHard()
        {
            int n1 = rnd.Next(50000, 100000), n2 = rnd.Next(50000, 100000);
            data_stream.WriteLine(n1 + " " + n2);
            for (int i = 0; i < n1; i++) data_stream.WriteLine(rnd.Next(100000));
            for (int i = 0; i < n2; i++)
            {
                int start = rnd.Next(n1);
                if (rnd.Next(1, 2) == 1) data_stream.WriteLine("1 " + start + " " + (start + rnd.Next(n1 - start)));
                else data_stream.WriteLine("2 " + start + " " + rnd.Next(100000));
            }
        }

        private void createMedium()
        {
            int n1 = rnd.Next(5000, 10000), n2 = rnd.Next(5000, 10000);
            data_stream.WriteLine(n1 + " " + n2);
            for (int i = 0; i < n1; i++) data_stream.WriteLine(rnd.Next(10000));
            for (int i = 0; i < n2; i++)
            {
                int start = rnd.Next(n1);
                if (rnd.Next(1, 2) == 1) data_stream.WriteLine("1 " + start + " " + (start + rnd.Next(n1 - start)));
                else data_stream.WriteLine("2 " + start + " " + rnd.Next(10000));
            }
        }
        private void createEasy()
        {
            int n1 = rnd.Next(50, 100), n2 = rnd.Next(50, 100);
            data_stream.WriteLine(n1 + " " + n2);
            for (int i = 0; i < n1; i++) data_stream.WriteLine(rnd.Next(100));
            for (int i = 0; i < n2; i++)
            {
                int start = rnd.Next(n1);
                if (rnd.Next(1, 2) == 1) data_stream.WriteLine("1 " + start + " " + (start + rnd.Next(n1 - start)));
                else data_stream.WriteLine("2 " + start + " " + rnd.Next(100));
            }
        }
        private void createChecked()
        {
            data_stream.WriteLine("10 8");
            data_stream.WriteLine("1");
            data_stream.WriteLine("7");
            data_stream.WriteLine("15");
            data_stream.WriteLine("8");
            data_stream.WriteLine("9");
            data_stream.WriteLine("15");
            data_stream.WriteLine("15");
            data_stream.WriteLine("19");
            data_stream.WriteLine("5");
            data_stream.WriteLine("19");
            data_stream.WriteLine("1 1 8");
            data_stream.WriteLine("1 6 8");
            data_stream.WriteLine("1 0 6");
            data_stream.WriteLine("2 6 6");
            data_stream.WriteLine("2 1 6");
            data_stream.WriteLine("2 0 9");
            data_stream.WriteLine("1 4 7");
            data_stream.WriteLine("1 3 6");


        }
    }
}
