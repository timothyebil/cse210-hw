/*
 * Course: CSE 210
 * Student Name: Timothy Ebil
 * Project: W05 Mindfulness Program
 * 
 * EXCEEDING CORE REQUIREMENTS EXPLANATION (Criterion 12):
 * 1. Persistent Activity Logging: Session details are tracked automatically using system file 
 *    streams, storing records into a permanent text file database called 'mindfulness_log.txt'. 
 *    Users can query and review their session metrics straight from menu option 4.
 * 2. Prompt Pool No-Repeat Algorithm: Employs dedicated dynamic lists (_promptPool, _questionPool) 
 *    that ensure prompts and follow-up sub-questions never repeat inside a session until every 
 *    single option has been exhausted.
 */

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log history");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            Activity activity = null;

            if (choice == "1")
            {
                activity = new BreathingActivity();
            }
            else if (choice == "2")
            {
                activity = new ReflectionActivity();
            }
            else if (choice == "3")
            {
                activity = new ListingActivity();
            }
            else if (choice == "4")
            {
                DisplayLogFile();
                continue;
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid option. Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            activity.Run();
        }
    }

    static void DisplayLogFile()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Log History ===");
        string filename = "mindfulness_log.txt";

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No history logged yet. Complete an activity first!");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}
