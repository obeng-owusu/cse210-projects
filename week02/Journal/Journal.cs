using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo journal entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(entry.GetFormattedEntry());
        }
    }

    public void SaveToCSV(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Mood,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToCSV());
            }
        }
    }

    public void LoadFromCSV(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\nFile not found.");
            return;
        }

        List<Entry> loadedEntries = new List<Entry>();

        string[] lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++)
        {
            Entry entry = Entry.FromCSV(lines[i]);

            if (entry != null)
            {
                loadedEntries.Add(entry);
            }
        }

        _entries = loadedEntries;
    }
}