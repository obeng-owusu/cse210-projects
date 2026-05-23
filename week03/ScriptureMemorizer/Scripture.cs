using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = text
            .Split(' ')
            .Select(word => new Word(word))
            .ToList();
    }

    public string GetDisplayText()
    {
        List<string> words = new List<string>();

        foreach (Word word in _words)
        {
            words.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}\n{string.Join(" ", words)}";
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        visibleWords = visibleWords
            .OrderBy(x => _random.Next())
            .ToList();

        int numberToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            visibleWords[i].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}