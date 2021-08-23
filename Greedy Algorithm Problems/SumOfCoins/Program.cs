using System;
using System.Collections;

namespace SumOfCoins
{
    class Program
    {
        static int finalSum = 18;
        static int currentSum = 0;
        static int[] coins = { 10, 10, 5, 5, 2, 2, 1, 1 };
        static Queue result = new Queue();

        static void Main(string[] args)
        {
            GreedySum();
        }

        private static void GreedySum()
        {
            for (int i = 0; i < coins.Length; i++)
            {
                if (currentSum + coins[i] > finalSum)
                {
                    continue;
                }

                currentSum += coins[i];
                result.Enqueue(coins[i]);

                if (currentSum == finalSum)
                {
                    foreach (var item in result)
                    {
                        Console.Write(string.Join(' ', item) + " ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
