using System;
using System.Linq;

namespace SumOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(SumArray(arr, arr.Length));
        }

        private static int SumArray(int[] arr, int length)
        {
            if (length <= 0)
            {
                return 0;
            }

            return SumArray(arr, length - 1) + arr[length - 1];
        }
    }
}
