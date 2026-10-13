// Creativity Extension: Added a Leveling System.
// Users level up every 1000 points and earn bonus points.
// This gamification motivates continued progress.
using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent(ref int score);

    public virtual string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent(ref int score)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            score += _points;
            Console.WriteLine($"Goal complete! +{_points} points");
        }
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent(ref int score)
    {
        score += _points;
        Console.WriteLine($"Event recorded! +{_points} points");
    }
}

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _timesCompleted;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    public override void RecordEvent(ref int score)
    {
        _timesCompleted++;
        score += _points;
        Console.WriteLine($"Progress recorded! +{_points} points");

        if (_timesCompleted == _targetCount)
        {
            score += _bonus;
            Console.WriteLine($"Checklist complete! Bonus +{_bonus} points");
        }
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description}) -- Completed {_timesCompleted}/{_targetCount}";
    }
}

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    private void CheckLevelUp()
    {
        int threshold = _level * 1000; // Level up every 1000 points
        if (_score >= threshold)
        {
            _level++;
            Console.WriteLine($"🎉 Congratulations! You reached Level {_level}!");
            Console.WriteLine("You earned a bonus of 200 points!");
            _score += 200; // Bonus for leveling up
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
            _goals.Add(new SimpleGoal(name, description, points));
        else if (choice == "2")
            _goals.Add(new EternalGoal(name, description, points));
        else if (choice == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ShowGoals();
        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        _goals[index].RecordEvent(ref _score);
        CheckLevelUp();
    }

    public void ShowGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"Score: {_score} | Level: {_level}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            output.WriteLine(_level);
            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetDetailsString());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        Console.WriteLine("Goals loaded.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": manager.CreateGoal(); break;
                case "2": manager.RecordEvent(); break;
                case "3": manager.ShowGoals(); break;
                case "4": manager.SaveGoals("goals.txt"); break;
                case "5": manager.LoadGoals("goals.txt"); break;
                case "6": running = false; break;
            }
        }
    }
}
