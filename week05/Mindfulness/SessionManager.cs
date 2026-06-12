using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MindfulnessApp
{
    public class SessionManager
    {
        private Dictionary<string, int> _activityCounts;
        private int _totalSeconds;
        private string _lastActivity;
        private string _logFileName;

        public SessionManager(string logFileName = "mindfulness_log.txt")
        {
            _logFileName = logFileName;
            _activityCounts = new Dictionary<string, int>
            {
                { "Breathing Activity", 0 },
                { "Reflection Activity", 0 },
                { "Listing Activity", 0 },
                { "Gratitude Activity", 0 }
            };
            _totalSeconds = 0;
            _lastActivity = "None";
            LoadProgress();
        }

        public void RecordActivity(string activityName, int duration)
        {
            if (_activityCounts.ContainsKey(activityName))
            {
                _activityCounts[activityName]++;
            }
            _totalSeconds += duration;
            _lastActivity = activityName;
            SaveProgress();
        }

        public void DisplayStatistics()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║         MINDFULNESS STATISTICS         ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            Console.WriteLine($"{"Activity",-25} {"Sessions",10}");
            Console.WriteLine(new string('-', 37));

            foreach (var activity in _activityCounts)
            {
                Console.WriteLine($"{activity.Key,-25} {activity.Value,10}");
            }

            Console.WriteLine(new string('-', 37));
            int totalActivities = _activityCounts.Values.Sum();
            Console.WriteLine($"{"Total Activities",-25} {totalActivities,10}");
            Console.WriteLine($"{"Total Mindfulness Time",-25} {_totalSeconds,10} seconds");
            Console.WriteLine($"{"Last Activity",-25} {_lastActivity,10}");

            if (totalActivities > 0)
            {
                Console.WriteLine($"{"Average Session Length",-25} {_totalSeconds / totalActivities,10} seconds");
            }
        }

        private void SaveProgress()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_logFileName))
                {
                    foreach (var activity in _activityCounts)
                    {
                        writer.WriteLine($"{activity.Key},{activity.Value}");
                    }
                    writer.WriteLine($"TotalSeconds,{_totalSeconds}");
                    writer.WriteLine($"LastActivity,{_lastActivity}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving progress: {ex.Message}");
            }
        }

        private void LoadProgress()
        {
            if (File.Exists(_logFileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(_logFileName);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            if (_activityCounts.ContainsKey(parts[0]))
                            {
                                _activityCounts[parts[0]] = int.Parse(parts[1]);
                            }
                            else if (parts[0] == "TotalSeconds")
                            {
                                _totalSeconds = int.Parse(parts[1]);
                            }
                            else if (parts[0] == "LastActivity")
                            {
                                _lastActivity = parts[1];
                            }
                        }
                    }
                    Console.WriteLine("✅ Progress loaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading progress: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No existing progress file found. Starting fresh.");
            }
            Thread.Sleep(1500);
        }
    }
}