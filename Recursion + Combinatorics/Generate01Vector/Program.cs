using System;

namespace Generate01Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] vector = new int[number];
            Generate(0, vector);
        }

        private static void Generate(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Generate(index + 1, vector);
            }
            
        }
    }
}
