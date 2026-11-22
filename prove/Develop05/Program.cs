// Creativity: Added three milestone awards that unlock as the score increases.
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        int score = 0;
        List<Quest> quests = [];
        while (running == true)
        {
            Console.WriteLine($"You have {score} points");
            Console.WriteLine("Your Rank:");
            Console.WriteLine($"  {(score >= 100 ? "[X]" : "[ ]")} Grunt (100 points)");
            Console.WriteLine($"  {(score >= 500 ? "[X]" : "[ ]")} Senior Officer (500 points)");
            Console.WriteLine($"  {(score >= 1500 ? "[X]" : "[ ]")} General (1500 points)");
            Console.WriteLine();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string menuChoice = Console.ReadLine();

            if (menuChoice == "1") //Create new quest
            {
                Console.WriteLine("The types of Goals are: ");
                Console.WriteLine("  1. Simple Quest");
                Console.WriteLine("  2. Eternal Quest");
                Console.WriteLine("  3. Checklist Quest");
                Console.Write("Which type of quest would you like to create? ");

                string questChoice = Console.ReadLine(); //Here

                if (questChoice == "1") // Create simple quest
                {
                    SingleQuest singleQuest = new SingleQuest();
                    singleQuest.EnterQuestDetails();
                    quests.Add(singleQuest);
                }
                else if (questChoice == "2") // Create eternal quest
                {
                    RecurringQuest recurringQuest = new RecurringQuest();
                    recurringQuest.EnterQuestDetails();
                    quests.Add(recurringQuest);
                }
                else if (questChoice == "3") // Create ProgressQuest
                {
                    ProgressQuest progressQuest = new ProgressQuest();
                    progressQuest.EnterQuestDetails();
                    progressQuest.EnterProgressDetails();
                    quests.Add(progressQuest);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else if (menuChoice == "2") //Display List new quest
            {
                Console.WriteLine("The quests are: ");
                foreach (Quest quest in quests)
                {
                    int index = quests.IndexOf(quest) + 1;
                    bool finished = quest.IsFinished();
                    string marker = "";
                    if (finished == true)
                    {
                        marker = "[X]";
                    }
                    else
                    {
                        marker = "[ ]";
                    }
                    Console.WriteLine($"{index}. {marker} {quest.FormatDisplay()}");
                }

            }
            else if (menuChoice == "3") //Save quest
            {
                Console.WriteLine("What is the file title?");
                Console.WriteLine("Remember to add '.txt'");
                string fileName = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    outputFile.WriteLine(score);

                    foreach (Quest quest in quests)
                    {
                        outputFile.WriteLine(quest.SerializeQuest());
                    }
                }
            }
            else if (menuChoice == "4") //Load quests
            {
                Console.WriteLine("What is the file title?");
                Console.WriteLine("Remember to add '.txt'");
                string fileName = Console.ReadLine();
                quests = [];

                string[] lines = System.IO.File.ReadAllLines(fileName);

                score = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] sections = line.Split(":");
                    string type = sections[0];
                    string data = sections[1];

                    if (type == "SingleQuest") // Here
                    {
                        SingleQuest singleQuest = new SingleQuest();
                        string[] fields = data.Split(",");
                        string title = fields[0];
                        string details = fields[1];
                        int reward = int.Parse(fields[2]);
                        bool finished = bool.Parse(fields[3]);

                        singleQuest.SetTitle(title);
                        singleQuest.SetDetails(details);
                        singleQuest.SetReward(reward);
                        singleQuest.SetFinished(finished);

                        quests.Add(singleQuest);
                    }
                    else if (type == "RecurringQuest")
                    {
                        RecurringQuest recurringQuest = new RecurringQuest();
                        string[] fields = data.Split(",");
                        string title = fields[0];
                        string details = fields[1];
                        int reward = int.Parse(fields[2]);
                        bool finished = bool.Parse(fields[3]);

                        recurringQuest.SetTitle(title);
                        recurringQuest.SetDetails(details);
                        recurringQuest.SetReward(reward);
                        recurringQuest.SetFinished(finished);

                        quests.Add(recurringQuest);
                    }
                    else if (type == "ProgressQuest")
                    {
                        ProgressQuest progressQuest = new ProgressQuest();
                        string[] fields = data.Split(",");
                        string title = fields[0];
                        string details = fields[1];
                        int reward = int.Parse(fields[2]);
                        bool finished = bool.Parse(fields[3]);
                        int bonus = int.Parse(fields[4]);
                        int progress = int.Parse(fields[5]);
                        int target = int.Parse(fields[6]);

                        progressQuest.SetTitle(title);
                        progressQuest.SetDetails(details);
                        progressQuest.SetReward(reward);
                        progressQuest.SetFinished(finished);
                        progressQuest.SetBonus(bonus);
                        progressQuest.SetProgress(progress);
                        progressQuest.SetTarget(target);

                        quests.Add(progressQuest);
                    }
                }
            }
            else if (menuChoice == "5") //Record event
            {
                Console.WriteLine("The quests are:");
                foreach (Quest quest in quests)
                {
                    int index = quests.IndexOf(quest) + 1;
                    Console.WriteLine($"{index}. {quest.GetTitle()}");
                }
                Console.WriteLine("Which quest did you accomplish?");
                if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > quests.Count)
                {
                    Console.WriteLine("Invalid goal selection.");
                    continue;
                }
                int selectedIndex = selection - 1;
                if (quests[selectedIndex].IsFinished())
                {
                    Console.WriteLine("This goal is already complete.");
                    continue;
                }

                int earned = quests[selectedIndex].LogCompletion();
                score = score + earned;

                Console.WriteLine($"Congrats!! you just earned {earned} score!!");
            }
            else if (menuChoice == "6") // quit
            {
                Console.WriteLine("Goodbye");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

    }
}
