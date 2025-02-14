using System;

class ReflectionActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity helps you reflect on your strengths and resilience.";
    }

    protected override void RunActivity()
    {
        Random rnd = new Random();
        Console.WriteLine(Prompts[rnd.Next(Prompts.Length)]);
        ShowSpinner(3);
        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.WriteLine(Questions[rnd.Next(Questions.Length)]);
            ShowSpinner(5);
            timeLeft -= 5;
        }
    }
}