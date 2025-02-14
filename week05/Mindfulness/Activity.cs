using System;
using System.Threading;

abstract class Activity
{
    protected int Duration;
    protected string Name;
    protected string Description;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(3);
        RunActivity();
        End();
    }

    protected abstract void RunActivity();

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int duration)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < duration * 4; i++)
        {
            Console.Write($"\r{spinner[i % 4]} ");
            Thread.Sleep(250);
        }
        Console.WriteLine();
    }

    private void End()
    {
        Console.WriteLine("Good job!");
        ShowCountdown(3);
        Console.WriteLine($"You completed the {Name} Activity for {Duration} seconds.");
        ShowCountdown(3);
    }
}