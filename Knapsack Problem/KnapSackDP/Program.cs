using System;
using System.Collections.Generic;

namespace KnapSackDP
{
    class Program
    {
        static void Main(string[] args)
        {
            DP();
        }

        static void DP()
        {
            Item[] items =
          {
                new Item(3, 2, "Flashlight"),
                new Item(1, 2, "Laptop"),
                new Item(3, 1, "Book")
            };

            int knapSackCapacity = 4;
            var matrix = new int[items.Length + 1, knapSackCapacity + 1];
            var boolMatrix = new bool[items.Length + 1, knapSackCapacity + 1];

            List<Item> chosenItem = new List<Item>();
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                Item currentItem = items[i - 1];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (currentItem.Weight > j)
                    {
                        continue;
                    }

                    var excludedValue = matrix[i - 1, j];
                    var includedValue = matrix[i - 1, j - currentItem.Weight] + currentItem.Value;

                    if (includedValue > excludedValue)
                    {
                        matrix[i, j] = includedValue;
                        boolMatrix[i, j] = true;
                    }
                    else
                    {
                        matrix[i, j] = excludedValue;
                    }
                }
            }
            var currentRow = items.Length;
            var currentCol = knapSackCapacity;
            while (currentRow > 0 && currentCol > 0)
            {
                if (boolMatrix[currentRow, currentCol])
                {
                    chosenItem.Add(items[currentRow - 1]);
                    currentCol -= items[currentRow - 1].Weight;
                }

                currentRow--;


            }
            chosenItem.ForEach(Console.WriteLine);
        }


    }
}


public class Item
{
    public Item(int value, int weight, string name)
    {
        this.Value = value;
        this.Weight = weight;
        this.Name = name;
    }

    public int Value { get; set; }
    public int Weight { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"<{this.Name}>" + $"\n - Weight: {this.Weight}\n" + $"-Value: {this.Value} \n";
    }
}

