public class TestimonyGoal : Goal
{
    public TestimonyGoal() : base("Testimony", "Strengthen the spirit through testifying.") { }

    public override string DisplayProgress()
    {
        int progressCount = GetProgressCount();
        return $"{_name}: {_description} - Points: {_points}. Progress: {progressCount}/12 months.";
    }
}
