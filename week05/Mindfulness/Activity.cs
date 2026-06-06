using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base Activity Class - Contains shared attributes and behaviors
    // All activities inherit from this class (Inheritance principle)
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected SessionManager _sessionManager;

        public Activity(SessionManager sessionManager, string name, string description)
        {
            _sessionManager = sessionManager;
            _name = name;
            _description = description;
        }

        // Common starting message for all activities
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.\n");
            Console.WriteLine(_description);
            Console.WriteLine();

            // Input validation to prevent crashes
            Console.Write("How long, in seconds, would you like for your session? ");
            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        // Common ending message for all activities
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(2);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);

            // Record this activity in the session manager
            _sessionManager.RecordActivity(_name, _duration);
        }

        // Animation: Show spinner (| / - \)
        protected void ShowSpinner(int seconds)
        {
            List<string> spinnerFrames = new List<string> { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int frameIndex = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(spinnerFrames[frameIndex % spinnerFrames.Count]);
                Thread.Sleep(200);
                Console.Write("\b");
                frameIndex++;
            }
        }

        // Animation: Countdown timer (5,4,3,2,1)
        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Abstract method to be implemented by derived classes
        // This demonstrates abstraction - each activity implements its own behavior
        public abstract void Run();
    }
}