public class Entry
{
    public string _prompt;
    public string _input;
    public string _dateTime;
    public string _mood;

    public void Display()
    {
        Console.WriteLine($"({_dateTime}) {_prompt}");
        Console.WriteLine($"{_input}");
        Console.WriteLine($"Mood:{_mood}");
    }
}
