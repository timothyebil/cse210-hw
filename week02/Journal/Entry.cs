// Entry.cs
using System;

public class Entry
{
    // Member variables (properties)
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Constructor to easily create new entries
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Default constructor required for JSON deserialization
    public Entry() { }

    // Method to display the entry
    public void Display()
    {
        Console.WriteLine($"\nDate: {Date} - Prompt: {Prompt}");
        Console.WriteLine($"> {Response}");
    }
}
