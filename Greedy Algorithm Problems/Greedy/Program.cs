using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    class Program
    {
        static List<string> variations = new List<string>();
        static List<string> combinations = new List<string>();

        public static void Variate(string[] elements, bool[] used, string[] variation, int index, int k)
        {
            if (index >= k)
            {
                variations.Add(string.Join("-", variation));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variation[index] = combinations[i][index] + elements[i];
                        Variate(elements, used, variation, index + 1, k);
                        used[i] = false;
                    }
                }
            }
        }

        public static void Combinate(int[] numbers, int[] current, int index, int start)
        {
            if (index >= current.Length)
            {
                combinations.Add(string.Join("", current));
            }
            else
            {
                for (int i = start; i < numbers.Length; i++)
                {
                    current[index] = numbers[i];
                    Combinate(numbers, current, index + 1, i + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] chars = Console.ReadLine().Select(x => x + "").ToArray();
            int k = int.Parse(Console.ReadLine());

            int[] numbers = Enumerable.Range(0, n).ToArray();

            Combinate(numbers, new int[k], 0, 0);
            Variate(chars, new bool[chars.Length], new string[k], 0, k);

            Console.WriteLine(string.Join("\n", variations));
        }
    }
}
