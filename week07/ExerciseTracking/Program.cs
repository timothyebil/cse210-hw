using System;
using System.Collections.Generic;

/*
================================================================================
Student Name: Timothy Ebil
Course: CSE 210
Project: Exercise Tracking Program (Week 07 Foundation #3)
================================================================================
*/

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a single unified list to hold polymorphic derived types
            List<Activity> activities = new List<Activity>();

            // Instantiate at least one activity of each type
            activities.Add(new Running("03 Nov 2022", 30, 4.8));
            activities.Add(new Cycling("04 Nov 2022", 45, 20.0));
            activities.Add(new Swimming("05 Nov 2022", 40, 30));

            Console.WriteLine("=================================================================");
            Console.WriteLine("                  FITNESS CENTER EXERCISE LOG                    ");
            Console.WriteLine("=================================================================");
            Console.WriteLine();

            // Iterate through the list, execute GetSummary polymorphically, and display the results
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }

            Console.WriteLine();
            Console.WriteLine("=================================================================");
        }
    }
}
