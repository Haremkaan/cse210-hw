using System;
public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;  // NEW FEATURE

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine();
    }
}
