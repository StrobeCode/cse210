
using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        ShowIntroduction();

        Stopwatch timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < _duration)
        {
            int timeLeft = _duration - (int)timer.Elapsed.TotalSeconds;
            int inhaleTime = Math.Min(4, timeLeft);

            Console.Write("Breathe in... ");
            ShowCountdown(inhaleTime);
            Console.WriteLine();

            timeLeft = _duration - (int)timer.Elapsed.TotalSeconds;

            if (timeLeft <= 0)
            {
                break;
            }

            int exhaleTime = Math.Min(6, timeLeft);

            Console.Write("Breathe out... ");
            ShowCountdown(exhaleTime);
            Console.WriteLine();
        }

        ShowConclusion();
    }
}
