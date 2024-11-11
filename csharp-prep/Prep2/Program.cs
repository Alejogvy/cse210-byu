using System;

class Program
{
    static void Main(string[] args)
    {
        // Request the user's rating percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Variable to store the letter grade
        string letter = "";
        
        // Determine the letter grade based on the percentage
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determines whether the user has passed the class
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Try again next time.");
        }

        // Variable to store the "+" or "-" sign in the rating
        string sign = "";

        // Apply the sign only if the grade is not "A" or "F"
        if (letter != "A" && letter != "F")
        {
            int lastDigit = gradePercentage % 10;
            
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && gradePercentage < 94)
        {
            sign = "-";
        }

        // Show the final result
        Console.WriteLine($"Your grade is {letter}{sign}.");
    }
}
