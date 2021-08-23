using System;
using System.Text;

namespace LongestCommonSubsequence
{
    class Program
    {
        static int result = 0;

        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();
            int[,] matrix = new int[firstString.Length + 1, secondString.Length + 1];

            LCS(matrix, firstString, secondString, firstString.Length, secondString.Length);
            
        }

        private static int LCS(int[,] matrix, string firstString, string secondString, int row, int col)
        {
            if (matrix[row, col] != 0)
            {
                return matrix[row, col];
            }
            else
            {
                if (row == 0 || col == 0)
                {
                    result = 0;
                }
                else if (firstString[row - 1] == secondString[col - 1])
                {
                    result = 1 + LCS(matrix, firstString, secondString, row - 1, col - 1);
                }
                else
                {
                    int temp1 = LCS(matrix, firstString, secondString, row - 1, col);
                    int temp2 = LCS(matrix, firstString, secondString, row, col - 1);

                    result = Math.Max(temp1, temp2);
                }
            }

            matrix[row, col] = result;
            
            return result;
        }

        static void Print(int[,] matrix, string firstString, string secondString)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (firstString[i] == secondString[j])
                    {
                        sb.Append(firstString[i]);
                    }
                   
                }
            }

            Console.Write(sb);

        }
    }
}
