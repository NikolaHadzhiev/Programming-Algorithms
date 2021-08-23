using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivitySelectionList
{
    class Program
    {
        static List<Activities> bestActivities = new List<Activities>();

        static void Main(string[] args)
        {
            List<Activities> activities = new List<Activities>()
            {
                new Activities(1, 4),
                new Activities(3, 5),
                new Activities(0, 6),
                new Activities(5, 7),
                new Activities(3, 8),
                new Activities(5, 9),
                new Activities(6, 10),
                new Activities(8, 11),
                new Activities(8, 12),
                new Activities(2, 13),
                new Activities(12, 14)
             };

            activities = activities.OrderBy(x => x.Finish).ToList();
            Activities currentActivity = activities[0];
            bestActivities.Add(currentActivity);

            while (activities.Count > 0)
            {
                if (activities[0].Start < currentActivity.Finish)
                {
                    activities.RemoveAt(0);
                }
                else
                {
                    currentActivity = activities[0];
                    bestActivities.Add(currentActivity);
                }
            }

            foreach (var activity in bestActivities)
            {
                Console.WriteLine($"{activity.Start} - {activity.Finish}");
            }

        }


        public class Activities
        {
            public Activities(int start, int finish)
            {
                this.Start = start;
                this.Finish = finish;
            }

            public int Start { get; set; }
            public int Finish { get; set; }
        }
    }
}
