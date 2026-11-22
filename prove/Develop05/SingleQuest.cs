public class SingleQuest : Quest
{
    public override int LogCompletion()
    {
        bool alreadyFinished = IsFinished();
        if (alreadyFinished == false)
        {
            SetFinished(true);
            return GetReward();
        }
        else
        {
            return 0;
        }
    }
    public override string SerializeQuest()
    {
        return $"SingleQuest:{GetTitle()},{GetDetails()},{GetReward()},{IsFinished()}";
    }
}
