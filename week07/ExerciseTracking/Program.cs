using System;
using System.Collections.Generic;

namespace FitnessTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 4), 45, 12.5),
                new Swimming(new DateTime(2022, 11, 5), 60, 40)
            };

            Console.WriteLine("=== Fitness Activity Summary ===\n");

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
                Console.WriteLine();
            }
        }
    }
}