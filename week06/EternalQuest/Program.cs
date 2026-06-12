using System;

/*
EXCEEDING REQUIREMENTS

1. Leveling System
   - Players level up as their score increases (Novice → Adventurer → Hero → Legend)

2. Progress Goals
   - Long-term goals completed gradually over time (e.g., 17/42 training runs)

3. Negative Goals
   - Records undesirable habits and deducts points (e.g., skipping workouts)

4. Achievement System
   - Unlocks special achievements at score milestones (1000 and 5000 points)
*/

class Program
{
   static void Main(string[] args)
   {
      Console.WriteLine("Welcome to Eternal Quest!");
      GoalManager manager = new GoalManager();
      manager.Start();
      Console.WriteLine("Thank you for using Eternal Quest!");
   }
}