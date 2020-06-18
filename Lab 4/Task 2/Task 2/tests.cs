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

        StreamWriter data;
        Random rnd;

        public tests()
        {
            data = new StreamWriter("input.txt");
            rnd = new Random();
            CreateChecked();
            CreateChecked_v2();
            CreateEasy();
            CreateMedium();
            CreateMax();
            data.Close();
        }

        private void CreateMax()
        {
            int n = 20000;
            data.WriteLine(n);
            for (int i = 0; i < n; i++) data.Write(rnd.Next(1, 100000) +" ");
            data.WriteLine();
        }

        private void CreateMedium()
        {
            int n = rnd.Next(1, 100);
            data.WriteLine(n);
            for (int i = 0; i < n; i++) data.Write(rnd.Next(1, 1000) + " ");
            data.WriteLine();
        }

        private void CreateEasy()
        {
            int n = rnd.Next(1, 10);
            data.WriteLine(n);
            for (int i = 0; i < n; i++) data.Write(rnd.Next(1, 100) + " ");
            data.WriteLine();
        }
        private void CreateChecked()
        {
            int[] capitals = new int[5] { 1, 2, 3, 4, 5 };
            data.WriteLine(5);
            for (int i = 0; i < 5; i++) data.Write(capitals[i] + " ");
            data.WriteLine();
        }

        private void CreateChecked_v2()
        {
            int[] capitals = new int[10] {2,10,100,30,7,4,15,2,15,80};
            data.WriteLine(10);
            for (int i = 0; i < 10; i++) data.Write(capitals[i] + " ");
            data.WriteLine();
        }
    }
}
