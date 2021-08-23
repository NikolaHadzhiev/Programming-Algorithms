using System;
using System.Text;

namespace Labirint
{
    class Program
    {
        static char[,] lab =
          {
                {'-', '-', '-', '*', '-', '-', '-'},
                {'*', '*', '-', '*', '-', '*', '-'},
                {'-', '-', '-', '-', '-', '-', '-'},
                {'-', '*', '*', '*', '*', '*', '-'},
                {'-', '-', '-', '-', '-', '-', 'e'}
           };

        static void Main(string[] args)
        {
            FindPath(0, 0);
        }

        private static void FindPath(int row, int col)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                Console.WriteLine("Path found!");
                Print();
            }
            else if (!IsVisited(row, col) && IsPassable(row, col))
            {
                Mark(row, col);
                FindPath(row, col + 1);
                FindPath(row + 1, col);
                FindPath(row, col - 1);
                FindPath(row - 1, col);
                Unmark(row, col);
            }
        }

        private static bool IsInBounds(int row, int col)
        {
            if (row > 4 || row < 0 || col > 6 || col < 0)
            {
                return false;
            }

            return true;
        }

        private static bool IsPassable(int row, int col)
        {
            if (lab[row, col] == '*' || lab[row, col] == 'e')
            {
                return false;
            }
            return true;
        }

        private static void Mark(int row, int col)
        {
            lab[row, col] = '#';
        }

        private static void Unmark(int row, int col)
        {
            lab[row, col] = '-';
        }

        private static bool IsVisited(int row, int col)
        {
            if (lab[row, col] == '#')
            {
                return true;
            }

            return false;
        }

        private static void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    sb.Append(lab[i, j] + " ");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
