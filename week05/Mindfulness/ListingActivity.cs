using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _unusedPrompts;
        private Random _random;

        public ListingActivity(SessionManager sessionManager) : base(
            sessionManager,
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _random = new Random();
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
            ResetPromptPool();
        }

        private void ResetPromptPool()
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        private string GetRandomPrompt()
        {
            if (_unusedPrompts.Count == 0)
            {
                ResetPromptPool();
            }
            int index = _random.Next(_unusedPrompts.Count);
            string prompt = _unusedPrompts[index];
            _unusedPrompts.RemoveAt(index);
            return prompt;
        }

        public override void Run()
        {
            int itemCount = 0;

            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine("List as many things as you can to the following prompt:\n");
            Console.WriteLine($"--- {prompt} ---\n");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                Console.ReadLine();
                itemCount++;
            }

            Console.WriteLine($"\nYou listed {itemCount} items!");
            DisplayEndingMessage();
        }
    }
}