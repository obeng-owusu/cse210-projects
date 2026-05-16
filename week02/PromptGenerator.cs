using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts;
    private readonly Random _random;

    // Constructor
    public PromptGenerator()
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today that I didn't know yesterday?",
            "What made me smile today?",
            "What challenge did I face and how did I overcome it?",
            "What am I grateful for today?",
            "What goal did I make progress on today?"
        };
    }

    // Return a random prompt
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);

        return _prompts[index];
    }
}