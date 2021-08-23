using System;
using System.Collections.Generic;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] changes = new int[n];
            bool[] contained = new bool[10000];
            string[] unparsedChanges = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                changes[i] = int.Parse(unparsedChanges[i]);
            }

            int initialSpeed = int.Parse(Console.ReadLine());
            int maximumSpeed = int.Parse(Console.ReadLine());

            LinkedList<int> possibleSums = new LinkedList<int>(new int[] { initialSpeed });

            for (int i = 0; i < changes.Length; i++)
            {
                List<int> newSums = new List<int>();
                List<int> sumsToRemove = new List<int>();

                foreach (var item in possibleSums)
                {
                    sumsToRemove.Add(item);

                    if (item + changes[i] <= maximumSpeed)
                    {
                        if (!contained[item + changes[i]])
                        {
                            contained[item + changes[i]] = true;
                            newSums.Add(item + changes[i]);
                        }
                    }

                    if (item - changes[i] >= 0)
                    {
                        if (!contained[item - changes[i]])
                        {
                            contained[item - changes[i]] = true;
                            newSums.Add(item - changes[i]);
                        }
                    }
                }

                foreach (var item in sumsToRemove)
                {
                    contained[item] = false;

                    possibleSums.Remove(item);
                }

                foreach (var item in newSums)
                {
                    possibleSums.AddLast(item);
                }
            }

            if (possibleSums.Count == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                int max = 0;

                foreach (var item in possibleSums)
                {
                    if (item > max)
                    {
                        max = item;
                    }
                }

                Console.WriteLine(max);
            }
        }
    }
}
