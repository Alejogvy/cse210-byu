using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("Learn C# Basics", "Programming Academy", 600);
        var video2 = new Video("Top 10 Travel Destinations", "Wanderlust Channel", 900);
        var video3 = new Video("Epic Gaming Moments", "GamerPro", 1200);

        // Add comments to each video
        video1.AddComment(new Comment("Alice", "This video was really helpful!"));
        video1.AddComment(new Comment("Bob", "Great explanation, thank you!"));
        video1.AddComment(new Comment("Charlie", "Loved it!"));

        video2.AddComment(new Comment("Diana", "Amazing destinations, can’t wait to visit them."));
        video2.AddComment(new Comment("Eve", "Thanks for sharing!"));
        video2.AddComment(new Comment("Frank", "Inspirational!"));

        video3.AddComment(new Comment("Grace", "That clutch play was awesome!"));
        video3.AddComment(new Comment("Hank", "One of the best compilations I’ve seen."));
        video3.AddComment(new Comment("Ivy", "Made my day!"));

        // Save videos to a playlist
        var videos = new List<Video> { video1, video2, video3 };

        // Show video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
