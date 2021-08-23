using System;
using System.Diagnostics;

namespace PermutationsSwap
{
    class Program
    {
        static int[] combinations = new int[] { 1, 2, 3 };

        static void Main(string[] args)
        {
            Permute(0, combinations);
        }

        private static void Permute(int index, int[] combinations)
        {
            if (index == combinations.Length)
            {
                Console.WriteLine(string.Join(' ', combinations));
                return;
            }

            for (int i = index; i < combinations.Length; i++)
            {
                combinations = Swap(combinations, index, i);
                Permute(index + 1, combinations);
                combinations = Swap(combinations, index, i);
            }

        }

        private static int[] Swap(int[] combinations, int index, int nextelement)
        {
            int temp = combinations[index];
            combinations[index] = combinations[nextelement];
            combinations[nextelement] = temp;
            return combinations;
        }
    }
}
