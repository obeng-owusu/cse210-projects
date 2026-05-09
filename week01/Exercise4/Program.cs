using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Step 1: Collect numbers from user until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            int input;

            // Validate input
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Please enter a valid number: ");
            }

            // Stop if user enters 0
            if (input == 0)
            {
                break;
            }

            // Add number to list (0 is not added)
            numbers.Add(input);
        }

        // Check if the list has any numbers
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Core Requirements:

        // 1. Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // 2. Compute the average
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // 3. Find the maximum (largest) number
        int max = numbers[0]; // Start with first number
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenges:

        // 4. Find the smallest positive number (closest to zero)
        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            if (number > 0) // Check if positive
            {
                if (smallestPositive == null || number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // 5. Sort the list and display it
        // Using bubble sort algorithm (without built-in Sort method for learning)
        List<int> sortedNumbers = new List<int>(numbers);
        for (int i = 0; i < sortedNumbers.Count - 1; i++)
        {
            for (int j = 0; j < sortedNumbers.Count - i - 1; j++)
            {
                if (sortedNumbers[j] > sortedNumbers[j + 1])
                {
                    // Swap
                    int temp = sortedNumbers[j];
                    sortedNumbers[j] = sortedNumbers[j + 1];
                    sortedNumbers[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("The sorted list is:");
        foreach (int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }

        // Alternative using built-in Sort method (commented out)
        /*
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        */
    }
}