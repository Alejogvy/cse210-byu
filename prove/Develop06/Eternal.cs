using System;
using System.Collections.Generic;

public class EternalQuest
{
    private List<Goal> _goals;
    private int _totalPoints;
    private bool _bonusAwarded;

    public EternalQuest()
    {
        _goals = new List<Goal>
        {
            new FastingGoal(),
            new TestimonyGoal()
        };
        _totalPoints = 0;
        _bonusAwarded = false;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Eternal Program!");
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"\nHi {firstName} {lastName}, let's begin!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Record fasting progress");
            Console.WriteLine("2. Record testimony progress");
            Console.WriteLine("3. Show progress");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterEvent("Fasting");
                    break;
                case "2":
                    RegisterEvent("Testimony");
                    break;
                case "3":
                    ShowProgress();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Thank you for using Eternal. Bye Bye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void RegisterEvent(string goalType)
    {
        Console.Write("Enter the month (e.g., January, February): ");
        string month = Console.ReadLine();

        foreach (Goal goal in _goals)
        {
            if (goalType == "Fasting" && goal is FastingGoal)
            {
                goal.RecordEvent(month);
            }
            else if (goalType == "Testimony" && goal is TestimonyGoal)
            {
                goal.RecordEvent(month);
            }
        }

        CheckBonus();
    }

    private void ShowProgress()
    {
        _totalPoints = 0;
        Console.WriteLine("\nCurrent Progress:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.DisplayProgress());
            _totalPoints += goal.GetPoints();
        }

        Console.WriteLine($"Total Points: {_totalPoints} points");
    }

    private void CheckBonus()
    {
        if (!_bonusAwarded && _goals.TrueForAll(goal => goal.CompletedAllMonths()))
        {
            _totalPoints += 4;
            _bonusAwarded = true;
            Console.WriteLine("Congratulations! You completed all 12 months. +4 bonus points awarded!");
        }
    }
}
