using System;
using System.Collections.Generic;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;
    private string _mood;

    public Entry(string prompt, string response, string date, string mood)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
        _mood = mood;
    }

    public string GetFormattedEntry()
    {
        int wordCount = _response.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        return
            $"Date: {_date}\n" +
            $"Mood: {_mood}\n" +
            $"Prompt: {_prompt}\n" +
            $"Response: {_response}\n" +
            $"Word Count: {wordCount}\n";
    }

    public string ToCSV()
    {
        return $"{EscapeCSV(_date)},{EscapeCSV(_mood)},{EscapeCSV(_prompt)},{EscapeCSV(_response)}";
    }

    public static Entry FromCSV(string csvLine)
    {
        string[] parts = ParseCSV(csvLine);

        if (parts.Length == 4)
        {
            return new Entry(
                parts[2],
                parts[3],
                parts[0],
                parts[1]
            );
        }

        return null;
    }

    private static string EscapeCSV(string text)
    {
        text = text.Replace("\"", "\"\"");
        return $"\"{text}\"";
    }

    private static string[] ParseCSV(string line)
    {
        List<string> values = new List<string>();

        bool inQuotes = false;

        string current = "";

        foreach (char c in line)
        {
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                values.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }

        values.Add(current);

        for (int i = 0; i < values.Count; i++)
        {
            values[i] = values[i].Replace("\"\"", "\"").Trim('"');
        }

        return values.ToArray();
    }
}