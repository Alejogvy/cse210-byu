using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

/* I exceeded the requirements by using "using System.Text.Json;" to perform data serialization and deserialization 
to read a JSON file in which I added 25 verses that are write domains.*/

class Program
{
    static void Main(string[] args)
    {
        string filePath = "DoctrinalMastery.json";

        // Load scriptures from JSON file
        List<Scripture> scriptures = LoadScripturesFromFile(filePath);

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the JSON file.");
            return;
        }

        // Memorization loop
        while (true)
        {
            // Select a random scripture
            var random = new Random();
            Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

            // Memorization loop for selected scripture
            while (!selectedScripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture);

                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
                string input = Console.ReadLine();
                if (input?.ToLower() == "quit") break;

                selectedScripture.HideRandomWords(3); // Hide 3 words at a time
            }

            Console.Clear();
            Console.WriteLine("Congratulations! All words are now hidden.");
            Console.WriteLine(selectedScripture);

            // Ask the user if they want to see another scripture or exit
            Console.WriteLine("\nWould you like to see another scripture? (yes/no)");
            string choice = Console.ReadLine();
            if (choice?.ToLower() == "no")
            {
                Console.WriteLine("Goodbye!");
                break; // Exit the loop if the user chooses 'no'
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return new List<Scripture>();
        }

        string json = File.ReadAllText(filePath);
        var scriptureData = JsonSerializer.Deserialize<List<JsonElement>>(json);

        var scriptures = new List<Scripture>();
        foreach (var entry in scriptureData)
        {
            var reference = new Reference(
                entry.GetProperty("Reference").GetProperty("Book").GetString(),
                entry.GetProperty("Reference").GetProperty("Chapter").GetInt32(),
                entry.GetProperty("Reference").GetProperty("StartVerse").GetInt32(),
                entry.GetProperty("Reference").TryGetProperty("EndVerse", out var endVerse) ? (int?)endVerse.GetInt32() : null
            );
            scriptures.Add(new Scripture(reference, entry.GetProperty("Text").GetString()));
        }

        return scriptures;
    }
}
