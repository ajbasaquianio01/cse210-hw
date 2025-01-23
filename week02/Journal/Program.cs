using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<JournalEntry> journal = new List<JournalEntry>();
    static Prompt promptManager = new Prompt();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nWelcome to the Journal Program!:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("Please select one of the following choices: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry()
    {
        string prompt = promptManager.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journal.Add(new JournalEntry(prompt, response));
        Console.WriteLine("Entry saved.");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in journal)
        {
            Console.WriteLine(entry);
        }
    }

    static void SaveJournalToFile()
    {
        Console.Write("Create a filename: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in journal)
                {
                    writer.WriteLine($"{entry.Prompt}~|~{entry.Response}~|~{entry.Date}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    static void LoadJournalFromFile()
    {
        Console.Write("What is the filename?: ");
        string filename = Console.ReadLine();

        try
        {
            journal.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split("~|~");
                    if (parts.Length == 3)
                    {
                        journal.Add(new JournalEntry(parts[0], parts[1]) { Date = parts[2] });
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}