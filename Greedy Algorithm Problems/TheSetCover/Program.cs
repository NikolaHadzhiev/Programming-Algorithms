using System;
using System.Collections.Generic;

namespace TheSetCover
{
    class Program
    {

        static int GetCountOfUncoveredElements(HashSet<int> uncovered, int[] subset)
        {
            int count = 0;
            for (int i = 0; i < subset.Length; i++)
            {
                if (uncovered.Contains(subset[i]))
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            int[] universe = new int[] { 1, 2, 3, 4, 5, 6 };
            int[][] set = {
                    new int[]{1, 3},
                    new int[]{1 },
                    new int[]{2, 4},
                    new int[]{2, 5},
                    new int[]{2, 3, 6},
                    new int[]{4, 6},
                    new int[]{4, 5, 6},
                    new int[]{6 },

            };
            HashSet<int> uncovered = new HashSet<int>(universe);
            List<int[]> results = new List<int[]>();

            while (uncovered.Count > 0)
            {
                int currentMaxUncovered = GetCountOfUncoveredElements(uncovered, set[0]);
                int currentMaxUncoveredIndex = 0;
                for (int i = 1; i < set.Length; i++)
                {
                    int currentUncovered = GetCountOfUncoveredElements(uncovered, set[i]);
                    if (currentUncovered >= currentMaxUncovered)
                    {
                        currentMaxUncovered = currentUncovered;
                        currentMaxUncoveredIndex = i;
                    }
                }
                results.Add(set[currentMaxUncoveredIndex]);

                for (int i = 0; i < set[currentMaxUncoveredIndex].Length; i++)
                {
                    uncovered.Remove(set[currentMaxUncoveredIndex][i]);
                }
            }

            results.ForEach(r => Console.WriteLine($"{{{string.Join(", ", r)}}}"));
        }
    }
}
