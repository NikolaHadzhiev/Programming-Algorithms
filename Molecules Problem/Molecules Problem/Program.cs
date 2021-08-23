using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molecules
{
    class Program
    {
        static void Main(string[] args)
        {
            //(fromMolecule - (toMolecule - energyCost))
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

            int molecules = int.Parse(Console.ReadLine());
            int connections = int.Parse(Console.ReadLine());

            for (int i = 1; i <= molecules; i++)
            {
                graph.Add(i, new Dictionary<int, int>());
            }

            for (int i = 0; i < connections; i++)
            {
                string[] inputParams = Console.ReadLine().Split(' ');

                int fromMolecule = int.Parse(inputParams[0]);
                int toMolecule = int.Parse(inputParams[1]);
                int energyCost = int.Parse(inputParams[2]);

                graph[fromMolecule][toMolecule] = energyCost;
                //graph[toMolecule][fromMolecule] = energyCost;
            }

            string[] fromToPoints = Console.ReadLine().Split(' ');

            int startPoint = int.Parse(fromToPoints[0]);
            int endPoint = int.Parse(fromToPoints[1]);

            int[] distances = new int[molecules];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[startPoint - 1] = 0;

            SortedSet<int> priorityQueue = new SortedSet<int>(Comparer<int>.Create((first, second) => {
                return distances[first - 1].CompareTo(distances[second - 1]);
            }));

            priorityQueue.Add(startPoint);

            HashSet<int> visited = new HashSet<int>();
            visited.Add(startPoint);

            while (priorityQueue.Count > 0)
            {
                int currentPoint = priorityQueue.First();
                priorityQueue.Remove(currentPoint);

                foreach (var child in graph[currentPoint])
                {
                    if (distances[child.Key - 1] >= distances[currentPoint - 1] + child.Value)
                    {
                        visited.Add(child.Key);
                        distances[child.Key - 1] = distances[currentPoint - 1] + child.Value;
                        priorityQueue.Add(child.Key);
                    }
                }
            }

            Console.WriteLine(distances[endPoint - 1]);

            StringBuilder sb = new StringBuilder();

            foreach (var item in graph.Keys)
            {
                if (!visited.Contains(item))
                {
                    sb.Append(item + " ");
                }
            }

            Console.WriteLine(sb);
        }
    }
}

