using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos

        Video video1 = new Video("Rafting Adventure", "OutdoorLife", 300);
        video1.AddComment(new Comment("Alice", "Looks so fun!"));
        video1.AddComment(new Comment("Bob", "I want to try this."));
        video1.AddComment(new Comment("Charlie", "Great video!"));

        Video video2 = new Video("Cooking Pasta", "ChefMario", 600);
        video2.AddComment(new Comment("Diana", "Yummy recipe!"));
        video2.AddComment(new Comment("Ethan", "I’ll cook this tonight."));
        video2.AddComment(new Comment("Fiona", "Love the step-by-step guide."));

        Video video3 = new Video("Tech Review: Laptop X", "TechGuru", 900);
        video3.AddComment(new Comment("George", "Very detailed review."));
        video3.AddComment(new Comment("Hannah", "Helped me decide to buy."));
        video3.AddComment(new Comment("Ian", "Can you review Laptop Y next?"));

        // Put videos in a list

        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display info for each video
        
        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayInfo());
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine("  " + comment.GetDisplayText());
            }
            Console.WriteLine();
        }
    }
}
