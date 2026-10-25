
using System;

// I exceeded the core requirements by adding a counter
// that shows how many words are left to memorizex

class Program
{
    static void Main(string[] args)
    {
        Reference verseReference = new Reference("John", 3, 16);

        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        Scripture memoryVerse = new Scripture(verseReference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(memoryVerse.DisplayRenderedText());
            Console.WriteLine();
            Console.WriteLine($"Words remaining: {memoryVerse.CountVisibleWords()}");

            if (memoryVerse.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden!");
                break;
            }

            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string userInput = Console.ReadLine();

            if (userInput?.ToLower() == "quit")
            {
                break;
            }

            if (userInput == "")
            {
                memoryVerse.HideRandomWords();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
