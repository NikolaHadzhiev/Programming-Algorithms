using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KnapSack_Vol_2
{
    
        class Item
        {
            public Item(int value, int weight, string name)
            {
                this.Name = name;
                this.Value = value;
                this.Weight = weight;
            }

            public int Value { get; set; }

            public int Weight { get; set; }

            public string Name { get; set; }

            public override string ToString()
            {
                return $"<{this.Name}>\n" +
                        $" - Weight: {this.Weight}\n" +
                        $" - Value: {this.Value}";
            }
        }

         class Program
        {
            static void Greedy()
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var items = new Item[]
                {
                new Item(3, 2, "Flashlight"),
                new Item(1, 2, "Laptop"),
                new Item(3, 1, "Book"),
                };

                var knapsackCapacity = 4;

                for (var i = 0; i < items.Length; i++)
                {
                    for (var j = 1; j < items.Length; j++)
                    {
                        if ((items[i].Weight > items[j].Weight)
                            || ((items[i].Weight == items[j].Weight && i != j) && items[i].Value > items[j].Value))
                        {
                            var temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
                        }
                    }
                }

                var remainingCapacity = knapsackCapacity;
                var chosenItems = new List<Item>();

                for (var i = 0; i < items.Length && remainingCapacity > 0; i++)
                {
                    if (items[i].Weight <= remainingCapacity)
                    {
                        remainingCapacity -= items[i].Weight;
                        chosenItems.Add(items[i]);
                    }
                }

                chosenItems.ForEach(Console.WriteLine);

                stopwatch.Stop();

                Console.WriteLine(stopwatch.Elapsed);
            }

            static void DP()
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var items = new Item[]
                {
                new Item(3, 2, "Flashlight"),
                new Item(1, 2, "Laptop"),
                new Item(3, 1, "Book"),
                };

                var knapsackCapacity = 4;
                var dpMatrix = new int[items.Length + 1, knapsackCapacity + 1];
                var boolMatrix = new bool[items.Length + 1, knapsackCapacity + 1];

                var chosenItems = new List<Item>();

                for (var i = 1; i < dpMatrix.GetLength(0); i++)
                {
                    var currentItem = items[i - 1];

                    for (var j = 1; j < dpMatrix.GetLength(1); j++)
                    {
                        // i = current item
                        // j = current capacity
                        if (currentItem.Weight > j)
                        {
                            continue;
                        }

                        var excludedValue = dpMatrix[i - 1, j];
                        var includedValue =
                            dpMatrix[i - 1, j - currentItem.Weight]
                            + currentItem.Value;

                        if (includedValue > excludedValue)
                        {
                            dpMatrix[i, j] = includedValue;
                            boolMatrix[i, j] = true;
                        }
                        else
                        {
                            dpMatrix[i, j] = excludedValue;
                        }
                    }
                }

                var currentRow = items.Length;
                var currentColumn = knapsackCapacity;

                while (currentRow > 0 && currentColumn > 0)
                {
                    if (boolMatrix[currentRow, currentColumn])
                    {
                        chosenItems.Add(items[currentRow - 1]);
                        currentColumn -= items[currentRow - 1].Weight;
                    }

                    currentRow--;
                }

                chosenItems.ForEach(Console.WriteLine);

                stopwatch.Stop();

                Console.WriteLine(stopwatch.Elapsed);
            }

            static void Main(string[] args)
            {
                Greedy();
                DP();
            }
        }
    }
