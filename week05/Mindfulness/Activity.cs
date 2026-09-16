using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public abstract class Activity
{
    // Protected member variables allow derived classes direct access per rubric
    protected string _name;
    protected string _description;
    protected int _duration;
    private const string LogFilename = "mindfulness_log.txt";

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Template method pattern for clean workflow inheritance
    public void Run()
    {
        DisplayStartingMessage();
        ExecuteActivity();
        DisplayEndingMessage();
        SaveLogEntry();
    }

    protected abstract void ExecuteActivity();

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive integer for seconds: ");
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Exceeding Requirements feature: File metrics logging
    private void SaveLogEntry()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogFilename, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Completed {_name} for {_duration} seconds.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not update metrics file: {ex.Message}");
        }
    }

    // Exceeding Requirements feature: Dynamic no-repeat pool algorithm
    protected string GetRandomUniqueItem(List<string> originalList, List<string> dynamicPool)
    {
        if (dynamicPool.Count == 0)
        {
            dynamicPool.AddRange(originalList);
        }

        Random rand = new Random();
        int index = rand.Next(dynamicPool.Count);
        string item = dynamicPool[index];
        dynamicPool.RemoveAt(index);
        
        return item;
    }
}
