using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {

            //Реализация с помощью разбиения числа на сегменты
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();

            /*
            string numerator = input_stream.ReadLine();
            input_stream.ReadLine();
            string denumerator = input_stream.ReadLine();
            bool is_negative = false;
            Console.WriteLine(Multiplication(denumerator, "111"));
            */
            stopWatch.Start();
            BigInteger numerator = BigInteger.Parse(Console.ReadLine());
            BigInteger denumerator = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(numerator / denumerator);
            Console.WriteLine(stopWatch.Elapsed);
            Console.ReadKey();
        }
        static bool FirstisBigger(string first_number, string second_number)
        {
            if (first_number.Length > second_number.Length)
            {
                string temp = new string('0', first_number.Length - second_number.Length);
                second_number = temp + second_number;
            }
            else
            {
                string temp = new string('0', second_number.Length - first_number.Length);
                first_number = temp + first_number;
            }
            bool flag = true;
            bool first_is_bigger = true;
            int index = 0;
            while (flag && index < first_number.Length)
            {
                if (first_number[index] > second_number[index])
                {
                    flag = false;
                }
                else if (first_number[index] < second_number[index])
                {
                    flag = false;
                    first_is_bigger = false;
                }
                else index++;
            }
            return first_is_bigger;
        }

        static string Multiplication(string number, string multiplier)
        {
            string result = ""; ;
            int rest, temp;
            for (int j = multiplier.Length - 1; j >= 0; j--)
            {
                 result = "";
                 rest = 0;
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    temp = Byte.Parse(number[i].ToString()) * Byte.Parse(multiplier[j].ToString()) + rest;
                    result = temp % 10 + result;
                    rest = temp / 10;
                }
                result = rest + result;
                Console.WriteLine(result);
            }

            return "";
        }

    }
}
