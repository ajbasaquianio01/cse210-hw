using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity helps you relax by guiding your breathing.";
    }

    protected override void RunActivity()
    {
        int timeLeft = Duration;
        while (timeLeft > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            timeLeft -= 3;
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
            timeLeft -= 3;
        }
    }
}