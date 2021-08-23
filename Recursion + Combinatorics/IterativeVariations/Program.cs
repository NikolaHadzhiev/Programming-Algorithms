using System;

namespace IterativeVariations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            int[] arr = new int[k];

            while (true)
            {
                Console.WriteLine(string.Join(' ', arr));
                int index = k - 1;
                while (index >= 0 && arr[index] == n - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                arr[index]++;
                for (int i = index + 1; i < k; i++)
                {
                    arr[i] = 0;
                }
            }
        }
    }
}
