public abstract class Quest
{
    private string _title;
    private string _details;
    private int _reward;
    private bool _finished;

    public Quest()
    {
        SetTitle("Null");
        SetDetails("Null");
        SetReward(0);
        SetFinished(false);
    }

    public string GetTitle()
    {
        return _title;
    }
    public void SetTitle(string title)
    {
        _title = title;
    }
    public string GetDetails()
    {
        return _details;
    }
    public void SetDetails(string details)
    {
        _details = details;
    }
    public int GetReward()
    {
        return _reward;
    }
    public void SetReward(int reward)
    {
        _reward = reward;
    }
    public void EnterQuestDetails()
    {
        Console.Write("What is the title of your quest? ");
        string title = Console.ReadLine();
        Console.Write("What is a short details of it? ");
        string details = Console.ReadLine();
        Console.Write("What is the amount of score associated with this quest? ");
        int reward = int.Parse(Console.ReadLine());

        SetTitle(title);
        SetDetails(details);
        SetReward(reward);
    }
    public bool IsFinished()
    {
        return _finished;
    }
    public void SetFinished(bool finished)
    {
        _finished = finished;
    }
    public abstract int LogCompletion();
    public virtual string FormatDisplay()
    {
        return $"{GetTitle()} ({GetDetails()})";
    }
    public abstract string SerializeQuest();
}
