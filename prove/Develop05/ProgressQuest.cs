public class ProgressQuest : Quest
{
    private int _completionBonus;
    private int _progress;
    private int _target;

    public ProgressQuest() : base()
    {
        SetBonus(0);
        SetProgress(0);
        SetTarget(0);
    }

    public int GetBonus()
    {
        return _completionBonus;
    }
    public void SetBonus(int bonus)
    {
        _completionBonus = bonus;
    }
    public int GetProgress()
    {
        return _progress;
    }
    public void SetProgress(int progress)
    {
        _progress = progress;
    }
    public int GetTarget()
    {
        return _target;
    }
    public void EnterProgressDetails()
    {
        Console.Write("How many times does this quest need to be accomplished for a bonus? ");
        int target = int.Parse(Console.ReadLine());
        while (target < 1)
        {
            Console.Write("Enter a target of at least 1: ");
            target = int.Parse(Console.ReadLine());
        }
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonus = int.Parse(Console.ReadLine());

        SetTarget(target);
        SetBonus(bonus);
    }
    public void SetTarget(int target)
    {
        _target = target;
    }
    public override int LogCompletion()
    {
        if (IsFinished())
        {
            return 0;
        }

        int current = GetProgress();
        int updatedProgress = current + 1;
        SetProgress(updatedProgress);

        if (GetProgress() == GetTarget())
        {
            SetFinished(true);
            return GetReward() + GetBonus();
        }
        return GetReward();
    }
    public override string FormatDisplay()
    {
        return $"{GetTitle()} {GetDetails()} --- Currently Completed: {GetProgress()}/{GetTarget()}";
    }
    public override string SerializeQuest()
    {
        return $"ProgressQuest:{GetTitle()},{GetDetails()},{GetReward()},{IsFinished()},{GetBonus()},{GetProgress()},{GetTarget()}";
    }
}
