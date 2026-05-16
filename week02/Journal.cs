using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    // Constructor
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Add a new entry
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Display all journal entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nThe journal is empty.");
            return;
        }

        Console.WriteLine($"\n=== Journal Entries ({_entries.Count}) ===\n");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save journal entries to a file
    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.GetFileRepresentation());
                }
            }

            Console.WriteLine($"Journal successfully saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Load journal entries from a file
    public void LoadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' does not exist.");
                return;
            }

            List<Entry> loadedEntries = new List<Entry>();

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];

                    Entry entry = new Entry(date, prompt, response);

                    loadedEntries.Add(entry);
                }
            }

            _entries = loadedEntries;

            Console.WriteLine($"Journal successfully loaded from '{filename}'.");
            Console.WriteLine($"{_entries.Count} entries loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}