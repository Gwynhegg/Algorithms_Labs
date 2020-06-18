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
        StreamWriter test_data;
        Random rnd;
        public tests()
        {
            test_data = new StreamWriter("input.txt");
            rnd = new Random();
            createEasy_v1();
            CreateEasy_v2();
            createEasy();
            CreateMedium();
            createMax();
            test_data.Close();
        }

        private void createEasy()
        {
            int num = rnd.Next(5, 10);
            string[] data = new string[num+5];
            string temp;
            test_data.WriteLine(num+5);
            for (int i = 0; i < num; i++)
            {
                temp = "";
                int string_size = rnd.Next(5, 10);
                for (int j = 0; j < string_size; j++) temp += (char)rnd.Next(65, 90);
                if (data.Contains(temp)) i--; else data[i] = temp;
            }
            for (int i = num; i < num+5; i++) data[i] = data[rnd.Next(num)] + data[rnd.Next(num)];
            for (int i = 0; i < num+5; i++) test_data.WriteLine(data[i]);
        }
        private void createMax()
        {
            int num = rnd.Next(700, 800);
            string[] data = new string[1000];
            string temp;
            test_data.WriteLine(1000);
            for (int i = 0; i < num; i++)
            {
                temp = "";
                int string_size = rnd.Next(400, 500);
                for (int j = 0; j < string_size; j++) temp += (char)rnd.Next(65, 90);
                if (data.Contains(temp)) i--; else data[i] = temp;
            }
            for (int i = num; i < 1000; i++) data[i] = data[rnd.Next(num)] + data[rnd.Next(num)];
            for (int i = 0; i < 1000; i++) test_data.WriteLine(data[i]);
        }
        private void createEasy_v1()
        {
            test_data.WriteLine(5);
            string[] data = new string[5] {"A","AB","B","AA","ABC" };
            for (int i = 0; i < 5; i++) test_data.WriteLine(data[i]);
        }

        private void CreateEasy_v2()
        {
            test_data.WriteLine(10);
            string[] data = new string[10] {"ABC","DEFG","AB","ABCAB","DEFGA","FG","ABFG","ABCAFG","FGFG","ABABC" };
            for (int i = 0; i < 10; i++) test_data.WriteLine(data[i]);
        }

        private void CreateMedium()
        {
            int num = rnd.Next(50,100);
            test_data.WriteLine(num+10);
            string[] data = new string[num+10];
            string temp;
            for (int i = 0; i < num; i++)
            {
                temp = "";
                int string_size = rnd.Next(1, 20);
                for (int j = 0; j < string_size; j++) temp += (char)rnd.Next(65, 90);
                if (data.Contains(temp)) i--; else data[i] = temp;
            }
            for (int i = num; i < num + 10; i++) data[i] = data[rnd.Next(num)] + data[rnd.Next(num)];
            for (int i = 0; i < num + 10; i++) test_data.WriteLine(data[i]);
        }
    }
}
