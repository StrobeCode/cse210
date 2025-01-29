public class Entry
{
    public string _Prompt;
    public string _Input;
    public string _DateTime;

    public void Display()
    {
        Console.WriteLine($"({_DateTime}) {_Prompt}");
        Console.WriteLine($"{_Input}");
    }
}
