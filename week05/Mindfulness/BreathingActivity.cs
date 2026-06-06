using System;
using System.Threading;

namespace MindfulnessApp
{
    // Breathing Activity Class - Inherits from Activity
    public class BreathingActivity : Activity
    {
        public BreathingActivity(SessionManager sessionManager) : base(
            sessionManager,
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        // Enhanced breathing animation - expands and contracts like a real breath
        private void AnimateBreathIn()
        {
            Console.WriteLine();
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("\r" + new string('*', i) + new string(' ', 5 - i));
                Thread.Sleep(600);
            }
        }

        private void AnimateBreathOut()
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.Write("\r" + new string('*', i) + new string(' ', 5 - i));
                Thread.Sleep(600);
            }
            Console.WriteLine();
        }

        public override void Run()
        {
            DisplayStartingMessage();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("\nBreathe in... ");
                AnimateBreathIn();

                Console.Write("\nBreathe out... ");
                AnimateBreathOut();
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}