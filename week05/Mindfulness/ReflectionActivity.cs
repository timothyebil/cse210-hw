using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _promptPool = new List<string>();

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _questionPool = new List<string>();

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will guide you to think deeply by having you consider an experience where you demonstrated strength or resilience. Follow-up prompts will help you discover personal patterns of success.")
    {}

    protected override void ExecuteActivity()
    {
        string prompt = GetRandomUniqueItem(_prompts, _promptPool);

        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomUniqueItem(_questions, _questionPool);
            Console.Write($"\n> {question} ");
            ShowSpinner(8);
            Console.WriteLine();
        }
    }
}
