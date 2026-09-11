using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            // Generate random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guessCount = 0;
            int guess = -1;

            Console.WriteLine("I have picked a magic number between 1 and 100.");

            // Loop until user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine($"You guessed it in {guessCount} tries!");

            // Ask if user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
