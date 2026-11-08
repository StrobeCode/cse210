
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    private List<string> _situations = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something very difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();
    private List<string> _unusedQuestions = new List<string>();

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    private string SelectSituation()
    {
        return _situations[_random.Next(_situations.Count)];
    }

    private string SelectQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_unusedQuestions.Count);
        string selected = _unusedQuestions[index];

        _unusedQuestions.RemoveAt(index);

        return selected;
    }

    public void Run()
    {
        ShowIntroduction();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {SelectSituation()} --- ");
        Console.WriteLine();

        Console.WriteLine("Think about the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        _unusedQuestions.Clear();

        Stopwatch timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < _duration)
        {
            Console.WriteLine($"> {SelectQuestion()}");

            int secondsLeft = _duration - (int)timer.Elapsed.TotalSeconds;
            int pauseTime = Math.Min(10, secondsLeft);

            ShowSpinner(pauseTime);
            Console.WriteLine();
        }

        ShowConclusion();
    }
}
