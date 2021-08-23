using System;
using System.Diagnostics;

namespace Permutations
{
    class Program
    {
        static int[] combinations = new int[3];
        static bool[] used = new bool[combinations.Length];

        static void Main(string[] args)
        {
            Permute(0, combinations, used);
        }

        static void Permute(int index, int[] combinations, bool[] used)
        {
            if (index == combinations.Length)
            {
                Print();
                return;
            }

            for (int i = 0; i < combinations.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    combinations[index] = i + 1;
                    Permute(index + 1, combinations, used);
                    used[i] = false;
                }
            }

        }

        private static void Print()
        {
            Console.WriteLine(string.Join(' ', combinations));
        }
    }
}
