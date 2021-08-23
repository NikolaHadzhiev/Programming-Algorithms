using System;

namespace FibonacciDP
{
    class Program
    {
        static int[] cache = new int[10];
        static void Main(string[] args)
        {
            Console.WriteLine(FibonacciBottomUp(4));
        }

        private static int FibonacciTopDown(int number)
        {
            if (number <= 1)
            {
                cache[number] = 1;
            }

            if (cache[number] == 0)
            {
                cache[number] = FibonacciTopDown(number - 1) + FibonacciTopDown(number - 2);
            }

            return cache[number];
        }

        private static int FibonacciBottomUp(int number)
        {
            int prePreviousNumber = 1;
            int previousNumber = 1;
            int currentNumber = prePreviousNumber + previousNumber;

            for (int i = 2; i < number; i++)
            {
                prePreviousNumber = previousNumber;
                previousNumber = currentNumber;
                currentNumber = prePreviousNumber + previousNumber;
            }

            return currentNumber;
        }
    }
}
