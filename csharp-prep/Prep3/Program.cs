using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Random randomgen = new Random();
        int magicNumber = randomgen.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }

            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}