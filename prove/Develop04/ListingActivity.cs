
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private List<string> _topics = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.";
    }

    private string ChooseTopic()
    {
        int position = _random.Next(_topics.Count);
        return _topics[position];
    }

    public void Run()
    {
        ShowIntroduction();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {ChooseTopic()} --- ");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        int responseCount = 0;
        Stopwatch timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < _duration)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responseCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {responseCount} items!");

        ShowConclusion();
    }
}
