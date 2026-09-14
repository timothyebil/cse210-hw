// Journal.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?", // Added prompt for creativity
        "What challenge did I overcome today?" // Added prompt for creativity
    };

    // Method to create a new entry with a random prompt
    public void WriteNewEntry()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string randomPrompt = _prompts[index];
        string currentDate = DateTime.Now.ToShortDateString();

        Console.WriteLine($"\nPrompt: {randomPrompt}");
        Console.Write(">");
        string userResponse = Console.ReadLine();

        Entry newEntry = new Entry(randomPrompt, userResponse, currentDate);
        _entries.Add(newEntry);
        Console.WriteLine("Entry successfully recorded.");
    }

    // Method to display all entries
    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save the journal to a file using JSON
    public void SaveToFile(string filename)
    {
        try
        {
            // Use System.Text.Json for robust saving (exceeds requirements)
            string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonString);
            Console.WriteLine($"Journal saved successfully to {filename}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while saving: {e.Message}");
        }
    }

    // Method to load the journal from a file using JSON
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            // Load and deserialize the JSON data
            string jsonString = File.ReadAllText(filename);
            // Replace current entries with loaded ones
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString); 
            Console.WriteLine($"Journal loaded successfully from {filename}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"An error occurred while reading the file (bad format): {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while loading: {e.Message}");
        }
    }
}
