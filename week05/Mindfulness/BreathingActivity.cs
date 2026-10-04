using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description) { }

    public void Run()
    {
        StartMessage();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Countdown(4);
            Console.WriteLine("Breathe out...");
            Countdown(4);
        }

        EndMessage();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}
