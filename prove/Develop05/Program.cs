using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the mindfulness activity!");
            Console.WriteLine("This activity will help you reflect and relax, find a comfortable place and let's get started.");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit the program");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BreathingActivity();
                    break;
                case "2":
                    ReflectionActivity();
                    break;
                case "3":
                    ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye friend! Take care of yourself.");
                    return;
                default:
                    Console.WriteLine("Ups! Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
    static void BreathingActivity()
    {
        DisplayStartMessage("Breathing Activity", 
            "This exercise will help you relax by inhaling and exhaling slowly. Clear your mind and focus on your breathing.");
        int duration = GetDuration();

        for (int i = 0; i < duration / 6; i++)
        {
            DisplayCountdown("Breathe in...");
            DisplayCountdown("Breathe out...");
        }

        DisplayEndMessage("Breathing Activity", duration);
    }
    static void ReflectionActivity()
    {
        DisplayStartMessage("Reflection Activity", 
            "This exercise will help you remember moments in your life when you demonstrated strength and resilience.");
        int duration = GetDuration();

        var prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        var questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        var random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);

        int elapsedTime = 0;
        while (elapsedTime < duration)
        {
            Console.WriteLine(questions[random.Next(questions.Count)]);
            DisplaySpinner(5);
            elapsedTime += 5;
        }

        DisplayEndMessage("Reflection Activity", duration);
    }
    static void ListingActivity()
    {
        DisplayStartMessage("Listing Activity", 
            "This exercise will help you reflect on the good things in life by listing as many things as possible in a specific area.");
        int duration = GetDuration();

        var prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        var random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
        DisplayCountdown("Get ready...");

        List<string> items = new List<string>();
        int elapsedTime = 0;

        while (elapsedTime < duration)
        {
            Console.Write("Enter an item: ");
            items.Add(Console.ReadLine());
            elapsedTime += 5;
        }

        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndMessage("Listing Activity", duration);
    }
    static void DisplayStartMessage(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"Starting {activityName}");
        Console.WriteLine(description);
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(3);
    }
    static void DisplayEndMessage(string activityName, int duration)
    {
        Console.WriteLine("We did it! You have completed the activity, congratulations!");
        Console.WriteLine($"You completed the {activityName} for {duration} seconds.");
        DisplaySpinner(3);
    }
    static int GetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        return int.TryParse(Console.ReadLine(), out int duration) && duration > 0 ? duration : 30;
    }
    static void DisplayCountdown(string message)
    {
        Console.Write($"{message} ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
    static void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write("|/-\\ "[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }
}



