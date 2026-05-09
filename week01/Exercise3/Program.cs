using System;

class GuessMyNumberGame
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            // Generate random number from 1 to 100
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            bool guessedCorrectly = false;

            Console.WriteLine("\n=== GUESS MY NUMBER GAME ===");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            // Game loop - continues until user guesses correctly
            while (!guessedCorrectly)
            {
                // Ask user for a guess
                Console.Write("\nEnter your guess: ");
                int guess;

                // Validate input
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.Write("Please enter a valid number: ");
                }

                guessCount++;

                // Check the guess
                if (guess == magicNumber)
                {
                    Console.WriteLine($"\nCongratulations! You guessed it in {guessCount} {(guessCount == 1 ? "try" : "tries")}!");
                    Console.WriteLine($"The magic number was {magicNumber}.");
                    guessedCorrectly = true;
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher! Try again.");
                }
                else // guess > magicNumber
                {
                    Console.WriteLine("Lower! Try again.");
                }
            }

            // Ask if user wants to play again
            Console.Write("\nWould you like to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            while (response != "yes" && response != "no")
            {
                Console.Write("Please enter 'yes' or 'no': ");
                response = Console.ReadLine().ToLower();
            }

            playAgain = (response == "yes");

            if (playAgain)
            {
                Console.WriteLine("\nGreat! Let's play again!\n");
            }
            else
            {
                Console.WriteLine("\nThanks for playing! Goodbye!");
            }
        }
    }
}