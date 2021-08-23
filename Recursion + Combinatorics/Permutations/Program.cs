using System;

namespace Permutations
{
    class Program
    {
        static void Permute(int index, string[] set, string[] sequence, bool[] marked)
        {
            if (index == sequence.Length)
            {
                Console.WriteLine(string.Join(", ", sequence));
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (!marked[i])
                    {
                        marked[i] = true;
                        sequence[index] = set[i];
                        Permute(index + 1, set, sequence, marked);
                        marked[i] = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string[] names = { "Pesho", "Gosho", "Tosho" };

            Permute(0, names, new string[names.Length], new bool[names.Length]);
        }
    }
}
