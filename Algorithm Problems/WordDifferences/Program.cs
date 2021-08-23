using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordDifferences
{
    class Program
    {
        static int LCS(int[,] matrix, int row, int col, string firstString)
        {
            int min = int.MaxValue;

            if (row == 0)
            {
                return col;
            }

            if (col == 0)
            {
                return row;
            }

            if (matrix[row - 1, col] < min)
            {
                min = matrix[row - 1, col];
            }

            if (matrix[row, col - 1] < min)
            {
                min = matrix[row, col - 1];
            }

            return min;
        }

        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            // LONGEST COMMON SUBSEQUENCE

            int[,] matrix = new int[firstString.Length, secondString.Length];

            for (int row = 0; row < firstString.Length; row++)
            {
                for (int col = 0; col < secondString.Length; col++)
                {

                    if (firstString[row] == secondString[col] && row > 0 && col > 0)
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        matrix[row, col] = LCS(matrix, row, col, firstString) + 1;
                    }
                }
            }

            PrintMatrix(matrix, firstString, secondString);

            Console.WriteLine($"Deletions and Insertions: {(matrix[firstString.Length - 1, secondString.Length - 1])}");
        }

        private static void PrintMatrix(int[,] matrix, string firstString, string secondString)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("  ");

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                sb.Append(secondString[i] + " ");
            }

            sb.AppendLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sb.Append(firstString[i] + " ");

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);

                    if (j < matrix.GetLength(1) - 1)
                    {
                        sb.Append(" ");
                    }

                    
                }

                sb.AppendLine();
               
            }

            Console.Write(sb);
            
            
        }
    }
}
