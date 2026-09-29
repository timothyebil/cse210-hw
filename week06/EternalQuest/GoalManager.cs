using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;
        private int _streak; // New Exceeding Requirement Attribute

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _streak = 0; // Initialize streak at 0
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                UpdateLevel();
                DisplayPlayerInfo();
                
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            int pointsNextLevel = _level * 1000;
            int pointsRemaining = pointsNextLevel - _score;

            Console.WriteLine();
            Console.WriteLine("=================================================================");
            Console.WriteLine($"👑 LEVEL: {_level} | Total Score: {_score} pts | 🔥 Current Streak: {_streak}x");
            Console.WriteLine($"📈 Progress to Level {_level + 1}: {pointsRemaining} points remaining");
            Console.WriteLine("=================================================================");
            Console.WriteLine();
        }

        private void UpdateLevel()
        {
            // Leveling algorithm: Levels scale smoothly every 1000 points accrued.
            _level = (_score / 1000) + 1;
        }

        public void ListGoalNames()
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("\nThe goals are:");
            if (_goals.Count == 0) Console.WriteLine("(No goals added yet)");
            
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nThe types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string desc = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            if (type == "1")
            {
                _goals.Add(new SimpleGoal(name, desc, points));
            }
            else if (type == "2")
            {
                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (type == "3")
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            }
        }

        public void RecordEvent()
        {
            ListGoalNames();
            if (_goals.Count == 0) return;

            Console.Write("\nWhich goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _goals.Count)
            {
                Goal selectedGoal = _goals[index];

                if (selectedGoal.IsComplete())
                {
                    Console.WriteLine("This goal is already fully completed! No points earned, streak reset.");
                    _streak = 0; // Streak breaks if trying to record a dead goal
                    return;
                }

                bool wasCompletedBefore = selectedGoal.IsComplete();
                selectedGoal.RecordEvent();
                
                // Calculate standard base points
                int pointsEarned = selectedGoal.Points;

                // Handle Checklist milestone bonus criteria
                if (selectedGoal is ChecklistGoal checklist)
                {
                    if (!wasCompletedBefore && checklist.IsComplete())
                    {
                        pointsEarned += checklist.Bonus;
                        Console.WriteLine($"🎉 Milestone complete! Bonus of {checklist.Bonus} points awarded!");
                    }
                }

                // Increment streak counter and calculate dynamic streak modifier payout
                _streak++;
                int streakBonus = _streak * 10; 
                pointsEarned += streakBonus;

                _score += pointsEarned;
                Console.WriteLine($"👍 Goal recorded! Base points + Streak Bonus earned: {pointsEarned} total points! (🔥 Streak: {_streak}x)");
                UpdateLevel();
            }
        }

        public void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                outputFile.WriteLine(_streak); // Save current streak to preserve progress state
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals and streak mechanics saved successfully.");
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _streak = int.Parse(lines[1]); // Safely reload streak position from data layout

            for (int i = 2; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] data = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                }
                else if (goalType == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                }
            }
            Console.WriteLine("Goals and leveling mechanics loaded successfully.");
        }
    }
}
