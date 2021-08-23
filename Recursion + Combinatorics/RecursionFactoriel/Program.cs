using System;

namespace RecursionFactoriel
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(RecursiveFactoriel(n));
        }

        private static int RecursiveFactoriel(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * RecursiveFactoriel(n - 1);
        }
    }
}
