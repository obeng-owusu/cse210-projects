using System;

class Program
{
    static void Main()
    {
        // EXCEEDED REQUIREMENTS:
        // 1. Added mood tracking for each journal entry.
        // 2. Added word count for responses.
        // 3. Improved save/load system using CSV format.
        // 4. CSV system correctly handles commas and quotation marks.
        // 5. Improved user interface and overall user experience.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== Journal Program ===");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to CSV File");
            Console.WriteLine("4. Load Journal from CSV File");
            Console.WriteLine("5. Quit");

            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine($"\nPrompt: {prompt}");

                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                    Entry entry = new Entry(prompt, response, date, mood);

                    journal.AddEntry(entry);

                    Console.WriteLine("\nEntry added successfully!");
                    Pause();
                    break;

                case "2":

                    Console.Clear();
                    journal.DisplayAll();
                    Pause();
                    break;

                case "3":

                    Console.Write("\nEnter filename (example: journal.csv): ");
                    string saveFile = Console.ReadLine();

                    journal.SaveToCSV(saveFile);

                    Console.WriteLine("\nJournal saved successfully!");
                    Pause();
                    break;

                case "4":

                    Console.Write("\nEnter filename to load: ");
                    string loadFile = Console.ReadLine();

                    journal.LoadFromCSV(loadFile);

                    Console.WriteLine("\nJournal loaded successfully!");
                    Pause();
                    break;

                case "5":

                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:

                    Console.WriteLine("\nInvalid choice.");
                    Pause();
                    break;
            }
        }
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}