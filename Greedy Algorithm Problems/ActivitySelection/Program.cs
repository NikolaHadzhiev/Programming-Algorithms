using System;

namespace ActivitySelection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] start = new int[11] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            int[] finish = new int[11] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            Activities(start, finish, 0);
        }

        private static void Activities(int[] start, int[] finish, int finishHour)
        {
            Console.WriteLine($"{start[finishHour]} - {finish[finishHour]}");

            for (int i = 1; i < start.Length; i++)
            {
                if (start[i] >= finish[finishHour])
                {
                    finishHour = i;
                    Console.WriteLine($"{start[i]} - {finish[i]}");
                }
            }

        }
    }
}
