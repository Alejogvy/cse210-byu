public class FastingGoal : Goal
{
    public FastingGoal() : base("Fasting", "Reinforce faith through fasting.") { }

    public override string DisplayProgress()
    {
        int progressCount = GetProgressCount();
        return $"{_name}: {_description} - Points: {_points}. Progress: {progressCount}/12 months.";
    }
}
