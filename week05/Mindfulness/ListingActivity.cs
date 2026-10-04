using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> Prompts;
    private List<string> UserResponses;
    private Random rand = new Random();

    public ListingActivity(string name, string description, List<string> prompts)
        : base(name, description)
    {
        Prompts = prompts;
        UserResponses = new List<string>();
    }

    public void Run()
    {
        StartMessage();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        Console.WriteLine("You may begin listing items...");

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
                UserResponses.Add(response);
        }

        Console.WriteLine($"You listed {UserResponses.Count} items!");
        EndMessage();
    }
}
