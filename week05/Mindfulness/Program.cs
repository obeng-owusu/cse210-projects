/*
EXCEEDING REQUIREMENTS

This project exceeds the core requirements:

1. Added a new Gratitude Activity that encourages users to focus on positive experiences and appreciation.
2. Added a SessionManager class that tracks statistics such as completed activities, total mindfulness time, 
   average session length, and the last activity performed.
3. Implemented file saving and loading so user progress persists between program executions.
4. Improved randomization by preventing prompts and questions from repeating until all available options have been used.
5. Enhanced the Breathing Activity with a visual breathing animation that expands and contracts to guide inhaling and exhaling.
6. Applied additional object-oriented design by separating activity tracking and file management responsibilities into their own class.
7. Added input validation to prevent crashes from invalid duration entries.
8. Ensured proper encapsulation by making fields private unless derived classes need direct access.
*/

using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness App";
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
╔══════════════════════════════════════════════════════════╗
║                  MINDFULNESS APP                         ║
║         Find peace, reflect, and grow daily             ║
╚══════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            SessionManager sessionManager = new SessionManager();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity(sessionManager);
                        break;
                    case "2":
                        activity = new ReflectionActivity(sessionManager);
                        break;
                    case "3":
                        activity = new ListingActivity(sessionManager);
                        break;
                    case "4":
                        activity = new GratitudeActivity(sessionManager);
                        break;
                    case "5":
                        sessionManager.DisplayStatistics();
                        Console.WriteLine("\nPress Enter to return to menu...");
                        Console.ReadLine();
                        continue;
                    case "6":
                        Console.WriteLine("\nThank you for using the Mindfulness App. Stay peaceful!");
                        running = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-6.");
                        System.Threading.Thread.Sleep(1500);
                        continue;
                }

                if (activity != null)
                {
                    activity.Run();
                }

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("              MENU OPTIONS");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("1.  Breathing Activity");
            Console.WriteLine("2.  Reflection Activity");
            Console.WriteLine("3.  Listing Activity");
            Console.WriteLine("4.  Gratitude Activity");
            Console.WriteLine("5.  View Statistics");
            Console.WriteLine("6.  Quit");
            Console.Write("\nSelect a choice from the menu (1-6): ");
        }
    }
}