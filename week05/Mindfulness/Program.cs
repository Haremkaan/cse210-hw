using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity(
                        "Breathing",
                        "This activity will help you relax by guiding you through slow breathing."
                    );
                    breathing.Run();
                    break;

                case "2":
                    var reflecting = new ReflectingActivity(
                        "Reflecting",
                        "This activity will help you reflect on times of strength and resilience.",
                        new List<string> {
                            "Think of a time when you stood up for someone else.",
                            "Think of a time when you did something really difficult.",
                            "Think of a time when you helped someone in need.",
                            "Think of a time when you did something truly selfless."
                        },
                        new List<string> {
                            "Why was this experience meaningful to you?",
                            "How did you get started?",
                            "What did you learn about yourself?",
                            "How can you keep this experience in mind in the future?"
                        }
                    );
                    reflecting.Run();
                    break;

                case "3":
                    var listing = new ListingActivity(
                        "Listing",
                        "This activity will help you reflect on the good things in your life.",
                        new List<string> {
                            "Who are people that you appreciate?",
                            "What are personal strengths of yours?",
                            "Who are people that you have helped this week?",
                            "Who are some of your personal heroes?"
                        }
                    );
                    listing.Run();
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
