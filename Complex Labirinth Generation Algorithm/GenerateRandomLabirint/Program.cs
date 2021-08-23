using System;
using System.Collections.Generic;

namespace GenerateRandomLabirint
{
    class Program
    {
        static int X = 20;
        static int Y = 20;

        static bool IsInMatrix(int x, int y)
        {
            return x < X && x >= 0 && y < Y && y >= 0;
        }

        static void GenerateRandomMatrix(string[,] matrix)
        {
            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            var possibleCells = new Dictionary<int, string>()
            {
                [0] = "-",
                [1] = "#",
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = possibleCells[1];
                }
            }

            var random = new Random();

            matrix[0, 0] = possibleCells[0];
            visited[0, 0] = true;

            var walls = new List<KeyValuePair<int, int>>();

            walls.Add(new KeyValuePair<int, int>(0, 1));
            walls.Add(new KeyValuePair<int, int>(1, 0));

            while (walls.Count > 0)
            {
                int randomIndex = random.Next(0, walls.Count);
                int currentWallRow = walls[randomIndex].Key;
                int currentWallColumn = walls[randomIndex].Value;
                int visitedNeighbours = 0;

                if (IsInMatrix(currentWallRow - 1, currentWallColumn) && visited[currentWallRow - 1, currentWallColumn]) visitedNeighbours++;
                if (IsInMatrix(currentWallRow, currentWallColumn + 1) && visited[currentWallRow, currentWallColumn + 1]) visitedNeighbours++;
                if (IsInMatrix(currentWallRow + 1, currentWallColumn) && visited[currentWallRow + 1, currentWallColumn]) visitedNeighbours++;
                if (IsInMatrix(currentWallRow, currentWallColumn - 1) && visited[currentWallRow, currentWallColumn - 1]) visitedNeighbours++;

                if (visitedNeighbours < 2)
                {
                    matrix[currentWallRow, currentWallColumn] = possibleCells[0];
                    visited[currentWallRow, currentWallColumn] = true;

                    if (IsInMatrix(currentWallRow - 1, currentWallColumn)
                        && !visited[currentWallRow - 1, currentWallColumn]
                        && matrix[currentWallRow - 1, currentWallColumn] == possibleCells[1])
                    {
                        walls.Add(new KeyValuePair<int, int>(currentWallRow - 1, currentWallColumn));
                    }

                    if (IsInMatrix(currentWallRow, currentWallColumn + 1)
                        && !visited[currentWallRow, currentWallColumn + 1]
                        && matrix[currentWallRow, currentWallColumn + 1] == possibleCells[1])
                    {
                        walls.Add(new KeyValuePair<int, int>(currentWallRow, currentWallColumn + 1));
                    }

                    if (IsInMatrix(currentWallRow + 1, currentWallColumn)
                        && !visited[currentWallRow + 1, currentWallColumn]
                        && matrix[currentWallRow + 1, currentWallColumn] == possibleCells[1])
                    {
                        walls.Add(new KeyValuePair<int, int>(currentWallRow + 1, currentWallColumn));
                    }

                    if (IsInMatrix(currentWallRow, currentWallColumn - 1)
                        && !visited[currentWallRow, currentWallColumn - 1]
                        && matrix[currentWallRow, currentWallColumn - 1] == possibleCells[1])
                    {
                        walls.Add(new KeyValuePair<int, int>(currentWallRow, currentWallColumn - 1));
                    }
                }

                walls.RemoveAt(randomIndex);
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var matrix = new string[X, Y];

            GenerateRandomMatrix(matrix);

            PrintMatrix(matrix);
        }
    }
}
