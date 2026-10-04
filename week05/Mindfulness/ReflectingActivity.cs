using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> Prompts;
    private List<string> Questions;
    private Random rand = new Random();

    public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions)
        : base(name, description)
    {
        Prompts = prompts;
        Questions = questions;
    }

    public void Run()
    {
        StartMessage();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string question = Questions[rand.Next(Questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
        }

        EndMessage();
    }
}
