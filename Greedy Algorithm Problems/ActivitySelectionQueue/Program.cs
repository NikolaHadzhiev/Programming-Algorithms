using System;
using System.Collections.Generic;

namespace ActivitySelectionQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> startQueue = new Queue<int>(new int[] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 });
            Queue<int> finishQueue = new Queue<int>(new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            Queue<string> results = new Queue<string>();

            while (startQueue.Count > 0 && finishQueue.Count > 0)
            {
                int minimalIndex = GetMinimumIndex(finishQueue);

                for (int i = 0; i < minimalIndex; i++)
                {
                    startQueue.Dequeue();
                    finishQueue.Dequeue();
                }
                int currentStart = startQueue.Dequeue();
                int currentEnd = finishQueue.Dequeue();
                results.Enqueue($"{currentStart} - {currentEnd}");

                while (startQueue.Count > 0 && startQueue.Peek() < currentEnd)
                {
                    startQueue.Dequeue();
                    finishQueue.Dequeue();
                }
            }
            foreach (var item in results)
            {
                Console.WriteLine(string.Join("-", item));
            }
        }

        static int GetMinimumIndex(Queue<int> endQueue)
        {
            int minimalEnd = endQueue.Dequeue();
            int minimalIndex = 0;

            endQueue.Enqueue(minimalEnd);

            for (int i = 1; i < endQueue.Count; i++)
            {
                int currentEnd = endQueue.Dequeue();

                if (currentEnd < minimalEnd)
                {
                    minimalEnd = currentEnd;
                    minimalIndex = minimalEnd;
                }
                endQueue.Enqueue(currentEnd);
            }

            return minimalIndex;
        }
    }
}

