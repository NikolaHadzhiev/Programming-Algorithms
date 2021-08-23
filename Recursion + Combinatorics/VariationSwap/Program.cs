using System;

namespace VariationSwap
{
    class Program
    {
        static int[] variations = new int[] { 1, 2, 3};
        static int[] elements = new int[2];

        static void Main(string[] args)
        {
            Generate(0, variations, elements);
        }

        private static void Generate(int index, int[] variations, int[] elements)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            for (int i = index; i < variations.Length; i++)
            {
                elements = Swap(elements, variations, index, i);
                Generate(index + 1, variations, elements);
                elements = Swap(elements, variations, index, i);

            }

        }

        private static int[] Swap(int[] elements, int[] variations, int index, int i)
        {
            int temp = variations[index];
            elements[index] = variations[i];
            variations[index] = variations[i];
            variations[i] = temp;
            return elements;
        }
    }
}

