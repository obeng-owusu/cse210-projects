using System;

public class Entry
{
    private readonly string _date;
    private readonly string _prompt;
    private readonly string _response;

    // Constructor for new entries
    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _response = response;
    }

    // Constructor for loading entries from file
    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    // Display entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine(new string('-', 50));
    }

    // Convert entry into file format
    public string GetFileRepresentation()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    // Getters
    public string GetDate()
    {
        return _date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }
}