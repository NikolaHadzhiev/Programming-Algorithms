using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
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

        static int DFS(Dictionary<int, List<int>> graph, int currentNode, bool[] marked)
        {
            int currentLength = 1;

            foreach (var child in graph[currentNode])
            {
                if (!marked[child - 1])
                {
                    marked[child - 1] = true;
                    currentLength += DFS(graph, child, marked);
                }
            }

            return currentLength;
        }

        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] dimensions = command.Split('x');
                int rows = int.Parse(dimensions[0]);
                int cols = int.Parse(dimensions[1]);

                int[,] matrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    char[] columns = Console.ReadLine().ToCharArray();

                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = int.Parse(columns[j] + "");
                    }
                }

                Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

                for (int x = 0, nodeIndex = 1; x < matrix.GetLength(0); x++)
                {
                    for (int y = 0; y < matrix.GetLength(1); y++)
                    {
                        if (matrix[x, y] == 1)
                        {
                            graph.Add(nodeIndex, new List<int>());

                            matrix[x, y] = nodeIndex;

                            nodeIndex++;
                        }
                    }
                }

                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    for (int y = 0; y < matrix.GetLength(1); y++)
                    {
                        if (matrix[x, y] > 0)
                        {
                            int currentNode = matrix[x, y];

                            if (x > 0 && matrix[x - 1, y] > 0)
                            {
                                graph[currentNode].Add(matrix[x - 1, y]);
                                graph[matrix[x - 1, y]].Add(currentNode);
                            }

                            if (y > 0 && matrix[x, y - 1] > 0)
                            {
                                graph[currentNode].Add(matrix[x, y - 1]);
                                graph[matrix[x, y - 1]].Add(currentNode);
                            }
                        }
                    }
                }

                bool[] marked = new bool[graph.Count];

                Dictionary<int, int> asteroids = new Dictionary<int, int>();

                int count = 0;

                for (int i = 1; i <= graph.Count; i++)
                {
                    if (!marked[i - 1])
                    {
                        count++;

                        marked[i - 1] = true;

                        int currentLength = DFS(graph, i, marked);

                        if (!asteroids.ContainsKey(currentLength))
                        {
                            asteroids[currentLength] = 1;
                        }
                        else
                        {
                            asteroids[currentLength]++;
                        }
                    }
                }

                foreach (var item in asteroids.OrderByDescending(a => a.Key))
                {
                    Console.WriteLine($"{item.Value}x{item.Key}");
                }

                Console.WriteLine($"Total: {count}");
            }
        }

        //Console.WriteLine(string.Join(Environment.NewLine, 
        //    graph.Select(entry => $"{entry.Key} -> {string.Join(", ", entry.Value)}")));

        //PrintMatrix(matrix);
    }
}

