using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Reflection Activity Class - Inherits from Activity
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private List<string> _unusedPrompts;
        private List<string> _unusedQuestions;
        private Random _random;

        public ReflectionActivity(SessionManager sessionManager) : base(
            sessionManager,
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _random = new Random();

            // List of available prompts
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            // List of available reflection questions
            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            ResetPromptPool();
            ResetQuestionPool();
        }

        private void ResetPromptPool()
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        private void ResetQuestionPool()
        {
            _unusedQuestions = new List<string>(_questions);
        }

        // Smart randomization - no repeats until all prompts are used
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

        // Smart randomization - no repeats until all questions are used
        private string GetRandomQuestion()
        {
            if (_unusedQuestions.Count == 0)
            {
                ResetQuestionPool();
            }
            int index = _random.Next(_unusedQuestions.Count);
            string question = _unusedQuestions[index];
            _unusedQuestions.RemoveAt(index);
            return question;
        }

        public override void Run()
        {
            DisplayStartingMessage();

            // Display a random prompt
            string prompt = GetRandomPrompt();
            Console.WriteLine("Consider the following prompt:\n");
            Console.WriteLine($"--- {prompt} ---\n");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(3);
            Console.Clear();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            // Keep showing random questions until time runs out
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.Write($"> {question} ");
                ShowSpinner(8);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}