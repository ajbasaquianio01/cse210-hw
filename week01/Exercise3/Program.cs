using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher than that");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower than that");
            }
            else
            {
                Console.WriteLine("Congratulations, you guessed it!");
            }

        }                    
    }
}