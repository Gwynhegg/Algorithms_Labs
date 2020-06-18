using System;
using System.IO;

namespace Task_1
{
    class tests
    {

        private StreamWriter data;
        private Random rnd;

        public tests()
        {
            data = new StreamWriter("input.txt");
            rnd = new Random();
            for (int i = 0; i < 3; i++) CreateChecked();
            for (int i = 0; i < 3; i++) CreateEasy();
            for (int i = 0; i < 3; i++) CreateHard();
            CreateMax();
            data.Close();
        }

        private void CreateChecked()
        {
            int key = rnd.Next(1, 20);
            int[] test_data = new int[5] { 6, 7, 8, 18, 20 };
            data.WriteLine(5 + " " + key);
            for (int i = 0; i < 5; i++) data.WriteLine(test_data[i]);
        }

        private void CreateEasy()
        {
            int key = rnd.Next(1, 50);
            int size = rnd.Next(1, 20);
            data.WriteLine(size + " " + key);
            for (int i = 0; i < size; i++) data.WriteLine(rnd.Next(1, 50));
        }

        private void CreateHard()
        {
            int key = rnd.Next(1, 100);
            int size = rnd.Next(1, 100);
            data.WriteLine(size + " " + key);
            for (int i = 0; i < size; i++) data.WriteLine(rnd.Next(1, 200));
        }

        private void CreateMax()
        {
            int key = rnd.Next(50000, 100000);
            int size = 100000;
            data.WriteLine(size + " " + key);
            for (int i = 0; i < size; i++) data.WriteLine(rnd.Next(1, 100000));
        }
    }
}