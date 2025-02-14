using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity helps you reflect on the good things in your life.";
    }

    protected override void RunActivity()
    {
        Random rnd = new Random();
        Console.WriteLine(Prompts[rnd.Next(Prompts.Length)]);
        ShowCountdown(5);
        List<string> items = new List<string>();
        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.Write("List an item: ");
            items.Add(Console.ReadLine());
            timeLeft -= 3;
        }
        Console.WriteLine($"You listed {items.Count} items!");
    }
}