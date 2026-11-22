public class RecurringQuest : Quest
{
    public override int LogCompletion()
    {
        return GetReward();
    }
    public override string SerializeQuest()
    {
        return $"RecurringQuest:{GetTitle()},{GetDetails()},{GetReward()},{IsFinished()}";
    }
}
