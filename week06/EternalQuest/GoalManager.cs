using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _pointsThisSession;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _pointsThisSession = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice. Please try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Score: {_score} points");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Bad Habit Tracker)");
        Console.WriteLine("5. Progress Goal (Gradual Achievement)");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        bool goalCreated = true;

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                Console.WriteLine("⚠️ This is a NEGATIVE goal. Recording it will DEDUCT points!");
                break;
            case "5":
                Console.Write("How many times/steps are needed to complete this goal? ");
                int progressTarget = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, description, points, progressTarget));
                Console.WriteLine("📊 This is a PROGRESS goal. You'll need to record it multiple times to complete it!");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                goalCreated = false;
                break;
        }

        if (goalCreated)
        {
            Console.WriteLine($"Goal '{name}' created successfully!");
        }
    }

    private void CheckLevelUp()
    {
        int previousLevel = _level;

        if (_score >= 2000)
            _level = 4;
        else if (_score >= 1000)
            _level = 3;
        else if (_score >= 500)
            _level = 2;
        else
            _level = 1;

        if (_level > previousLevel)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine($"🌟 LEVEL UP! You reached Level {_level}!");
            Console.WriteLine("=================================");
        }
    }

    private void CheckAchievements()
    {
        if (_score >= 1000 && _score - _pointsThisSession < 1000)
        {
            Console.WriteLine();
            Console.WriteLine("🏆 ACHIEVEMENT UNLOCKED!");
            Console.WriteLine("Point Master - Earned 1000 Total Points");
        }

        if (_score >= 5000 && _score - _pointsThisSession < 5000)
        {
            Console.WriteLine();
            Console.WriteLine("🏆 ACHIEVEMENT UNLOCKED!");
            Console.WriteLine("Legendary Scorer - Earned 5000 Total Points");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Please create a goal first.");
            return;
        }

        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _pointsThisSession = pointsEarned;
            _score += pointsEarned;

            if (pointsEarned >= 0)
            {
                Console.WriteLine($"✨ Congratulations! You have earned {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine($"⚠️ That negative habit cost you {Math.Abs(pointsEarned)} points!");
            }

            CheckLevelUp();
            CheckAchievements();

            Console.WriteLine($"You now have {_score} total points.");

            if (_goals[goalIndex].IsComplete())
            {
                Console.WriteLine($"🎉 Congratulations! You completed the goal!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename to save to? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved to {filename} successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename to load from? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            _level = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] data = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        // Format: name,description,points,bonusPoints,target,amountCompleted
                        _goals.Add(new ChecklistGoal(
                            data[0],                           // name
                            data[1],                           // description
                            int.Parse(data[2]),                // points
                            int.Parse(data[4]),                // target (index 4)
                            int.Parse(data[3]),                // bonusPoints (index 3)
                            int.Parse(data[5])));              // amountCompleted
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ProgressGoal":
                        _goals.Add(new ProgressGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4])));
                        break;
                }
            }
        }

        Console.WriteLine($"Goals loaded from {filename} successfully!");
    }
}