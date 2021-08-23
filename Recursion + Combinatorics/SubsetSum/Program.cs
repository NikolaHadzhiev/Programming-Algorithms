using System;
using System.Collections.Generic;

namespace SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 5, 1, 4, 2 };

            Dictionary<int, int> possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                HashSet<int> newSums = new HashSet<int>();

                foreach (var oldSum in possibleSums.Keys)
                {
                    newSums.Add(oldSum + numbers[i]);
                }

                foreach (var newSum in newSums)
                {
                    if (!possibleSums.ContainsKey(newSum))
                    {
                        possibleSums.Add(newSum, numbers[i]);
                    }
                }
            }

            int n = int.Parse(Console.ReadLine());
            int remaining = n;
            List<int> nums = new List<int>();

            while (remaining > 0)
            {
                nums.Add(possibleSums[remaining]);
                remaining -= possibleSums[remaining];
            }

            nums.Reverse();

            Console.WriteLine($"{n}: {string.Join(", ", nums)}");
        }
    }
}
