using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            tests tests = new tests();
            StreamReader input_stream = new StreamReader("input.txt");
            StreamWriter output_stream = new StreamWriter("output.txt");
            Stopwatch stopWatch = new Stopwatch();
            int num_of_objects, num_of_request;
            List<int[]> tree;
            string[] input;
            while (!input_stream.EndOfStream)
            {
                input = input_stream.ReadLine().Split(' ');
                num_of_objects = Int32.Parse(input[0]);
                num_of_request = Int32.Parse(input[1]);
                tree = new List<int[]>();
                tree.Add(new int[num_of_objects]);
                for (int i = 0; i < num_of_objects; i++)
                {
                    tree[0][i] = Int32.Parse(input_stream.ReadLine());
                }
                stopWatch.Restart();
                fillTheTree(tree);
                for (int i = 0; i < num_of_request; i++)
                {
                    input = input_stream.ReadLine().Split(' ');
                    if (input[0] == "1") output_stream.WriteLine(sumRequest(tree, input)); else updateRequest(tree, input);
                }
                output_stream.WriteLine(stopWatch.Elapsed);
            }

            input_stream.Close();
            output_stream.Close();
        }

        static void fillTheTree(List<int[]> tree)
        {
            int current_num = (int)Math.Ceiling((decimal)tree[0].Length / 2);
            int current_level = 1;
            while (current_num != 1)
            {
                tree.Add(new int[current_num]);
                for (int i = 0; i < current_num; i++)
                {
                    if (i * 2 + 1 < tree[current_level - 1].Length) tree[current_level][i] = tree[current_level - 1][i * 2] + tree[current_level - 1][i * 2 + 1];
                    else tree[current_level][i] = tree[current_level - 1][i * 2];
                }
                current_level++;
                current_num = (int)Math.Ceiling((decimal)current_num / 2);
            }
            tree.Add(new int[1]);
            tree[current_level][0] = tree[current_level - 1][0] + tree[current_level - 1][1];
        }

        static long sumRequest(List<int[]> tree, string[] input)
        {
            long sum = 0;
            int left = Int32.Parse(input[1]);
            int right = Int32.Parse(input[2]);
            int starting_level = 0;
            while (left < right)
            {
                if (left % 2 != 0) sum += tree[starting_level][left++];
                if (right % 2 == 0) sum += tree[starting_level][right--];
                left /= 2; right /= 2;
                starting_level++;
            }
            for (int i=right;i<=left;i++) sum += tree[starting_level][i];
            return sum;
        }

        static void updateRequest(List<int[]> tree, string[] input)
        {
            int element_index = Int32.Parse(input[1]);
            int value = Int32.Parse(input[2]);
            int difference = tree[0][element_index] - value;
            for (int i = 0; i < tree.Count; i++)
            {
                tree[i][element_index] -= difference;
                element_index /= 2;
            }
        }
    }
}
