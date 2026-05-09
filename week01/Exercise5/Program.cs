using System;

class Program
{
    static void Main(string[] args)
    {
        // Call each function in sequence
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // Function 1: DisplayWelcome - Shows welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function 2: PromptUserName - Asks for and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function 3: PromptUserNumber - Asks for and returns user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number;

        // Input validation to ensure a valid integer is entered
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Please enter a valid number: ");
        }

        return number;
    }

    // Function 4: SquareNumber - Accepts integer and returns its square
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 5: DisplayResult - Shows user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}