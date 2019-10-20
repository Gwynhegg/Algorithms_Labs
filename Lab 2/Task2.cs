using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            StreamReader input_stream = new StreamReader("input.txt");
            string first_number = input_stream.ReadLine();
            string operand = input_stream.ReadLine();
            string second_number = input_stream.ReadLine();
            input_stream.Close();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool first_is_positive = true,second_is_positive=true;
            //Для начала сведем все необходимые операции к сумме. Для этого в случае вычитания изменим знак второго числа на противоположный
            if (operand == "-" && second_number[0] == '-') second_number = second_number.Remove(0, 1);
            else if (operand == "-" && second_number[0] != '-') second_number = "-" + second_number;

            //Для сравнивания чисел по модулю удалим префиксные знаки, если они есть, и запомним их отдельно в логических переменных
            if (first_number[0] == '-') {
                first_number = first_number.Remove(0, 1);
                first_is_positive = false;
            }
            if (second_number[0] == '-') {
                second_number = second_number.Remove(0, 1);
                second_is_positive = false;
            }

            //Если количество знаков в числах разное, то уравниваем их нулями для облегчения последующих вычислений
            if (first_number.Length > second_number.Length)
            {
                string temp = new string('0', first_number.Length - second_number.Length);
                second_number = temp + second_number;
            } else
            {
                string temp = new string('0', second_number.Length - first_number.Length);
                first_number = temp + first_number;
            }

            //Сравниваем два числа по модулю. Меняем их местами таким образом, чтобы большее всегда было первым слагаемым для облегчения последующих вычислений
            if (!FirstisBigger(first_number, second_number))
            {
                string temp = first_number;
                first_number = second_number;
                second_number = temp;
                bool temp1 = first_is_positive;
                first_is_positive = second_is_positive;
                second_is_positive = temp1;
            }
            StreamWriter output_stream = new StreamWriter("output.txt");
            //Теперь, когда все сведено к сумме и числа расставлены в удобном порядке, начинаем вычисления.
            //Если первое и второе - положительные числа, то просто суммируем их  и выводим ответ
            if (first_is_positive && second_is_positive) output_stream.WriteLine(Summarize(first_number, second_number));

            //Если первое положительно, а второе - отрицательно, то производим обычное вычитание
            if (first_is_positive && !second_is_positive) output_stream.WriteLine(Subtractize(first_number, second_number));

            //Если первое отрицательно, а второе положительно, то производим вычитание и приписываем - к ответу
            if (!first_is_positive && second_is_positive) output_stream.WriteLine("-" + Subtractize(first_number, second_number));

            //Если оба числа отрицательны, то производим сумму и приписываем - к ответу
            if (!first_is_positive && !second_is_positive) output_stream.WriteLine("-" + Summarize(first_number, second_number));
            stopWatch.Stop();
            output_stream.WriteLine(stopWatch.Elapsed);
            output_stream.Close();
        }


        static bool FirstisBigger(string first_number, string second_number)
        {
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

        static string Subtractize(string first_number, string second_number)
            {
            string result = "";
            byte rank = 0;
            byte temp1, temp2;
            int first_index = first_number.Length - 1;
            while (first_index >= 0)
            {
                temp1 = Byte.Parse(first_number[first_index].ToString());
                temp2 = Byte.Parse(second_number[first_index].ToString());
                if (temp1-rank-temp2<0)
                {
                    result = (10 + temp1 - rank - temp2) + result;
                    rank = 1;
                } else
                {
                    result = (temp1 - rank - temp2) + result;
                    rank = 0;

                }
                first_index--;
            }
            result = result.TrimStart('0');
            if (result != "") return result; else return "0";
        }

        static string Summarize(string first_number,string second_number)
        {
            int remainder = 0;
            string result="";
            byte temp1, temp2;
            int first_index = first_number.Length - 1;
            while (first_index>=0)
            {
                temp1 = Byte.Parse(first_number[first_index].ToString());
                temp2 = Byte.Parse(second_number[first_index].ToString());
                if (temp1 + temp2 + remainder > 9)
                {
                    result = (temp1 + temp2 + remainder)%10 + result;
                    remainder = 1;
                } else
                {
                    result = (temp1 + temp2 + remainder)  + result;
                    remainder = 0;
                }
                first_index--;
            }
            if (remainder != 0) result = remainder + result;
            result = result.TrimStart('0');
            if (result != "") return result; else return "0";
        }
    }
}
