using System;

class Program
{
    static void Main(string[] args)
    {
         Journal journal = new Journal();
        Random random = new Random();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                Console.Write("How are you feeling today? ");
                string mood = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry
                {
                    _date = date,
                    _prompt = prompt,
                    _response = response,
                    _mood = mood
                };

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayJournal();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
        }
    }
    
}