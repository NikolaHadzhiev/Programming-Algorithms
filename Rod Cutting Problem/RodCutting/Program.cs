using System;
using System.Linq;

namespace RodCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            Console.WriteLine($"Prices are: " +
                $"{string.Join(", ", prices.Select((x, i) => $"\n{i} meters => ${x}"))}");

            Console.Write("What would you like to sell?: ");

            int n = int.Parse(Console.ReadLine());


            int[] bestPrices = new int[prices.Length];
            int[][] bestPrevious = new int[prices.Length][];

            bestPrices[0] = 0;
            bestPrevious[0] = new int[] { 0, 0 };

            for (int i = 1; i <= 10; i++)
            {
                int max = bestPrices[i];
                bestPrevious[i] = new int[] { i, 1 };

                for (int j = 1; j <= i; j++)
                {
                    int current = prices[j] + prices[i - j];

                    if (current > max)
                    {
                        max = current;
                        bestPrevious[i] = new int[] { j, i - j };
                    }
                }

                bestPrices[i] = max;
            }

            Console.WriteLine($"You could sell it best for ${bestPrices[n]}.");
            Console.WriteLine($"You should split it in the following pieces: ${string.Join(", ", bestPrevious[n].Where(x => x > 0).Select(x => $"{x} metres"))}!");
        }
    }
}
