using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence_Vol_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ivo's Longest Increasing Subsequence
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] prev = new int[numbers.Length];
            int[] lenghts = new int[numbers.Length];

            // 3 14 5 12 15 7 8 9 11 10 1
            // 1 2 2 3 4 3 5
            // Results:
            // 3 5 7 9 10

            int maxLength = 0;
            int maxIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                prev[i] = -1;
                lenghts[i] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[i] > numbers[j] && lenghts[i] <= lenghts[j] + 1)
                    {
                        lenghts[i] = lenghts[j] + 1;
                        prev[i] = j;
                    }
                }

                if (maxLength <= lenghts[i])
                {
                    maxLength = lenghts[i];
                    maxIndex = i;
                }
            }

            Stack<int> stack = new Stack<int>();

            while (maxIndex != -1)
            {
                stack.Push(numbers[maxIndex]);
                maxIndex = prev[maxIndex];
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
