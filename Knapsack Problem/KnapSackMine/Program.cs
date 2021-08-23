using System;
using System.Collections.Generic;

namespace KnapSackMine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item(60, 10,"Flashlight"),
                new Item(100, 20, "Laptop"),
                new Item(120, 30, "Book")
            };

            Console.WriteLine(KnapSack(50, items));
        }

        public static int KnapSack(int bagCapacity, List<Item> items)
        {
            var itemCount = items.Count;

            int[,] matrix = new int[itemCount + 1, bagCapacity + 1];

            //Go through each item. 
            for (int item = 0; item <= itemCount; item++)
            {
                //This loop basically starts at 0, and slowly gets bigger. 
                //Think of it like working out the best way to fit into smaller bags and then keep building on that. 
                for (int capacity = 0; capacity <= bagCapacity; capacity++)
                {
                    //If we are on the first loop, then set our starting matrix value to 0. 
                    if (item == 0 || capacity == 0)
                    {
                        matrix[item, capacity] = 0;
                        continue;
                    }

                    //Because indexes start at 0, 
                    //it's easier to read if we do this here so we don't think that we are reading the "previous" element etc. 
                    var currentItemIndex = item - 1;
                    var currentItem = items[currentItemIndex];

                    
                       
                    //Is the weight of the current jewel less than W 
                    //(e.g. We could find a place to put it in the bag if we had to, even if we emptied something else?)
                    if (currentItem.Weight <= capacity)
                    {
                        //If I took this jewel right now, and combined it with other gems
                        //Would that be bigger than what you currently think is the best effort now? 
                        //In other words, if W is 50, and I weigh 30. If I joined up with another jewel that was 20 (Or multiple that weigh 20, or none)
                        //Would I be better off with that combination than what you have right now?
                        //If not, then just set the value to be whatever happened with the last item 
                        //(may have fit, may have done the same thing and not fit and got the previous etc). 
                        matrix[item, capacity] = Math.Max(currentItem.Value + matrix[item - 1, capacity - currentItem.Weight]
                                                , matrix[item - 1, capacity]);
                    }
                    //This jewel can't fit, so bring forward what the last value was because that's still the "best" fit we have. 
                    else
                    {
                        matrix[item, capacity] = matrix[item - 1, capacity];
                    }

                   
                }
            }

            //Because we carry everything forward, the very last item on both indexes is our max val
            return matrix[itemCount, bagCapacity];
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
            return $"<{this.Name}>" + $" - Weight: {this.Weight}\n" + $"-Value: {this.Value} \n";
        }
    }
}
