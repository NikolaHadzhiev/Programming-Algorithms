using System;
using System.Collections.Generic;
using System.Text;

namespace MoveDownRightSum
{
    class Program
    {
        static int[,] matrix = new int[,] {
                        {2,6,1,8,9,4,2},
                        {1,8,0,3,5,6,7 },
                        {3,4,8,7,2,1,8 },
                        {0,9,2,8,1,7,9 },
                        {2,7,1,9,7,8,2 },
                        {4,5,6,1,2,5,6 },
                        {9,3,5,2,8,1,9 },
                        {2,3,4,1,7,2,8 }
                                        };
        static int[,] sumMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

        static void Main(string[] args)
        {
            sumMatrix[0, 0] = matrix[0, 0];

            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                sumMatrix[0, i] = sumMatrix[0, i - 1] + matrix[0, i];
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                sumMatrix[i, 0] = sumMatrix[i - 1, 0] + matrix[i, 0];
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    sumMatrix[i, j] = matrix[i, j] + (
                        sumMatrix[i - 1, j] > sumMatrix[i, j - 1]
                        ? sumMatrix[i - 1, j] : sumMatrix[i, j - 1]);
                }
            }

            int currentRow = matrix.GetLength(0) - 1;
            int currentCol = matrix.GetLength(1) - 1;
            Stack<int[]> path = new Stack<int[]>();

            path.Push(new int[] { currentRow, currentCol });
            while (currentRow >= 0 && currentCol >= 0)
            {
                if (currentRow == 0)
                {
                    path.Push(new int[] { currentRow, currentCol - 1 });
                    currentCol--;
                }
                else if (currentCol == 0)
                {
                    path.Push(new int[] { currentRow - 1, currentCol });
                    currentRow--;
                }
                else if (sumMatrix[currentRow - 1, currentCol] > sumMatrix[currentRow, currentCol - 1])
                {

                    path.Push(new int[] { currentRow - 1, currentCol });
                    currentRow--;
                }
                else
                {
                    path.Push(new int[] { currentRow, currentCol - 1 });
                    currentCol--;
                }
            }

            path.Pop();

            PrintMatrix(matrix, path);
        }

        static void PrintMatrix(int[,] matrix, Stack<int[]> path)
        {


            int[] currentStep = path.Pop();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == currentStep[0] && j == currentStep[1])
                    {
                        sb.Append('*').Append(' ');
                        if (path.Count > 0)
                        {
                            currentStep = path.Pop();
                        }
                    }
                    else
                    {
                        sb.Append(matrix[i, j]).Append(' ');
                    }
                }

                Console.WriteLine(sb);
            }
        }

    }
}
