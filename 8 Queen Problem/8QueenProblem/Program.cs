using System;
using System.Text;

namespace _8QueenProblem
{
    class Program
    {
        static char[,] board = new char[,] {
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' }
            };

        static int count = 1;
        static void Main(string[] args)
        {
            PutQueens(0);
        }

        static void PutQueens(int row)
        {
            if (row >= 8)
            {
                Console.WriteLine(count);
                PrintSolution();
                Console.WriteLine();
            }
            else
            {
                for (int col = 0; col < 8; col++)
                {
                    if (CanPlaceQueens(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            board[row, col] = '-';
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            board[row, col] = 'Q';

        }

        private static bool CanPlaceQueens(int row, int col)
        {
            for (int i = 0; i < 8; i++)
            {
                if (board[i, col] == 'Q' || board[row, i] == 'Q')
                {
                    return false;
                }
            }

            for (int i = row, j = col; i < 8 && j < 8; i++, j++)
            {
                if (board[i, j] == 'Q')
                {
                    return false;
                }
            }

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 'Q')
                {
                    return false;
                }
            }

            for (int i = row, j = col; i >= 0 && j < 8; i--, j++)
            {
                if (board[i, j] == 'Q')
                {
                    return false;
                }
            }

            for (int i = row, j = col; i < 8 && j >= 0; i++, j--)
            {
                if (board[i, j] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintSolution()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    sb.Append(board[i, j] + " ");
                }
                sb.AppendLine();
            }
            count++;
            Console.WriteLine();
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
