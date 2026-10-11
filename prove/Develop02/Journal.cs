using System;
using System.IO;
// Journal file
public class Journal
{
    public Entry[] _entries = new Entry[10];
    public int _entryCount = 0;
    public Prompt _promptGenerator = new Prompt();

    public void WriteEntry()
    {
        if (_entryCount == _entries.Length)
        {
            ResizeArray();
        }

        string prompt = _promptGenerator.ChoosePrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string input = Console.ReadLine();
        Console.Write("How are you feeling today? ");
        string mood = Console.ReadLine();

        Entry entry = new Entry
        {
            _prompt = prompt,
            _input = input,
            _dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            _mood = mood
        };

        _entries[_entryCount] = entry;
        _entryCount++;
        Console.WriteLine("Entry added!");
    }

    public void DisplayJournal()
    {
        if (_entryCount == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        for (int i = 0; i < _entryCount; i++)
        {
            _entries[i].Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < _entryCount; i++)
            {
                writer.WriteLine(_entries[i]._dateTime);
                writer.WriteLine(_entries[i]._prompt);
                writer.WriteLine(_entries[i]._input);
                writer.WriteLine(_entries[i]._mood);
                writer.WriteLine("---");
            }
        }

        Console.WriteLine($"Journal saved to {fileName}");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries = new Entry[10];
        _entryCount = 0;

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (_entryCount == _entries.Length)
                {
                    ResizeArray();
                }

                string dateTime = line;
                string prompt = reader.ReadLine();
                string input = reader.ReadLine();
                string mood = reader.ReadLine();
                reader.ReadLine();

                Entry entry = new Entry
                {
                    _dateTime = dateTime,
                    _prompt = prompt,
                    _input = input,
                    _mood = mood
                };

                _entries[_entryCount] = entry;
                _entryCount++;
            }
        }

        Console.WriteLine($"Journal loaded from {fileName}");
    }

    public void ResizeArray()
    {
        Entry[] newEntries = new Entry[_entries.Length * 2];
        for (int i = 0; i < _entries.Length; i++)
        {
            newEntries[i] = _entries[i];
        }
        _entries = newEntries;
    }
}
