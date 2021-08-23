using System;

namespace Combintions
{
    class Program
    {
        static int[] combinations = new int[] { 1, 2, 3 };
        static int[] elements = new int[2];

        static void Main(string[] args)
        {
            Combine(0, 0, combinations, elements);
        }

        private static void Combine(int index, int setIndex, int[] combinations, int[] elements)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            for (int i = setIndex; i < combinations.Length; i++)
            {
                elements[index] = combinations[i];
                Combine(index + 1, i + 1, combinations, elements);
            }
        }
    }
}
