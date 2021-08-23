using System;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int draw = int.Parse(Console.ReadLine());
            Draw(draw);
        }

        private static void Draw(int number)
        {
            if (number <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));
            Draw(number - 1);
            Console.WriteLine(new string('#', number));
        }
    }
}
