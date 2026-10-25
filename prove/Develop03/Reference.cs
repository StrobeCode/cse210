
using System;

public class Reference
{
    private string _bookName;
    private int _chapterNumber;
    private int _firstVerse;
    private int _lastVerse;

    public Reference()
    {
        _bookName = "John";
        _chapterNumber = 3;
        _firstVerse = 16;
        _lastVerse = 0;
    }

    public Reference(string book, int chapter, int verse)
    {
        _bookName = book;
        _chapterNumber = chapter;
        _firstVerse = verse;
        _lastVerse = 0;
    }

    public Reference(string book, int chapter, int start, int end)
    {
        _bookName = book;
        _chapterNumber = chapter;
        _firstVerse = start;
        _lastVerse = end;
    }

    public void GetBookInformation()
    {
        Console.WriteLine("Enter the scripture reference:");

        Console.Write("Book: ");
        _bookName = Console.ReadLine();

        Console.Write("Chapter: ");
        _chapterNumber = int.Parse(Console.ReadLine());

        Console.Write("Verse: ");
        _firstVerse = int.Parse(Console.ReadLine());

        Console.Write("Does this include more than one verse? (y/n): ");
        string choice = Console.ReadLine().ToLower();

        _lastVerse = 0;

        if (choice == "y")
        {
            Console.Write("Ending verse: ");
            _lastVerse = int.Parse(Console.ReadLine());
        }
    }

    public string GetReference()
    {
        string location = $"{_bookName} {_chapterNumber}:{_firstVerse}";

        if (_lastVerse > 0)
        {
            location += $"-{_lastVerse}";
        }

        return location;
    }
}
