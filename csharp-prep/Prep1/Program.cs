using System;

class Program
{
    static void Main(string[] args)
    {
        // Requests first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Request the last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Displays the result in the specified format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}