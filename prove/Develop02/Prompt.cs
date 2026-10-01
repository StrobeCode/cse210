using System;

public class Prompt
{
    public string[] _promptsList = new string[]
    {
        "What is one thing you’re grateful for today?",
        "What was the most interesting thing you learned recently?",
        "Describe a goal you’re working toward and how you’re progressing.",
        "Who made a positive impact on your life today, and how?",
        "What’s one thing that made you smile today?"
    };

    public string ChoosePrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _promptsList.Length);
        return _promptsList[randomIndex];
    }
}
