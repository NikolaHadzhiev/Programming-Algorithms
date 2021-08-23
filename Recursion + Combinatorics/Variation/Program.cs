using System;

namespace Variation
{
    class Program
    {
        static int[] variations = new int[] { 1, 2, 3 };
        static int[] elements = new int[2];
        static bool[] used = new bool[variations.Length];

        static void Main(string[] args)
        {
            Generate(0, used, variations, elements);
        }

        private static void Generate(int index, bool[] used, int[] variations, int[] elements)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            for (int i = 0; i < variations.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    elements[index] = variations[i];
                    Generate(index + 1, used, variations, elements);
                    used[i] = false;
                }

            }
        }

        static void GenerateWithRep(int index, bool[] used, int[] variatons, int[] elements)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                for (int i = 0; i < variations.Length; i++)
                {
                    elements[index] = variations[i];
                    Generate(index + 1, used, variations, elements);
                }
            }
        }
    }
}

