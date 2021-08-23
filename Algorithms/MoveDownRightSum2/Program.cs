using System;
using System.Collections.Generic;

namespace MoveDownRightSum2
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

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = (row == 0) ? 1 : 0; col < matrix.GetLength(1); col++)
                {
                    if (row > 0 && col > 0)
                    {
                        if (sumMatrix[row - 1, col] > sumMatrix[row, col - 1])
                        {
                            sumMatrix[row, col] = sumMatrix[row - 1, col] + matrix[row, col];
                        }
                        else
                        {
                            sumMatrix[row, col] = sumMatrix[row, col - 1] + matrix[row, col];
                        }
                    }
                    else if (col == 0)
                    {
                        sumMatrix[row, col] = sumMatrix[row - 1, col] + matrix[row, col];
                    }
                    else
                    {
                        sumMatrix[row, col] = sumMatrix[row, col - 1] + matrix[row, col];
                    }
            }
        }

            List<int> solution = new List<int> { sumMatrix[sumMatrix.GetLength(0) - 1, sumMatrix.GetLength(1) - 1] };
            int scol = sumMatrix.GetLength(1) - 1;
            int srow = sumMatrix.GetLength(0) - 1;

            while (scol > 0 && srow >= 0)
            {
                if (srow == 0)
                {
                    solution.Add(sumMatrix[srow, --scol]);
                }
                else if (sumMatrix[srow - 1, scol] > sumMatrix[srow, scol - 1])
                {
                    solution.Add(sumMatrix[--srow, scol]);
                }
                else
                {
                    solution.Add(sumMatrix[srow, --scol]);
                }
            }
            solution.Reverse();
            Console.WriteLine(string.Join(" ", solution));
    }
}
}
