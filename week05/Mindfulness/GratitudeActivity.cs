using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    /// <summary>
    /// Gratitude Activity - Exceeds core requirements by adding a 4th activity type.
    /// </summary>
    public class GratitudeActivity : Activity
    {
        private List<string> _prompts;
        private Random _random;

        public GratitudeActivity(SessionManager sessionManager) : base(
            sessionManager,
            "Gratitude Activity",
            "This activity will help you cultivate gratitude by reflecting on positive experiences and things you appreciate in your life.")
        {
            _random = new Random();
            _prompts = new List<string>
            {
                "What made you smile today?",
                "Who helped you recently?",
                "What opportunity are you thankful for?",
                "What is something beautiful you noticed today?",
                "Who is someone that makes your life better?",
                "What skill or talent are you grateful for?",
                "What comfort are you thankful for today?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("List three things you are grateful for today:\n");

            for (int i = 1; i <= 3; i++)
            {
                string prompt = _prompts[_random.Next(_prompts.Count)];
                Console.Write($"{i}. {prompt} ");
                Console.ReadLine();
            }

            Console.WriteLine("\n✨ Gratitude is a powerful practice. Keep cultivating it! ✨");
            DisplayEndingMessage();
        }
    }
}