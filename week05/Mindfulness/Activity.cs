using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    /// <summary>
    /// Base Activity Class - Contains shared attributes and behaviors.
    /// All activities inherit from this class (Inheritance principle).
    /// </summary>
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private SessionManager _sessionManager;
        protected int _duration;

        public Activity(SessionManager sessionManager, string name, string description)
        {
            _sessionManager = sessionManager;
            _name = name;
            _description = description;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.\n");
            Console.WriteLine(_description);
            Console.WriteLine();

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

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(2);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);

            _sessionManager.RecordActivity(_name, _duration);
        }

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

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}