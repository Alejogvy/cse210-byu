using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected Dictionary<string, bool> _monthlyProgress;

    public Goal(string name, string description)
    {
        _name = name;
        _description = description;
        _points = 0;
        _monthlyProgress = new Dictionary<string, bool>
        {
            {"January", false}, {"February", false}, {"March", false}, {"April", false},
            {"May", false}, {"June", false}, {"July", false}, {"August", false},
            {"September", false}, {"October", false}, {"November", false}, {"December", false}
        };
    }

    public virtual void RecordEvent(string month)
    {
        if (_monthlyProgress.ContainsKey(month) && !_monthlyProgress[month])
        {
            _points += 4;
            _monthlyProgress[month] = true;
            Console.WriteLine($"Progress recorded for {month}. +4 points!");
        }
        else
        {
            Console.WriteLine($"Progress for {month} has already been recorded.");
        }
    }

    public bool CompletedAllMonths()
    {
        return !_monthlyProgress.ContainsValue(false);
    }

    public int GetProgressCount()
    {
        int count = 0;
        foreach (var month in _monthlyProgress.Values)
        {
            if (month) count++;
        }
        return count;
    }

    public abstract string DisplayProgress();

    public int GetPoints()
    {
        return _points;
    }

    protected string GetMonthlyProgress()
    {
        List<string> completed = new List<string>();
        foreach (var month in _monthlyProgress)
        {
            if (month.Value) completed.Add(month.Key);
        }
        return string.Join(", ", completed);
    }
}
