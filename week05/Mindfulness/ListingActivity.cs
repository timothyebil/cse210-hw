using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };
    private List<string> _promptPool = new List<string>();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will guide you to think broadly by encouraging you to rapidly inventory positive aspects of your life. Start listing items until the session runtime expires.")
    {}

    protected override void ExecuteActivity()
    {
        string prompt = GetRandomUniqueItem(_prompts, _promptPool);

        Console.WriteLine("List as many items as you can according to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userItems = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        string currentInput = "";
        Console.Write("> ");

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(currentInput))
                    {
                        userItems.Add(currentInput.Trim());
                    }
                    currentInput = "";
                    Console.WriteLine();
                    if (DateTime.Now < endTime)
                    {
                        Console.Write("> ");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (currentInput.Length > 0)
                    {
                        currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    }
                }
                else
                {
                    currentInput += keyInfo.KeyChar;
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }
        
        Console.WriteLine();
        Console.WriteLine($"\nYou listed {userItems.Count} items!");
    }
}
