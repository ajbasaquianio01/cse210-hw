using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string Name;
    protected int Points;
    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string SaveData();
    
    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }
}

class SimpleGoal : Goal
{
    private bool IsCompleted;
    
    public SimpleGoal(string name, int points) : base(name, points)
    {
        IsCompleted = false;
    }
    
    public override void RecordEvent()
    {
        IsCompleted = true;
        Program.UserScore += Points;
    }
    
    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
    
    public override string SaveData()
    {
        return $"Simple,{Name},{Points},{IsCompleted}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }
    
    public override void RecordEvent()
    {
        Program.UserScore += Points;
    }
    
    public override string GetStatus()
    {
        return "[∞] " + Name;
    }
    
    public override string SaveData()
    {
        return $"Eternal,{Name},{Points}";
    }
}

class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int Bonus;
    
    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }
    
    public override void RecordEvent()
    {
        CurrentCount++;
        Program.UserScore += Points;
        if (CurrentCount == TargetCount)
        {
            Program.UserScore += Bonus;
        }
    }
    
    public override string GetStatus()
    {
        return (CurrentCount >= TargetCount ? "[X] " : "[ ] ") + Name + $" (Completed {CurrentCount}/{TargetCount})";
    }
    
    public override string SaveData()
    {
        return $"Checklist,{Name},{Points},{CurrentCount},{TargetCount},{Bonus}";
    }
}

class Program
{
    public static int UserScore = 0;
    private static List<Goal> Goals = new List<Goal>();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": RecordEvent(); break;
                case "3": ShowGoals(); break;
                case "4": Console.WriteLine($"Score: {UserScore}"); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": return;
            }
        }
    }
    
    static void CreateGoal()
    {
        Console.WriteLine("Choose Goal Type: 1. Simple 2. Eternal 3. Checklist");
        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());
        
        switch (type)
        {
            case "1": Goals.Add(new SimpleGoal(name, points)); break;
            case "2": Goals.Add(new EternalGoal(name, points)); break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                Goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
        }
    }
    
    static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Select goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < Goals.Count)
        {
            Goals[index].RecordEvent();
        }
    }
    
    static void ShowGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].GetStatus()}");
        }
    }
    
    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(UserScore);
            foreach (Goal goal in Goals)
            {
                writer.WriteLine(goal.SaveData());
            }
        }
    }
    
    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            Goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            UserScore = int.Parse(lines[0]);
            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                switch (parts[0])
                {
                    case "Simple": Goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2]))); break;
                    case "Eternal": Goals.Add(new EternalGoal(parts[1], int.Parse(parts[2]))); break;
                    case "Checklist": Goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[5]))); break;
                }
            }
        }
    }
}
