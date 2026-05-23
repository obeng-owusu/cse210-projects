using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement: Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        double gradePercentage = double.Parse(input);
        
        // Core Requirement: Determine letter grade
        string letter = "";
        
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Stretch Challenge: Determine the sign (+ or -)
        string sign = "";
        
        // Only add sign for grades that aren't F and handle special cases
        if (letter != "F")
        {
            // Get the last digit (ones place)
            int lastDigit = (int)gradePercentage % 10;
            
            if (lastDigit >= 7)
            {
                // Special case: No A+
                if (letter != "A")
                {
                    sign = "+";
                }
            }
            else if (lastDigit < 3)
            {
                // Special case: A- is allowed, but no F-
                if (letter != "F")
                {
                    sign = "-";
                }
            }
        }
        
        // Core Requirement: Display letter grade (and sign if applicable)
        if (string.IsNullOrEmpty(sign))
        {
            Console.WriteLine($"Your letter grade is: {letter}");
        }
        else
        {
            Console.WriteLine($"Your letter grade is: {letter}{sign}");
        }
        
        // Core Requirement: Determine if the user passed the course
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll do better next time!");
        }
    }
}