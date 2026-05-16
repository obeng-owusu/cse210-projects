using System;

class Program
{
    static void Main(string[] args)
    {
        // Create journal and prompt generator objects
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            // Display menu
            Console.WriteLine("\n=== Journal Program ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("\nWhat would you like to do? ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    // Generate a random prompt
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");

                    string response = Console.ReadLine() ?? "";

                    // Create new journal entry
                    Entry newEntry = new Entry(prompt, response);

                    // Add entry to journal
                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2":
                    // Display all journal entries
                    Console.WriteLine("\n=== Journal Entries ===");
                    journal.DisplayAll();
                    break;

                case "3":
                    // Save journal to file
                    Console.Write("Enter filename to save to: ");

                    string saveFilename = Console.ReadLine() ?? "";

                    journal.SaveToFile(saveFilename);

                    Console.WriteLine("Journal saved successfully!");
                    break;

                case "4":
                    // Load journal from file
                    Console.Write("Enter filename to load from: ");

                    string loadFilename = Console.ReadLine() ?? "";

                    journal.LoadFromFile(loadFilename);

                    Console.WriteLine("Journal loaded successfully!");
                    break;

                case "5":
                    // Exit application
                    running = false;

                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    // Invalid option
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}