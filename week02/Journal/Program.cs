// Program.cs
using System;

class Program
{
    /* 
    * Exceeding Requirements Description:
    * 
    * This program uses JSON serialization via the System.Text.Json library for saving 
    * and loading the journal data. This approach is more robust than using a simple 
    * character separator (like | or ~) because it correctly handles special characters, 
    * commas, and new lines within the user's journal entries without data corruption. 
    * It also includes basic try-catch blocks in the Journal class methods for better 
    * error handling during file operations.
    */
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }
}
