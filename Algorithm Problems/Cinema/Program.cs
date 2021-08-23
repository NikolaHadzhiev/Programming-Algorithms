using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    class Program
    {
        static void Swap(int from, int to, string[] sequence)
        {
            string temp = sequence[from];
            sequence[from] = sequence[to];
            sequence[to] = temp;
        }

        static void Permute(int index, string[] sequence, Dictionary<string, int> pairs)
        {
            if (index == sequence.Length)
            {
                string[] names = new string[sequence.Length + pairs.Count];

                foreach (var item in pairs)
                {
                    names[item.Value] = item.Key;
                }

                for (int i = 0, j = 0; i < names.Length; i++)
                {
                    if (names[i] == null)
                    {
                        names[i] = sequence[j++];
                    }
                }

                Console.WriteLine(string.Join(" ", names));
            }
            else
            {
                Permute(index + 1, sequence, pairs);

                for (int i = index + 1; i < sequence.Length; i++)
                {
                    Swap(i, index, sequence);
                    Permute(index + 1, sequence, pairs);
                    Swap(i, index, sequence);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");
            Dictionary<string, int> pairs = new Dictionary<string, int>();

            string pair = string.Empty;

            while ((pair = Console.ReadLine()) != "generate")
            {
                string[] nameAndPositionPair = pair.Split(" - ");

                string nameFromPair = nameAndPositionPair[0];
                int indexFromPair = int.Parse(nameAndPositionPair[1]) - 1;
                pairs[nameFromPair] = indexFromPair;
            }

            string[] excludedNames = names.Where(x => !pairs.ContainsKey(x)).ToArray();

            Permute(0, excludedNames, pairs);

            // PERMUTATION ONLY OF EXCLUDED
        }
    }
}
