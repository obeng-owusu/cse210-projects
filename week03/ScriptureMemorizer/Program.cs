using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // EXCEEDED REQUIREMENTS:
        // 1. Added a scripture library with multiple scriptures.
        // 2. Program randomly selects a scripture each time it runs.
        // 3. Improved hiding logic so only visible words are hidden.
        // 4. Added user-friendly instructions and cleaner UI.
        // 5. Added a difficulty system that increases hidden words gradually.

        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            )
        };

        Random random = new Random();

        // Pick a random scripture
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        int wordsToHide = 2;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== Scripture Memorizer ===\n");
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress ENTER to hide words.");
            Console.WriteLine("Type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(wordsToHide);

            // Increase difficulty gradually
            wordsToHide++;

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();

                Console.WriteLine(scripture.GetDisplayText());

                Console.WriteLine("\nGreat job! You memorized the scripture!");
                Console.WriteLine("Press any key to exit.");

                Console.ReadKey();
                break;
            }
        }
    }
}