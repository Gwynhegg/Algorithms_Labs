using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            tests new_test = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");

            int N=0, K, M, L;
            int[] a;
            Stopwatch stopWatch = new Stopwatch();

            while (input_stream.EndOfStream == false)
            {
                string[] input = input_stream.ReadLine().Split(' ');
                N = Int32.Parse(input[0]); K = Int32.Parse(input[1]); M = Int32.Parse(input[2]); L = Int32.Parse(input[3]);
                Console.WriteLine("Current test:" + N);
                a = new Int32[N];
                a[0] = K;
                for (UInt32 i = 0; i < N - 1; i++)
                {
                a[i + 1] = (Int32) ((a[i] * (long)M)&0xFFFFFFFFU)% L;
                }
                stopWatch = new Stopwatch();
                QuickSort(a, 0, N-1);
                stopWatch.Restart();
                output_stream.WriteLine(Summarize(a));
                stopWatch.Stop();
                output_stream.WriteLine(stopWatch.Elapsed);
            }
            input_stream.Close();
            output_stream.Close();
        }

        static long Summarize(int[] a)
        {
            long sum=0;
            for (int i = 0; i < a.Length; i += 2)
            {
                sum += a[i];
            }
            return sum;
        }
        static Int32 Partition(Int32[] array, Int32 start, Int32 end)
        { 
            Int32 temp;
            Int32 marker = start;
            for (Int32 i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        static void QuickSort(Int32[] array, Int32 start, Int32 end)
        {
            if (start >= end)
            {
                return;
            }
            Int32 pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

    }
}
