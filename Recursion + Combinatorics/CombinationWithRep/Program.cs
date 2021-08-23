using System;

namespace CombinationWithRep
{
    class Program
    {
        static int[] combinations = new int[] { 1, 2, 3, 4};
        static int[] elements = new int[2];

        static void Main(string[] args)
        {
            Comb(0, 0);
        }

        static void Comb(int index, int start)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
            }
            else
            {
                for (int i = start; i < combinations.Length; i++)
                {
                    elements[index] = i;
                    Comb(index + 1, i);
                }
            }
                
        }

    }
}
