
using System;

class Program
{
    static void Main(string[] args)
    {
        // To exceed the requirements I added a feature that keeps track of how many
        // times each activity is completed. When the user quits, the program shows
        // a summary of their activities. I also changed the reflecting activity so
        // questions won't repeat until all the other questions have been used.

        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Start breathing activity");
            Console.WriteLine("    2. Start reflecting activity");
            Console.WriteLine("    3. Start listing activity");
            Console.WriteLine("    4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    reflectingCount++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }

        Console.Clear();

        int total = breathingCount + reflectingCount + listingCount;

        Console.WriteLine("Session Summary");
        Console.WriteLine();
        Console.WriteLine($"Breathing activities: {breathingCount}");
        Console.WriteLine($"Reflecting activities: {reflectingCount}");
        Console.WriteLine($"Listing activities: {listingCount}");
        Console.WriteLine();
        Console.WriteLine($"Total activities completed: {total}");
        Console.WriteLine();
        Console.WriteLine("Goodbye!");
    }
}
